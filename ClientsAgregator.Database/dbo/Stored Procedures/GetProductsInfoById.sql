CREATE PROCEDURE [ClientsAgregatorDB].[GetProductsInfoById]
@Id INT
AS
SELECT 
[ClientsAgregatorDB].[Products].[Id],
[ClientsAgregatorDB].[Products].[Articul], [ClientsAgregatorDB].[Products].[Title],
[ClientsAgregatorDB].[Products].[Price], [ClientsAgregatorDB].[Products].[Quantity],
[ClientsAgregatorDB].[MeasureUnits].[Title] AS [MeasureUnit], 
[ClientsAgregatorDB].[Subgroups].[Title] AS [Subgroup],
[ClientsAgregatorDB].[Groups].[Title] AS[Group]
FROM [ClientsAgregatorDB].[Products]
LEFT JOIN [ClientsAgregatorDB].[MeasureUnits] 
ON [ClientsAgregatorDB].[Products].[MeasureId] = [ClientsAgregatorDB].[MeasureUnits].[Id]
LEFT JOIN [ClientsAgregatorDB].[Product_Subgroup]
ON [ClientsAgregatorDB].[Product_Subgroup].[ProductId] = [ClientsAgregatorDB].[Products].[Id]
LEFT JOIN [ClientsAgregatorDB].[Subgroups]
ON [ClientsAgregatorDB].[Product_Subgroup].[SubgroupId] = [ClientsAgregatorDB].[Subgroups].[Id]
LEFT JOIN [ClientsAgregatorDB].[Subgroup_Group]
ON [ClientsAgregatorDB].[Subgroups].[Id] = [ClientsAgregatorDB].[Subgroup_Group].[SubgroupId]
LEFT JOIN [ClientsAgregatorDB].[Groups]
ON [ClientsAgregatorDB].[Groups].[Id] = [ClientsAgregatorDB].[Subgroup_Group].[GroupId]
WHERE [ClientsAgregatorDB].[Products].[Id] = @Id