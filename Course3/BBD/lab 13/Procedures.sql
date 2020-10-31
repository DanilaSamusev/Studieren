USE JustInMind;

GO
CREATE PROCEDURE TaskBugInfo
AS
SELECT Id, Name, Description
FROM Tasks
WHERE CategoryId = 1;

GO
CREATE PROCEDURE FullAllTaskInfo
AS
SELECT t.Id as TaskId, t.Name, Description,
	   u.Name as Urgency, s.Name as State, c.Name as Category
FROM Tasks t
LEFT JOIN Urgencies u ON t.UrgencyId = u.Id
LEFt JOIN States s ON t.StateId = s.Id
LEFT JOIN Categories c ON t.CategoryId = c.Id;

GO
CREATE PROCEDURE TaskWithUserRoleInfo
AS
SELECT t.Name, Description, r.Name as UserRole
FROM Tasks t
LEFT JOIN Users u ON t.UserId = u.Id
LEFT JOIN Roles r ON u.RoleId = r.Id
WHERE CategoryId = 1;

GO
CREATE PROCEDURE UserDevelopersInfo
AS
SELECT Id, Name
FROM Users
WHERE RoleId = 2;

GO
CREATE PROCEDURE AttachementsWithHttpsReferenceInfo
AS
SELECT Id, Reference
FROM Attachements
WHERE Reference LIKE 'https://%';

GO
CREATE PROCEDURE UsersIdInfo
AS
SELECT Id
FROM Users;

GO
CREATE PROCEDURE HistoriesMadeByTestersInfo
AS
SELECT h.Id, h.Action, h.TaskId
FROM Users u
LEFT JOIN Histories h ON h.UserId = u.Id
WHERE u.RoleId = 4;

GO
CREATE PROCEDURE FeedbackTextOnlyInfo
AS
SELECT Text
FROM Feedbacks;

GO
CREATE PROCEDURE UpdateFeedbacks
AS
UPDATE Feedbacks SET Rate = 5
WHERE Rate = 4;

GO
CREATE PROCEDURE UpdateUsers
AS
UPDATE Users SET Password = '1'
WHERE Password = '';

GO
CREATE PROCEDURE DeleteTasks
AS
DELETE FROM Tasks
WHERE StateId = 5;

GO
CREATE PROCEDURE DeleteUsersTesters
AS
DELETE FROM Users
WHERE RoleId = 3;

GO
CREATE PROCEDURE DeleteUsers
AS
DELETE FROM Users
WHERE (SELECT Name AS Role 
	   FROM Roles r WHERE r.Id = Id) LIKE 'A%';

GO
CREATE PROCEDURE UserWithFeedbackInfo
AS
SELECT Name, f.Text
FROM Users u
RIGHT JOIN Feedbacks f ON u.Id = f.UserId;

GO
CREATE VIEW FeedbackWithRateBetween3And6Info
AS
SELECT Text, Rate, UserId
FROM Feedbacks
WHERE Rate BETWEEN 3 AND 6;