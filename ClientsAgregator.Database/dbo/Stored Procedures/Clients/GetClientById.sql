CREATE PROCEDURE GetClientById
@Id INT
AS
SELECT C.[LastName], C.FirstName, 
C.MiddleName, C.Phone,C.Email,C.Male, [dbo].BulkStatus.Title
FROM [dbo].[Clients] AS C
JOIN [dbo].BulkStatus ON [dbo].[BulkStatus].Id = C.[BulkStatusId]
WHERE C.Id = @Id