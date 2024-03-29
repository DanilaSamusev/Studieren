USE OstapenkoBBD;
GO

UPDATE ПерсональныеДанные SET ФИОПользователя = LTRIM(RTRIM(ФИОПользователя))
WHERE LEFT(ФИОПользователя, 1) = ' ' OR RIGHT(ФИОПользователя, 1) = ' ';
GO

UPDATE Пользователи SET ПарольПользователя = REVERSE(ПарольПользователя);
GO

DELETE FROM ПерсональныеДанные
WHERE LOWER(ФИОПользователя) = ФИОПользователя;
GO

UPDATE ПерсональныеДанные SET ФИОПользователя = REPLACE(ФИОПользователя, N'Назар', N'Никита')
WHERE ФИОПользователя LIKE N'%Назар%';
GO

DELETE FROM Пользователи
WHERE LEN(ПарольПользователя) < 8;
GO

UPDATE НовостныеЗаписи SET ИмяНовостнойЗаписи = SUBSTRING(ТекстНовостнойЗаписи, 1, LEN(ТекстНовостнойЗаписи)/2) + '...'
WHERE ИмяНовостнойЗаписи IS NULL AND ТекстНовостнойЗаписи IS NOT NULL;
GO

UPDATE Голосования SET СтатусГолосования = 'Done'
WHERE GETDATE() > ДатаЗавершенияГолосования;
GO

DELETE FROM Голосования
WHERE (SELECT COUNT(*) FROM ГолосаПользователей 
	   WHERE Голосования.КодГолосования = ГолосаПользователей.КодГолосования) < 5
GO

UPDATE Команды SET ИмяКоманды = LTRIM(RTRIM(ИмяКоманды))
WHERE LEFT(ИмяКоманды, 1) = ' ' OR RIGHT(ИмяКоманды, 1) = ' ';
GO

UPDATE СпортивныеСобытия
SET ИмяСпортивногоСобытия = ДатаСпортивногоСобытия + ' ' + МестоСпортивныеСобытия
WHERE ИмяСпортивногоСобытия = NULL;
GO