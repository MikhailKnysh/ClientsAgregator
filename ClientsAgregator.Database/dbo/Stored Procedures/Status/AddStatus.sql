CREATE PROCEDURE [ClientsAgregatorDB].[AddStatus]
@Title varchar(255)
AS
INSERT [ClientsAgregatorDB].[Statuses]
VALUES (@Title)
