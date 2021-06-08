CREATE PROCEDURE AddSubgroupGroup
@SubgroupId INT,
@GroupId INT
AS
INSERT [dbo].[Subgroup_Group]
VALUES (@SubgroupId, @GroupId)