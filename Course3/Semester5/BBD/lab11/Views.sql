USE JustInMind;

GO
CREATE VIEW AllTaskInfo
AS
SELECT Id, Name, Description
FROM Tasks

GO
CREATE VIEW TaskBugInfo
AS
SELECT Id, Name, Description
FROM Tasks
WHERE CategoryId = 1;

GO
CREATE VIEW NewTaskInfo
AS
SELECT Id, Name, Description
FROM Tasks
WHERE StateId = 1;

GO
CREATE VIEW ActiveCriticalTaskInfo
AS
SELECT Id, Name, Description
FROM Tasks
WHERE StateId = 2 AND UrgencyId = 5;

GO
CREATE VIEW FullAllTaskInfo
AS
SELECT t.Id as TaskId, t.Name, Description,
	   u.Name as Urgency, s.Name as State, c.Name as Category
FROM Tasks t
LEFT JOIN Urgencies u ON t.UrgencyId = u.Id
LEFt JOIN States s ON t.StateId = s.Id
LEFT JOIN Categories c ON t.CategoryId = c.Id;

GO
CREATE VIEW TaskWithFixDescriptionInfo
AS
SELECT Id, Name, Description
FROM Tasks
WHERE Description LIKE 'Fix%';

GO
CREATE VIEW TaskWithUserRoleInfo
AS
SELECT t.Name, Description, r.Name as UserRole
FROM Tasks t
LEFT JOIN Users u ON t.UserId = u.Id
LEFT JOIN Roles r ON u.RoleId = r.Id
WHERE CategoryId = 1;

GO
CREATE VIEW UserDevelopersInfo
AS
SELECT Id, Name
FROM Users
WHERE RoleId = 2;

GO
CREATE VIEW UserWithFeedbackInfo
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

GO
CREATE VIEW AttachementsWithHttpsReferenceInfo
AS
SELECT Id, Reference
FROM Attachements
WHERE Reference LIKE 'https://%';

GO
CREATE VIEW UserNotManagersInfo
AS
SELECT u.Id, u.Name, r.Name as Role
FROM Users u
LEFT JOIN Roles r ON u.RoleId = r.Id
WHERE RoleId != 3;

GO
CREATE VIEW UsersIdInfo
AS
SELECT Id
FROM Users;

GO
CREATE VIEW HistoriesMadeByTestersInfo
AS
SELECT h.Id, h.Action, h.TaskId
FROM Users u
LEFT JOIN Histories h ON h.UserId = u.Id
WHERE u.RoleId = 4;

GO
CREATE VIEW FeedbackTextOnlyInfo
AS
SELECT Text
FROM Feedbacks;