CREATE PROCEDURE [ClientsAgregatorDB].[GetProductSubgroup]
AS
SELECT [ClientsAgregatorDB].[Products].[Id] AS ProductID, [ClientsAgregatorDB].[Products].[Title] AS ProductTitle ,
[ClientsAgregatorDB].[Subgroups].[Id] AS SubgroupId,[ClientsAgregatorDB].[Subgroups].[Title] AS SubgroupTitle
FROM [ClientsAgregatorDB].[Products]
JOIN [ClientsAgregatorDB].[Product_Subgroup] ON [ClientsAgregatorDB].[Products].[Id] = [ClientsAgregatorDB].[Product_Subgroup].[ProductId]
JOIN [ClientsAgregatorDB].[Subgroups] On [ClientsAgregatorDB].[Product_Subgroup].[SubgroupId] = [ClientsAgregatorDB].[Subgroups].[Id] 