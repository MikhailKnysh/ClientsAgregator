CREATE TABLE [ClientsAgregatorDB].[Clients] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [LastName]     VARCHAR (255) NOT NULL,
    [FirstName]    VARCHAR (255) NOT NULL,
    [MiddleName]   VARCHAR (255) NOT NULL,
    [Phone]        VARCHAR (60)  NULL,
    [Email]        NVARCHAR(50) NULL,
    [BulkStatusId] INT           NOT NULL,
    [Male]         VARCHAR(50)                   NOT NULL,
    [СommentAboutСlient] VARCHAR(800)   NULL,

    CONSTRAINT [PK_CLIENTS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Clients_fk0] FOREIGN KEY ([BulkStatusId]) REFERENCES [ClientsAgregatorDB].[BulkStatus] ([Id])
);

