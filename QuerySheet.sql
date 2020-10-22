SELECT * FROM ServiceRecord s 
Inner join BankCodeRecord b ON b.ReferneceNumber = s.ReferneceNumber
Inner join GCTRecord g on g.ReferneceNumber = b.ReferneceNumber 
WHERE s.ReferneceNumber = 2020102029


SELECT ServiceRecord.Amount , BankCodeRecord.Amount ,GCTRecord.Amount FROM 
ServiceRecord ,
BankCodeRecord ,
GCTRecord  
WHERE ServiceRecord.ReferneceNumber = 2020102032
AND BankCodeRecord.ReferneceNumber = 2020102032
AND GCTRecord.ReferneceNumber = 2020102032

SELECT ServiceRecord.Amount , BankCodeRecord.Amount , GCTRecord.Amount FROM ServiceRecord 
full outer  join BankCodeRecord  ON BankCodeRecord.ReferneceNumber = ServiceRecord.ReferneceNumber 
full  outer  join GCTRecord  on GCTRecord.ReferneceNumber = BankCodeRecord.ReferneceNumber 
WHERE ServiceRecord.ReferneceNumber = 2020102029


CREATE TABLE new5
(
    TransactionDetails NVARCHAR (MAX) ,
    ReferneceNumber NVARCHAR(max),
    AccountNumber NVARCHAR(max),
    SubAccount NVARCHAR(Max),
    Amount DECIMAL (18, 2)
)
GO
INSERT INTO new5
SELECT  *
FROM    (
        SELECT TransactionDetails , ReferneceNumber ,AccountNumber , SubAccount , Amount FROM ServiceRecord 
        UNION
        SELECT TransactionDetails , ReferneceNumber ,AccountNumber , SubAccount , Amount FROM GCTRecord
        UNION
        SELECT TransactionDetails , ReferneceNumber ,AccountNumber , SubAccount , Amount FROM BankCodeRecord 
        ) LU --LU is added.

 Select * From New5


        SELECT DocumentType,  CustomerID, TransactionDetails , ReferneceNumber ,AccountNumber , SubAccount , Amount FROM ServiceRecord 
        UNION
        SELECT  DocumentType, CustomerID,  TransactionDetails , ReferneceNumber ,AccountNumber , SubAccount , Amount FROM GCTRecord
        UNION
        SELECT  DocumentType, CustomerID, TransactionDetails , ReferneceNumber ,AccountNumber , SubAccount , Amount FROM BankCodeRecord 