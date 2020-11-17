Select * FROM ServiceRecord
Where BankAccountNumber = 188090   AND TransactionDate >= '2020/11/16'
UNION 
Select * FROM GCTRecord
Where BankAccountNumber = 188090 AND  TransactionDate >= '2020/11/16'



SELECT   AccountNumber ,FORMAT (TransactionDate, 'dd-MM-yy') As TransDate , SubAccount ,SUM(Amount) FROM BankCodeRecord 
Where   AccountNumber = 130030 AND  TransactionDate >= '2020/11/15'
GROUP BY AccountNumber ,SubAccount ,FORMAT (TransactionDate, 'dd-MM-yy')
