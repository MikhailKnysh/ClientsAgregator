CREATE PROCEDURE [ClientsAgregatorDB].[AddSubgroup]
@Title VARCHAR(255)
AS
INSERT [ClientsAgregatorDB].[Subgroups]
OUTPUT inserted.Id
VALUES (@Title)