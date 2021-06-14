CREATE PROCEDURE [ClientsAgregatorDB].[AddBulkStatus]
@Title VARCHAR(255)
AS
INSERT [ClientsAgregatorDB].[BulkStatus] VALUES
(@Title) 