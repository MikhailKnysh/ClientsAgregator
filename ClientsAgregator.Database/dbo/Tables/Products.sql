CREATE TABLE [dbo].[Products] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [Articul]   VARCHAR (255) NULL,
    [Title]     VARCHAR (255) NOT NULL,
    [Price]     FLOAT (53)    NULL,
    [Quantity]  INT           NULL,
    [MeasureId] INT           NOT NULL,
    CONSTRAINT [PK_PRODUCTS] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [Products_fk0] FOREIGN KEY ([MeasureId]) REFERENCES [dbo].[MeasureUnits] ([Id])
);

