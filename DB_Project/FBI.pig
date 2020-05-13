data  = LOAD 'FBI2.txt' USING PigStorage(':') AS (Year:int, Population:chararray, ViolentCrime:chararray);

dump data;
STORE data INTO 'FBI2_Output/ ' USING PigStorage (',');
