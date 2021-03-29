USE OstapenkoBBD;
GO

CREATE
INDEX ИндексСпортивногоСобытия ON СпортивныеСобытия (ИмяСпортивногоСобытия)
GO

CREATE NONCLUSTERED
INDEX ИндексПользователя ON Пользователи (ИмяПользователя)
GO

CREATE UNIQUE
INDEX ИндексРоли ON Роли (ИмяРоли)
GO

CREATE UNIQUE NONCLUSTERED
INDEX ИндексГолосования ON Голосования (ИмяГолосования)
GO

CREATE
INDEX ИндексНовостнойЗаписи ON НовостныеЗаписи (ТекстНовостнойЗаписи)
GO