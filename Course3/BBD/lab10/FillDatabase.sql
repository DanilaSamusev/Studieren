USE JustInMind;

DELETE FROM dbo.Attachements;
DBCC CHECKIDENT (Attachements, RESEED, 0);
DELETE FROM dbo.Comments;
DBCC CHECKIDENT (Comments, RESEED, 0);
DELETE FROM dbo.Feedbacks;
DBCC CHECKIDENT (Feedbacks, RESEED, 0);
DELETE FROM dbo.Histories;
DBCC CHECKIDENT (Histories, RESEED, 0);
DELETE FROM dbo.Tasks;
DBCC CHECKIDENT (Tasks, RESEED, 0);
DELETE FROM dbo.States;
DBCC CHECKIDENT (States, RESEED, 0);
DELETE FROM dbo.Users;
DBCC CHECKIDENT (Users, RESEED, 0);
DELETE FROM dbo.Categories;
DBCC CHECKIDENT (Categories, RESEED, 0);
DELETE FROM dbo.Roles;
DBCC CHECKIDENT (Roles, RESEED, 0);
DELETE FROM dbo.Urgencies;
DBCC CHECKIDENT (Urgencies, RESEED, 0);



INSERT INTO dbo.Roles (Name)
VALUES ('Guest'),
	   ('Developer'),
	   ('Manager'),
	   ('Tester'),
       ('DevOps');

INSERT INTO dbo.States (Name)
VALUES ('New'),
	   ('Active'),
	   ('Done'),
	   ('Investigation'),
       ('In test');

INSERT INTO dbo.Urgencies (Name)
VALUES ('Low'),
	   ('MediumLow'),
	   ('Medium'),
	   ('High'),
       ('Critical');

INSERT INTO dbo.Categories (Name)
VALUES ('Bug'),
	   ('Improvement'),
	   ('Feature'),
	   ('Error'),
       ('Other');

INSERT INTO dbo.Users (Name, Password, RoleId)
VALUES ('Victor', '1', 1),
	   ('Danila', '1', 1),
	   ('Petia', '1', 1),
	   ('Dan', '1', 1),
	   ('Jon', '1', 2),
	   ('Mike', '1', 2),
	   ('Hill', '1', 2),
	   ('Irving', '1', 2),
	   ('Aleksey', '1', 2),
	   ('Ais', '1', 3),
	   ('Harry', '1', 3),
	   ('Mor', '1', 3),
	   ('Tom', '1', 3),
	   ('Kevin', '1', 4),
	   ('Loch', '1', 4),
	   ('Jim', '1', 4),
	   ('Podric', '1', 5),
	   ('Terion', '1', 5),
	   ('Tyvin', '1', 5),
	   ('Hound', '1', 5),
	   ('Aria', '1', 5),
	   ('Sansa', '1', 5);

INSERT INTO dbo.Tasks (Name, Description, UrgencyId, CategoryId, UserId, StateId)
VALUES ('Add flag', '', 1, 1, 1, 2),
	   ('Add flag', '', 1, 1, 1, 2),
	   ('Add flag', '', 1, 1, 1, 2),
	   ('Add flag', '', 1, 1, 1, 2),
	   ('Add flag', '', 1, 1, 1, 2),
	   ('Fix bug', '', 1, 1, 1, 1),
	   ('Fix bug', '', 1, 1, 1, 1),
	   ('Fix bug', '', 1, 1, 1, 1),
	   ('Fix bug', '', 1, 1, 1, 1),
	   ('Fix bug', '', 1, 1, 1, 1),
	   ('Investigation', '', 1, 1, 1, 5),
	   ('Investigation', '', 1, 1, 1, 5),
	   ('Investigation', '', 1, 1, 1, 5),
	   ('Investigation', '', 1, 1, 1, 5),
	   ('Investigation', '', 1, 1, 1, 5),
	   ('Test', '', 1, 1, 1, 5),
	   ('Test', '', 1, 1, 1, 5),
	   ('Test', '', 1, 1, 1, 5),
	   ('Test', '', 1, 1, 1, 5),
	   ('Fix error', '', 1, 1, 1, 4),
	   ('Fix error', '', 1, 1, 1, 4),
	   ('Fix error', '', 1, 1, 1, 4),
	   ('Fix error', '', 1, 1, 1, 4),
	   ('Fix error', '', 1, 1, 1, 3),
	   ('Fix error', '', 1, 1, 1, 3),
	   ('Fix error', '', 1, 1, 1, 3),
	   ('Fix error', '', 1, 1, 1, 3),
	   ('Fix error', '', 1, 1, 1, 3),
	   ('Fix error', '', 1, 1, 1, 3),
	   ('Fix error', '', 1, 1, 1, 3),
	   ('Fix error', '', 1, 1, 1, 3)

