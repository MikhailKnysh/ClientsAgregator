﻿CREATE PROCEDURE [ClientsAgregatorDB].[GetClients]
AS
SELECT C.Id, C.[LastName], C.FirstName, 
C.MiddleName, C.Phone, C.Email, C.Male, [ClientsAgregatorDB].[BulkStatus].[Title] AS BulkStatusId, C.СommentAboutСlient
FROM [ClientsAgregatorDB].[Clients] AS C
JOIN [ClientsAgregatorDB].[BulkStatus] ON [ClientsAgregatorDB].[BulkStatus].[Id] = [C].[BulkStatusId]