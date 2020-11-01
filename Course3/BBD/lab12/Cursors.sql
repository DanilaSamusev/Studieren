USE JustInMind;

GO
DECLARE Cursor1 CURSOR 
FOR
SELECT Name FROM Users

OPEN Cursor1
FETCH Cursor1
ClOSE Cursor1
DEALLOCATE Cursor1



GO
DECLARE Cursor2 CURSOR 
FOR
SELECT Name, Id FROM Users

DECLARE @Name char(50), @Id int

OPEN Cursor2
FETCH Cursor2 INTO @Name, @Id
PRINT RTRIM(@Name)
PRINT RTRIM(@Id)
ClOSE Cursor2
DEALLOCATE Cursor2



GO
DECLARE Cursor3 CURSOR 
LOCAL
FAST_FORWARD
FOR
SELECT Name FROM Users

DECLARE @Name char(50), @count int

OPEN Cursor3
SET @count = 1
WHILE @count <= 15
BEGIN 
	FETCH Cursor3 INTO @Name
	PRINT RTRIM(@count) + ': ' + RTRIM(@Name)
	SET @count = @count + 1
END
ClOSE Cursor3
DEALLOCATE Cursor3



GO
DECLARE Cursor4 CURSOR 
FOR
SELECT Password FROM Users

OPEN Cursor4
FETCH Cursor4

UPDATE Users SET Password = ''
	WHERE CURRENT OF Cursor4

SELECT Password FROM Users WHERE Id = 1
ClOSE Cursor4
DEALLOCATE Cursor4



GO
DECLARE Cursor5 CURSOR 
LOCAL
KEYSET
FOR
SELECT Name FROM Users

DECLARE @Name char(50), @SecondName char(50)

OPEN Cursor5
FETCH FIRST FROM Cursor5 INTO @Name
FETCH ABSOLUTE 5 FROM Cursor5 INTO @SecondName
PRINT RTRIM(@Name) + ' meets ' + RTRIM(@SecondName)
ClOSE Cursor5
DEALLOCATE Cursor5