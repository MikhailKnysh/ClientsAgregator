CREATE TABLE [ClientsAgregatorDB].[Product_Subgroup] (
    [ProductId]  INT NOT NULL,
    [SubgroupId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC, [SubgroupId] ASC),
    CONSTRAINT [Product_Subgroup_fk0] FOREIGN KEY ([ProductId]) REFERENCES [ClientsAgregatorDB].[Products] ([Id]),
    CONSTRAINT [Product_Subgroup_fk1] FOREIGN KEY ([SubgroupId]) REFERENCES [ClientsAgregatorDB].[Subgroups] ([Id])
);

