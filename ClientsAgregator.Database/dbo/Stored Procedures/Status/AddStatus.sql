CREATE PROCEDURE AddStatus
@Title varchar(255)
AS
INSERT [dbo].[Statuses]
VALUES (@Title)
