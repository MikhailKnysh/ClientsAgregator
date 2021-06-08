CREATE PROCEDURE [ClientsAgregatorDB].[GetSubgroupsInfoByGroupId]
@GroupID INT
AS
SELECT  [ClientsAgregatorDB].[Subgroups].[Id],[ClientsAgregatorDB].[Subgroups].[Title]
FROM [ClientsAgregatorDB].[Subgroups]
INNER JOIN [ClientsAgregatorDB].[Subgroup_Group] 
ON [ClientsAgregatorDB].[Subgroup_Group].[SubgroupId] = [ClientsAgregatorDB].[Subgroups].[Id]
WHERE [ClientsAgregatorDB].[Subgroup_Group].[GroupId] = @GroupID
