USE OstapenkoBBD;
GO

CREATE PROCEDURE КоличествоАктуальныхГолосований
AS
SELECT COUNT(*)
FROM СпортивныеСобытия
WHERE СпортивныеСобытия.ДатаСпортивногоСобытия >= GETDATE()
GO

CREATE PROCEDURE КоличествоВидовСпорта
AS
SELECT COUNT(*)
FROM ВидыСпорта
GO

CREATE PROCEDURE КоличествоАдминистраторов
AS
SELECT COUNT(*)
FROM Пользователи
WHERE КодРоли = 1
GO

CREATE PROCEDURE УдалитьНовостнуюЗаписьПоКоду
	@id INT
AS
DELETE FROM НовостныеЗаписи
WHERE КодНовостнойЗаписи = @id
GO

CREATE PROCEDURE УдалитьГолосованиеПоКоду
	@id INT
AS
DELETE FROM Голосования
WHERE КодГолосования = @id
GO

CREATE PROCEDURE ИзменитьЛогинПользователя
	@id INT, @login NVARCHAR(50)
AS
UPDATE Пользователи
SET ИмяПользователя = @login
WHERE КодПользователя = @id
GO

CREATE PROCEDURE СпортивныеСобытияПоВидуСпорта
	@kindOfSport NVARCHAR(50)
AS
SELECT	СП.КодСпортивногоСобытия,
		СП.ИмяСпортивногоСобытия,
		СП.МестоСпортивногоСобытия,
		СП.ДатаСпортивногоСобытия,
		ВС.ИмяВидаСпорта,
		СП.РезультатСпортивногоСобытия
FROM	СпортивныеСобытия AS СП
		LEFT JOIN ВидыСпорта AS ВС ON ВС.КодВидаСпорта = СП.КодВидаСпорта
WHERE	СП.КодВидаСпорта = (SELECT КодВидаСпорта FROM ВидыСпорта WHERE ИмяВидаСпорта = @kindOfSport)
GO

CREATE PROCEDURE ИзменитьРезультатСпортивногоСобытия
	@id INT, @result NVARCHAR(50)
AS
UPDATE СпортивныеСобытия
SET РезультатСпортивногоСобытия = @result
WHERE КодСпортивногоСобытия = @id
GO

CREATE PROCEDURE ДобавитьВидСпорта
	@name NVARCHAR(50)
AS
INSERT INTO ВидыСпорта (ИмяВидаСпорта)
VALUES (@name)
GO

CREATE PROCEDURE ДобавитьСпортивноеСобытие
	@name NVARCHAR(100),
	@date DATE,
	@palce NVARCHAR(50),
	@result NVARCHAR(50)
AS
INSERT INTO СпортивныеСобытия (ИмяСпортивногоСобытия, ДатаСпортивногоСобытия, МестоСпортивногоСобытия, РезультатСпортивногоСобытия)
VALUES (@name, @date, @palce, @result)
GO

CREATE PROCEDURE ГолосованияБезРезультата
AS
SELECT	Г.КодГолосования,
		СС.ИмяСпортивногоСобытия,
		СС.МестоСпортивногоСобытия,
		СС.ДатаСпортивногоСобытия,
		ВС.ИмяВидаСпорта,
		СС.РезультатСпортивногоСобытия
FROM	Голосования AS Г
		LEFT JOIN СпортивныеСобытия AS СС ON СС.КодСпортивногоСобытия = Г.КодСпортивногоСобытия
		LEFT JOIN ВидыСпорта AS ВС ON ВС.КодВидаСпорта = СС.КодВидаСпорта
WHERE	СС.РезультатСпортивногоСобытия = NULL OR СС.РезультатСпортивногоСобытия = ''
GO

CREATE PROCEDURE СпортивныеСобытияПоМесту
	@place NVARCHAR(50)
AS
SELECT	СП.КодСпортивногоСобытия,
		СП.ИмяСпортивногоСобытия,
		СП.МестоСпортивногоСобытия,
		СП.ДатаСпортивногоСобытия,
		ВС.ИмяВидаСпорта,
		СП.РезультатСпортивногоСобытия
FROM	СпортивныеСобытия AS СП
		LEFT JOIN ВидыСпорта AS ВС ON ВС.КодВидаСпорта = СП.КодВидаСпорта
WHERE	СП.МестоСпортивногоСобытия = @place
GO

CREATE PROCEDURE ДобавитьНовостнуюЗапись
	@name NVARCHAR(100),
	@text NVARCHAR(750),
	@voteId INT,
	@userId INT
AS
INSERT INTO НовостныеЗаписи(ИмяНовостнойЗаписи, ТекстНовостнойЗаписи, КодГолосования, КодПользователя)
VALUES (@name, @text, @voteId, @userId)
GO

CREATE PROCEDURE ГолосованияПользователя
	@userId INT
AS
SELECT	Г.КодГолосования,
		СС.ИмяСпортивногоСобытия,
		СС.МестоСпортивногоСобытия,
		СС.ДатаСпортивногоСобытия,
		ВС.ИмяВидаСпорта,
		СС.РезультатСпортивногоСобытия
FROM	Голосования AS Г
		LEFT JOIN СпортивныеСобытия AS СС ON СС.КодСпортивногоСобытия = Г.КодСпортивногоСобытия
		LEFT JOIN ВидыСпорта AS ВС ON ВС.КодВидаСпорта = СС.КодВидаСпорта
WHERE	Г.КодПользователя = @userId
GO

CREATE PROCEDURE ПользователиСРолью
	@roleName NVARCHAR(50)
AS
SELECT	П.КодПользователя,
		П.ИмяПользователя,
		П.ПарольПользователя
FROM Пользователи AS П
WHERE П.КодРоли = (SELECT КодРоли FROM Роли WHERE ИмяРоли = @roleName)
GO