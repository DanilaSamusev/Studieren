USE OstapenkoBBD;
GO


CREATE TABLE УдалённыеПользователи
(
	КодПользователя INT PRIMARY KEY IDENTITY,
    ИмяПользователя NVARCHAR(50) NOT NULL,
    ПарольПользователя NVARCHAR(50) NOT NULL,
    КодРоли INT REFERENCES Роли (КодРоли) ON DELETE CASCADE NOT NULL
);
GO

CREATE TRIGGER УдалениеПользователя
ON Пользователи
AFTER DELETE
AS
INSERT INTO УдалённыеПользователи 
	(ИмяПользователя, ПарольПользователя, КодРоли)
SELECT ИмяПользователя, ПарольПользователя, КодРоли
FROM deleted
GO


CREATE TRIGGER ДобавлениеПерсональныхДанных
ON ПерсональныеДанные
AFTER INSERT
AS
IF NOT EXISTS(SELECT * FROM Пользователи, inserted WHERE Пользователи.КодПользователя = inserted.КодПользователя)
BEGIN
	PRINT 'Пользователя не существует.'
	ROLLBACK TRANSACTION
END
GO


CREATE TRIGGER ДобавлениеИзменениеПользователя
ON Пользователи
AFTER INSERT, UPDATE
AS
IF EXISTS(SELECT * FROM Пользователи, inserted WHERE Пользователи.ИмяПользователя = inserted.ИмяПользователя)
BEGIN
	PRINT 'Логин занят.'
	ROLLBACK TRANSACTION
END
GO


CREATE TRIGGER ДобавлениеСпортивногоСобытия
ON СпортивныеСобытия
AFTER INSERT
AS
IF EXISTS(SELECT * FROM inserted WHERE inserted.ДатаСпортивногоСобытия < GETDATE() AND inserted.РезультатСпортивногоСобытия = NULL)
BEGIN
	PRINT 'Введите результат события.'
	ROLLBACK TRANSACTION
END
GO


CREATE TABLE ДобавленныеГолосования
(
	КодГолосования INT PRIMARY KEY IDENTITY,
    ДатаДобаления DATE
);
GO

CREATE TRIGGER ДобавлениеГолосования
ON Голосования
AFTER INSERT
AS
INSERT INTO ДобавленныеГолосования 
	(ДатаДобаления)
VALUES (GETDATE())
GO


CREATE TRIGGER ДобавлениеКоманды
ON Команды
AFTER INSERT
AS
IF NOT EXISTS(SELECT * FROM ВидыСпорта, inserted WHERE ВидыСпорта.ИмяВидаСпорта = inserted.КодВидаСпорта)
BEGIN
	PRINT 'Виды спорта нет в базе. Сначала добавьте вид спорта'
	ROLLBACK TRANSACTION
END
GO