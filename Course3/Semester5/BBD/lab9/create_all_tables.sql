USE [OstapenkoBBD];
GO

CREATE TABLE [Роли]
(
	[КодРоли] INT PRIMARY KEY IDENTITY,
    [ИмяРоли] NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE [Пользователи]
(
	[КодПользователя] INT PRIMARY KEY IDENTITY,
    [ИмяПользователя] NVARCHAR(50) NOT NULL,
    [ПарольПользователя] NVARCHAR(50) NOT NULL,
    [КодРоли] INT REFERENCES [Роли] ([КодРоли]) ON DELETE CASCADE NOT NULL
);
GO

CREATE TABLE [ПерсональныеДанные]
(
	[КодПерсональныхДанных] INT PRIMARY KEY IDENTITY,
    [ФИОПользователя] NVARCHAR(100) NOT NULL,
    [НомерТелефонаПользователя] NVARCHAR(50) NULL,
    [ПочтаПользователя] NVARCHAR(50) NULL,
    [КодПользователя] INT REFERENCES [Пользователи] ([КодПользователя]) ON DELETE CASCADE NOT NULL
);
GO

CREATE TABLE [ВидыСпорта]
(
	[КодВидаСпорта] INT PRIMARY KEY IDENTITY,
    [ИмяВидаСпорта] NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE [Команды]
(
	[КодКоманды] INT PRIMARY KEY IDENTITY,
    [ИмяКоманды] NVARCHAR(100) NOT NULL,
    [КодВидаСпорта] INT REFERENCES [ВидыСпорта] ([КодВидаСпорта]) ON DELETE CASCADE NOT NULL
);
GO

CREATE TABLE [СпортивныеСобытия]
(
	[КодСпортивногоСобытия] INT PRIMARY KEY IDENTITY,
    [ИмяСпортивногоСобытия] NVARCHAR(100) NOT NULL,
    [ДатаСпортивногоСобытия] DATE NOT NULL,
    [МестоСпортивногоСобытия] NVARCHAR(50) NOT NULL,
    [РезультатСпортивногоСобытия] NVARCHAR(50) NULL,
    [КодВидаСпорта] INT REFERENCES [ВидыСпорта] ([КодВидаСпорта]) ON DELETE CASCADE NOT NULL
);
GO

CREATE TABLE [КомандыВСпортивномСобытии]
(
	[КодКомандыВСпортивномСобытии] INT PRIMARY KEY IDENTITY,
    [КодСпортивногоСобытия] INT REFERENCES [СпортивныеСобытия] ([КодСпортивногоСобытия]) ON DELETE NO ACTION NOT NULL,
    [КодКоманды] INT REFERENCES [Команды] ([КодКоманды]) ON DELETE CASCADE NOT NULL
);
GO

CREATE TABLE [Голосования]
(
	[КодГолосования] INT PRIMARY KEY IDENTITY,
    [КодСпортивногоСобытия] INT REFERENCES [СпортивныеСобытия] ([КодСпортивногоСобытия]) ON DELETE CASCADE NOT NULL,
    [КодПользователя] INT REFERENCES [Пользователи] ([КодПользователя]) ON DELETE CASCADE NOT NULL
);
GO

CREATE TABLE [ГолосаПользователей]
(
	[КодГолосаПользователя] INT PRIMARY KEY IDENTITY,
    [ВыбранныйРезультатСобытия] NVARCHAR(50) NOT NULL,
    [КодГолосования] INT REFERENCES [Голосования] ([КодГолосования]) ON DELETE CASCADE NOT NULL,
    [КодПользователя] INT REFERENCES [Пользователи] ([КодПользователя]) ON DELETE NO ACTION NOT NULL
);
GO

CREATE TABLE [НовостныеЗаписи]
(
	[КодНовостнойЗаписи] INT PRIMARY KEY IDENTITY,
    [ИмяНовостнойЗаписи] NVARCHAR(100) NOT NULL,
    [ТекстНовостнойЗаписи] NVARCHAR(750) NOT NULL,
    [КодГолосования] INT REFERENCES [Голосования] ([КодГолосования]) ON DELETE NO ACTION NULL,
    [КодПользователя] INT REFERENCES [Пользователи] ([КодПользователя]) ON DELETE NO ACTION NULL
);
GO