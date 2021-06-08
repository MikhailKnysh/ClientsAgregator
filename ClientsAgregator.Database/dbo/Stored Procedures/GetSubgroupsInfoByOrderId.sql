CREATE PROCEDURE [dbo].[GetSubgroupsInfoByGroupId]
@GroupID INT
AS
SELECT  [dbo].[Subgroups].[Id],[dbo].[Subgroups].[Title]
FROM [dbo].[Subgroups]
INNER JOIN [dbo].[Subgroup_Group] 
ON [dbo].[Subgroup_Group].[SubgroupId] = [dbo].[Subgroups].[Id]
WHERE [dbo].[Subgroup_Group].[GroupId] = @GroupID
