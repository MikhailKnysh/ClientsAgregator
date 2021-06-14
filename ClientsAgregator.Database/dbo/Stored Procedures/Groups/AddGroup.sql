CREATE PROCEDURE [ClientsAgregatorDB].[AddGroup]
@Title VARCHAR(255)
AS
INSERT [ClientsAgregatorDB].[Groups] VALUES
(@Title)