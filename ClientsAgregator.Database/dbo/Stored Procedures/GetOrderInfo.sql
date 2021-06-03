CREATE PROCEDURE [dbo].[GetOrderInfo]
AS
SELECT [dbo].[Products].[Articul], [dbo].[Products].[Title],
[dbo].[Products].[Price], [dbo].[Product_Order].[Quantity],
[dbo].[MeasureUnits].[Title], [dbo].[Subgroups].[Title],
[dbo].[Groups].[Title]
FROM [dbo].[Products]
INNER JOIN [dbo].[Product_Order]
ON [dbo].[Products].[Id] = [dbo].[Product_Order].[ProductId]
INNER JOIN [dbo].[MeasureUnits]
ON [dbo].[Products].[MeasureId] = [dbo].[MeasureUnits].[Id]
INNER JOIN [dbo].[Product_Subgroup]
ON [dbo].[Product_Subgroup].[ProductId] = [dbo].[Products].[Id]
INNER JOIN [dbo].[Subgroups]
ON [dbo].[Product_Subgroup].[SubgroupId] = [dbo].[Subgroups].[Id]
INNER JOIN [dbo].[Subgroup_Group]
ON [dbo].[Subgroups].[Id] = [dbo].[Subgroup_Group].[SubgroupId]
INNER JOIN [dbo].[Groups]
ON [dbo].[Groups].[Id] = [dbo].[Subgroup_Group].[GroupId]