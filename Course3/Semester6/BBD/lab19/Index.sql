use JustInMind;

GO
CREATE 
INDEX TasksIndex ON Tasks (Description)

GO
CREATE NONCLUSTERED
INDEX UserIndex ON Users (Name)

GO
CREATE UNIQUE
INDEX RolesIndex ON Roles (Name)

GO
CREATE UNIQUE NONCLUSTERED
INDEX UrgencyIndex ON Urgencies (Name)

GO
CREATE
INDEX AttachementsIndex ON Attachements (Reference)

GO
SELECT Name FROM Users