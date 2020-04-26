data  = LOAD 'orders450DDTTSS-Head.csv' USING PigStorage(',') AS (OrderID:int, StoreNumber:int, SalesPersonID:int, Item:int, Price:int, Datetime:chararray);

groupbystore = GROUP data BY StoreNumber;

storecount = FOREACH groupbystore GENERATE group, COUNT(data.OrderID);

orderbystore = ORDER storecount BY $1 DESC; /*$1 = StoreNumber*/

topresult = LIMIT orderbystore 1;

DUMP topresult;

/*

data 			 = set of all records (450 in total)

groupbystore 	 = creates a bag for each store number with all connected data

storecount 		 = parses output to store number and order count

orderbystore 	 = Orders output by order count from highest to lowest

topresult 		 = Parses out everything except the first result

Expected results = (98046,81)

*/
