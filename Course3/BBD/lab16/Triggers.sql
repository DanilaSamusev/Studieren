USE OstapenkoBBD;
GO


CREATE TABLE УдалённыеПользователи
(
	КодПользователя INT PRIMARY KEY IDENTITY,
    ИмяПользователя NVARCHAR(50) NOT NULL,
    ПарольПользователя NVARCHAR(50) NOT NULL,
    КодРоли INT REFERENCES Роли (КодРоли) ON DELETE CASCADE NOT NULL,
	ВремяУдаления DATETIME NOT NULL
);
GO

CREATE TRIGGER УдалениеПользователя
ON Пользователи
AFTER DELETE
AS
INSERT INTO УдалённыеПользователи 
	(ИмяПользователя, ПарольПользователя, КодРоли, ВремяУдаления)
SELECT ИмяПользователя, ПарольПользователя, КодРоли, CURRENT_TIMESTAMP
FROM deleted
GO


CREATE TABLE УдалённыеНовостныеЗаписи
(
	КодНовостнойЗаписи INT PRIMARY KEY IDENTITY,
    ИмяНовостнойЗаписи NVARCHAR(100) NOT NULL,
    ТекстНовостнойЗаписи NVARCHAR(750) NOT NULL,
    КодГолосования INT REFERENCES Голосования (КодГолосования) ON DELETE NO ACTION NULL,
    КодПользователя INT REFERENCES Пользователи (КодПользователя) ON DELETE NO ACTION NULL,
	ВремяУдаления DATETIME NOT NULL
);
GO

CREATE TRIGGER УдалениеНовостнойЗаписи
ON НовостныеЗаписи
AFTER DELETE
AS
INSERT INTO УдалённыеНовостныеЗаписи 
	(ИмяНовостнойЗаписи, ТекстНовостнойЗаписи, КодГолосования, КодПользователя, ВремяУдаления)
SELECT ИмяНовостнойЗаписи, ТекстНовостнойЗаписи, КодГолосования, КодПользователя, CURRENT_TIMESTAMP
FROM deleted
GO


CREATE TABLE УдалённыеСпортивныеСобытия
(
	КодСпортивногоСобытия INT PRIMARY KEY IDENTITY,
    ИмяСпортивногоСобытия NVARCHAR(100) NOT NULL,
    ДатаСпортивногоСобытия DATE NOT NULL,
    МестоСпортивногоСобытия NVARCHAR(50) NOT NULL,
    РезультатСпортивногоСобытия NVARCHAR(50) NULL,
    КодВидаСпорта INT REFERENCES ВидыСпорта (КодВидаСпорта) ON DELETE CASCADE NOT NULL,
	ВремяУдаления DATETIME NOT NULL
);
GO

CREATE TRIGGER УдалениеСпортивногоСобытия
ON СпортивныеСобытия
AFTER DELETE
AS
INSERT INTO УдалённыеСпортивныеСобытия 
	(ИмяСпортивногоСобытия, ДатаСпортивногоСобытия, МестоСпортивногоСобытия, РезультатСпортивногоСобытия, КодВидаСпорта, ВремяУдаления)
SELECT ИмяСпортивногоСобытия, ДатаСпортивногоСобытия, МестоСпортивногоСобытия, РезультатСпортивногоСобытия, КодВидаСпорта, CURRENT_TIMESTAMP
FROM deleted
GO