CREATE TABLE [ClientsAgregatorDB].[Statuses] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Title] VARCHAR (255) NULL,
    CONSTRAINT [PK_STATUSES] PRIMARY KEY CLUSTERED ([Id] ASC)
);

