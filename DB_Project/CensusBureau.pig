data  = LOAD 'CensusBureau.txt' USING PigStorage(',') AS (Datetime:chararray, Population:chararray);

dump data;
STORE data INTO 'CensusBureau_Output/ ' USING PigStorage (',');
