CREATE TABLE [dbo].[Subgroup_Group] (
    [SubgroupId] INT NOT NULL,
    [GroupId]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([SubgroupId] ASC, [GroupId] ASC),
    CONSTRAINT [Subgroup_Group_fk0] FOREIGN KEY ([SubgroupId]) REFERENCES [dbo].[Subgroups] ([ID]),
    CONSTRAINT [Subgroup_Group_fk1] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([ID])
);