INSERT INTO dbo.Histories (Action, TaskId, UserId)
VALUES ('Added task', 1, 11),
       ('Added task', 2, 11),
	   ('Added task', 3, 11),
	   ('Added task', 4, 11),
	   ('Added task', 5, 11),
	   ('Added task', 6, 11),
	   ('Added task', 7, 11),
	   ('Added task', 8, 11),
	   ('Added task', 9, 11),
	   ('Added task', 10, 11),
	   ('Added task', 11, 11),
	   ('Added task', 12, 11),
	   ('Added task', 13, 11),
	   ('Added task', 14, 11),
	   ('Added task', 15, 11),
	   ('Added task', 16, 11),
	   ('Added task', 17, 11),
	   ('Added task', 18, 11),
	   ('Added task', 19, 11),
	   ('Added task', 20, 11),
	   ('Added task', 21, 11),
	   ('Added task', 22, 11),
	   ('Added task', 23, 11),
	   ('Finished task', 24, 5),
	   ('Finished task', 25, 5),
	   ('Finished task', 26, 5),
	   ('Finished task', 27, 5),
	   ('Finished task', 28, 5),
	   ('Finished task', 29, 5),
	   ('Finished task', 30, 5),
	   ('Finished task', 31, 5);

INSERT INTO dbo.Feedbacks (Rate, Text, TaskId, UserId)
VALUES (NULL, 'Well done', 24, 11),
       (NULL, 'Well done', 25, 11),
	   (NULL, 'Well done', 26, 11),
	   (5, 'Well done', 27, 11),
	   (5, 'Well done', 28, 11),
	   (4, 'Well done', 29, 11),
	   (4, 'Well done', 30, 11),
	   (4, 'Well done', 31, 11);

INSERT INTO dbo.Comments (Text, TaskId, UserId)
VALUES ('Please, hold off this changes', 1,  11),
       ('Please, hold off this changes', 2,  11),
	   ('Please, hold off this changes', 3,  11),
	   ('Please, hold off this changes', 4,  11),
	   ('Please, hold off this changes', 5,  11),
	   ('Please, hold off this changes', 6,  11),
	   ('Please, hold off this changes', 7,  11),
	   ('Please, hold off this changes', 8,  11),
	   ('Please, hold off this changes', 9,  11),
	   ('Please, hold off this changes', 10, 11),
	   ('Please, hold off this changes', 11, 11),
	   ('Please, hold off this changes', 12, 11),
	   ('Please, hold off this changes', 13, 11),
	   ('Please, hold off this changes', 14, 11),
	   ('Please, hold off this changes', 15, 11),
	   ('Please, hold off this changes', 16, 11),
	   ('Please, hold off this changes', 17, 11),
	   ('Please, hold off this changes', 18, 11),
	   ('Please, hold off this changes', 19, 11),
	   ('Please, hold off this changes', 20, 11),
	   ('Please, hold off this changes', 21, 11),
	   ('Please, hold off this changes', 22, 11),
	   ('Please, hold off this changes', 23, 11);

INSERT INTO dbo.Attachements (Reference, TaskId)
VALUES ('https://html5book.ru/sozdanie-html-form/', 1),
       ('https://html5book.ru/sozdanie-html-form/', 2),
	   ('https://html5book.ru/sozdanie-html-form/', 3),
	   ('https://html5book.ru/sozdanie-html-form/', 4),
	   ('https://html5book.ru/sozdanie-html-form/', 5),
	   ('https://html5book.ru/sozdanie-html-form/', 6),
	   ('https://html5book.ru/sozdanie-html-form/', 7),
	   ('https://html5book.ru/sozdanie-html-form/', 8),
	   ('https://html5book.ru/sozdanie-html-form/', 9),
	   ('https://html5book.ru/sozdanie-html-form/', 10);