CREATE PROCEDURE [dbo].[GetProductsInfo]
AS
SELECT 
[dbo].[Products].[Articul], [dbo].[Products].[Title],
[dbo].[Products].[Price], [dbo].[Products].[Quantity],
[dbo].[MeasureUnits].[Title] AS [MeasureUnit], 
[dbo].[Subgroups].[Title] AS [Subgroup],
[dbo].[Groups].[Title] AS[Group]
FROM [dbo].[Products]
LEFT JOIN [dbo].[MeasureUnits] 
ON [dbo].[Products].[MeasureId] = [dbo].[MeasureUnits].[Id]
LEFT JOIN [dbo].[Product_Subgroup]
ON [dbo].[Product_Subgroup].[ProductId] = [dbo].[Products].[Id]
LEFT JOIN [dbo].[Subgroups]
ON [dbo].[Product_Subgroup].[SubgroupId] = [dbo].[Subgroups].[Id]
LEFT JOIN [dbo].[Subgroup_Group]
ON [dbo].[Subgroups].[Id] = [dbo].[Subgroup_Group].[SubgroupId]
LEFT JOIN [dbo].[Groups]
ON [dbo].[Groups].[Id] = [dbo].[Subgroup_Group].[GroupId]
