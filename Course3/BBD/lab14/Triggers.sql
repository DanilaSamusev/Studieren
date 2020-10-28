USE JustInMind;

GO
CREATE TRIGGER Tasks_INSERT
ON dbo.Tasks
AFTER INSERT
AS
UPDATE dbo.Tasks
SET UrgencyId = UrgencyId - 1
WHERE Id = (SELECT Id FROM inserted);

GO
CREATE TRIGGER Tasks_DELETE
ON dbo.Tasks
AFTER DELETE
AS
SELECT Name FROM deleted;

GO
CREATE TRIGGER Users_DELETE
ON dbo.Users
AFTER DELETE
AS
SELECT Name + RoleId FROM deleted;

GO
CREATE TRIGGER Users_INSERT
ON dbo.Users
AFTER INSERT
AS
UPDATE dbo.Users
SET Name = Name + (SELECT r.Name FROM dbo.Roles r WHERE  r.Id = RoleId)
WHERE Id = (SELECT Id FROM inserted);

GO
CREATE TRIGGER Histories_INSERT
ON dbo.Histories
AFTER INSERT
AS
UPDATE dbo.Histories
SET Action = Action + GETDATE()
WHERE Id = (SELECT Id FROM inserted);

GO
CREATE TRIGGER Feedbacks_INSERT
ON dbo.Feedbacks
AFTER INSERT
AS
UPDATE dbo.Feedbacks
SET Text = Text + ': ' + Rate
WHERE Id = (SELECT Id FROM inserted);

GO
CREATE TRIGGER Comments_INSERT
ON dbo.Comments
AFTER INSERT
AS
UPDATE dbo.Comments
SET Text = Text + GETDATE()
WHERE Id = (SELECT Id FROM inserted)

GO
CREATE TRIGGER Attachements_INSERT
ON dbo.Attachements
AFTER INSERT
AS
UPDATE dbo.Attachements
SET Reference = REPLACE(Reference, 'http://', 'https://')
WHERE Id = (SELECT Id FROM inserted) AND Reference LIKE 'http://%'