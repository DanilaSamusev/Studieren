USE OstapenkoBBD;
GO


DECLARE Cursor1 CURSOR
SCROLL KEYSET
TYPE_WARNING

FOR
SELECT КодПользователя FROM Пользователи
FOR READ ONLY

OPEN Cursor1
DECLARE @Counter INT
SET @Counter = @@CURSOR_ROWS
SELECT @Counter
ClOSE Cursor1
DEALLOCATE Cursor1
GO


DECLARE Cursor2 CURSOR
SCROLL KEYSET
TYPE_WARNING

FOR
SELECT КодСпортивногоСобытия FROM СпортивныеСобытия
FOR READ ONLY

OPEN Cursor2
DECLARE @Counter INT
SET @Counter = @@CURSOR_ROWS
SELECT @Counter
ClOSE Cursor2
DEALLOCATE Cursor2
GO


DECLARE Cursor3 CURSOR
GLOBAL SCROLL KEYSET
TYPE_WARNING

FOR
SELECT ИмяПользователя, ПарольПользователя, КодРоли 
FROM Пользователи
FOR READ ONLY

DECLARE @name NVARCHAR(50), @password NVARCHAR(50), @roleId INT

OPEN Cursor3
DECLARE @Counter INT
SET @Counter = @@CURSOR_ROWS
FETCH NEXT FROM Cursor3 INTO @name, @password, @roleId
WHILE @@FETCH_STATUS = 0
BEGIN
	PRINT @name + ' ' + @password + ' ' + CONVERT(NVARCHAR(50), @roleId)
	FETCH NEXT FROM Cursor3 INTO @name, @password, @roleId
END

PRINT 'Всего записей: ' + CONVERT(NVARCHAR(5), @Counter)
ClOSE Cursor3
DEALLOCATE Cursor3
GO


DECLARE Cursor4 CURSOR 
FOR
SELECT ПарольПользователя FROM Пользователи

OPEN Cursor4
FETCH Cursor4

UPDATE Пользователи SET ПарольПользователя = ''
	WHERE CURRENT OF Cursor4

SELECT ПарольПользователя FROM Пользователи WHERE КодПользователя = 1
ClOSE Cursor4
DEALLOCATE Cursor4
GO


DECLARE Cursor5 CURSOR
GLOBAL SCROLL KEYSET
TYPE_WARNING

FOR
SELECT ФИОПользователя, НомерТелефонаПользователя, ПочтаПользователя
FROM ПерсональныеДанные
FOR READ ONLY 

DECLARE @name NVARCHAR(100), @phone NVARCHAR(50), @email NVARCHAR(50)

OPEN Cursor5
DECLARE @counter INT
SET @counter = 0

PRINT 'Пользователи с ФИО, короче 25 символов: '
FETCH NEXT FROM Cursor5 INTO @name, @phone, @email
WHILE @@FETCH_STATUS = 0
BEGIN
	IF LEN(@name) < 25
    BEGIN
		SET @counter = @counter + 1 
		PRINT @name + @phone + @email
	END
	FETCH NEXT FROM Cursor5 INTO @name, @phone, @email
END
PRINT 'Всего: ' + CONVERT(NVARCHAR(5), @counter)

CLOSE Cursor5
DEALLOCATE Cursor5
GO