CREATE PROCEDURE GetClients
AS
SELECT C.Id, C.[LastName], C.FirstName, 
C.MiddleName, C.Phone,C.Email,C.Male, [dbo].BulkStatus.Title
FROM [dbo].[Clients] AS C
JOIN [dbo].BulkStatus ON [dbo].[BulkStatus].Id = C.[BulkStatusId]