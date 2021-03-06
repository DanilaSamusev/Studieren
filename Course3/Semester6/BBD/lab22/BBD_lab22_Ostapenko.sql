USE [SportVoting]
GO

CREATE PROCEDURE Users
AS
SELECT	U.Id,
		U.Login,
		U.Password,
		R.Name AS RoleName
FROM	Users AS U
		LEFT JOIN Roles AS R ON R.Id = U.RoleId
GO

CREATE PROCEDURE SportEventById
	@id INT
AS
SELECT	SE.Id,
		SE.Name,
		SE.Place,
		SE.Date,
		S.Name,
		SE.EventResult
FROM	SportsEvents AS SE
		LEFT JOIN Sports AS S ON S.Id = SE.SportId
WHERE	SE.Id = @id
GO