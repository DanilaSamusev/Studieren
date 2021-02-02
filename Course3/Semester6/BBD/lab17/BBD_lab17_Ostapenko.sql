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