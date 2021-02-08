USE JustInMind;

CREATE TABLE UsersCopy(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[RoleId] [int] NOT NULL,
	[DeleteDate] [DateTime] NULL)

ALTER TABLE UsersCopy  WITH CHECK
	ADD CONSTRAINT [FK_Users_Roles] 
	FOREIGN KEY([RoleId])
	REFERENCES [dbo].[Roles] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]



CREATE TABLE TasksCopy(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NULL,
	[UrgencyId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[StateId] [int] NOT NULL,
	[DeleteDate] [DateTime] NULL)

ALTER TABLE TasksCopy WITH CHECK ADD CONSTRAINT [FK_Tasks_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE TasksCopy CHECK CONSTRAINT [FK_Tasks_Categories]
GO

ALTER TABLE TasksCopy  WITH CHECK ADD  CONSTRAINT [FK_Tasks_States] FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO



CREATE TABLE CommentsCopyWithDeleteDate(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [varchar](250) NOT NULL,
	[TaskId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[DeleteDate] [DateTime] NULL)

ALTER TABLE CommentsCopyWithDeleteDate  WITH CHECK ADD  CONSTRAINT [FK_Comments_Tasks] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Tasks]
GO

ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users]