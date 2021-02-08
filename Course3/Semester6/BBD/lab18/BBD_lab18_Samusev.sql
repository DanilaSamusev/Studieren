USE JustInMind;

GO
UPDATE Tasks SET Name = SUBSTRING(Description, 1, LEN(Description)/2) + '...'
WHERE Name IS NULL AND Description IS NOT NULL;

GO
UPDATE Users SET Name = REPLACE(Name, Name, 'Dan')
WHERE Name = 'Daniel';

GO
UPDATE Feedbacks SET Text = SUBSTRING(Text,'-', Rate)
WHERE LEN(Text) < 50;

GO
UPDATE Attachements SET Reference = REPLACE(Reference, 'http', 'https');

GO
UPDATE Feedbacks SET Rate = Rate + 1
WHERE Rate < (SELECT AVG(Rate));

INSERT INTO dbo.Feedbacks (Rate, Text, TaskId, UserId)
VALUES (RIGHT('Well done - 5', 1), LEFT('Well done - 5', 9), 24, 11);

INSERT INTO dbo.Tasks (Name, Description, UrgencyId, CategoryId, UserId, StateId)
VALUES ('Add flag', '', 1, 1, 1, 2);

DELETE FROM Users
WHERE LOWER(Name) = Name;

DELETE FROM Feedbacks
WHERE Rate < (SELECT MIN(Rate) * 2);

DELETE FROM Users
WHERE (SELECT Name AS Role 
	   FROM Roles r WHERE r.Id = Id) LIKE 'A%' OR Name = REVERSE(Name);

UPDATE dbo.Histories
SET Action = Action + GETDATE();

UPDATE dbo.Comments
SET Text = Text + GETDATE();