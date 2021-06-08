CREATE TABLE [ClientsAgregatorDB].[Groups] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Title] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_GROUPS] PRIMARY KEY CLUSTERED ([Id] ASC)
);

