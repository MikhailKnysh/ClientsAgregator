CREATE TABLE [dbo].[Product_Subgroup] (
    [ProductId]  INT NOT NULL,
    [SubgroupId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC, [SubgroupId] ASC),
    CONSTRAINT [Product_Subgroup_fk0] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ID]),
    CONSTRAINT [Product_Subgroup_fk1] FOREIGN KEY ([SubgroupId]) REFERENCES [dbo].[Subgroups] ([ID])
);

