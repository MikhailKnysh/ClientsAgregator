CREATE PROCEDURE [ClientsAgregatorDB].[GetOrderInfo]
AS
SELECT [ClientsAgregatorDB].[Products].[Articul], [ClientsAgregatorDB].[Products].[Title],
[ClientsAgregatorDB].[Products].[Price], [ClientsAgregatorDB].[Product_Order].[Quantity],
[ClientsAgregatorDB].[MeasureUnits].[Title], [ClientsAgregatorDB].[Subgroups].[Title],
[ClientsAgregatorDB].[Groups].[Title]
FROM [ClientsAgregatorDB].[Products]
INNER JOIN [ClientsAgregatorDB].[Product_Order]
ON [ClientsAgregatorDB].[Products].[Id] = [ClientsAgregatorDB].[Product_Order].[ProductId]
INNER JOIN [ClientsAgregatorDB].[MeasureUnits]
ON [ClientsAgregatorDB].[Products].[MeasureId] = [ClientsAgregatorDB].[MeasureUnits].[Id]
INNER JOIN [ClientsAgregatorDB].[Product_Subgroup]
ON [ClientsAgregatorDB].[Product_Subgroup].[ProductId] = [ClientsAgregatorDB].[Products].[Id]
INNER JOIN [ClientsAgregatorDB].[Subgroups]
ON [ClientsAgregatorDB].[Product_Subgroup].[SubgroupId] = [ClientsAgregatorDB].[Subgroups].[Id]
INNER JOIN [ClientsAgregatorDB].[Subgroup_Group]
ON [ClientsAgregatorDB].[Subgroups].[Id] = [ClientsAgregatorDB].[Subgroup_Group].[SubgroupId]
INNER JOIN [ClientsAgregatorDB].[Groups]
ON [ClientsAgregatorDB].[Groups].[Id] = [ClientsAgregatorDB].[Subgroup_Group].[GroupId]