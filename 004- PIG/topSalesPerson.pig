data  = LOAD 'orders450DDTTSS-Head.csv' USING PigStorage(',') AS (OrderID:int, StoreNumber:int, SalesPersonID:int, Item:int, Price:int, Datetime:chararray);

groupbypersonID = GROUP data BY SalesPersonID;

personcount = FOREACH groupbypersonID GENERATE group, COUNT(data.OrderID);

orderbyperson = ORDER personcount BY $1 DESC; /*$1 = StoreNumber*/

topresult = LIMIT orderbyperson 1;

DUMP topresult;

/*

data 			 = set of all records (450 in total)

groupbypersonID  = creates a bag for each Sales Person ID with all connected data

personcount 	 = parses output to Sales Person ID and order count

orderbyperson 	 = Orders output by order count from highest to lowest

topresult 		 = Parses out everything except the first result

Expected results = (21,31)

*/
