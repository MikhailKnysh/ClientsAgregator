CREATE TABLE [ClientsAgregatorDB].[Subgroup_Group] (
    [SubgroupId] INT NOT NULL,
    [GroupId]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([SubgroupId] ASC, [GroupId] ASC),
    CONSTRAINT [Subgroup_Group_fk0] FOREIGN KEY ([SubgroupId]) REFERENCES [ClientsAgregatorDB].[Subgroups] ([Id]),
    CONSTRAINT [Subgroup_Group_fk1] FOREIGN KEY ([GroupId]) REFERENCES [ClientsAgregatorDB].[Groups] ([Id])
);

