CREATE PROCEDURE [ClientsAgregatorDB].[AddSubgroupGroup]
@SubgroupId INT,
@GroupId INT
AS
INSERT [ClientsAgregatorDB].[Subgroup_Group]
VALUES (@SubgroupId, @GroupId)