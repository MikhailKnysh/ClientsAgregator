CREATE TABLE [ClientsAgregatorDB].[Products] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Articul]   VARCHAR (255) NULL,
    [Title]     VARCHAR (255) NOT NULL,
    [Price]     FLOAT (53)    NOT NULL,
    [Quantity]  INT           NOT NULL,
    [MeasureId] INT           NOT NULL,
    [IsDeleted] VARCHAR (255) NULL
    CONSTRAINT [PK_PRODUCTS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Products_fk0] FOREIGN KEY ([MeasureId]) REFERENCES [ClientsAgregatorDB].[MeasureUnits] ([Id])
);

