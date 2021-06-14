CREATE PROCEDURE [ClientsAgregatorDB].[GetClientById]
@Id INT
AS
SELECT C.Id, C.LastName, C.FirstName, 
C.MiddleName, C.Phone, C.Email, C.Male, [ClientsAgregatorDB].BulkStatus.Title AS BulkStatusTitle, C.СommentAboutСlient
FROM [ClientsAgregatorDB].[Clients] AS C
JOIN [ClientsAgregatorDB].[BulkStatus] ON [ClientsAgregatorDB].[BulkStatus].Id = C.[BulkStatusId]
WHERE C.Id = @Id