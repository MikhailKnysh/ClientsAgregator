CREATE TABLE [dbo].[Orders] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [ClientId]      INT           NOT NULL,
    [StatusesId]    INT           NOT NULL,
    [SellerComment] VARCHAR (800) NULL,
    [OrderDate]     VARCHAR (255) NULL,
    [DeliveryDate]  VARCHAR (255) NULL,
    CONSTRAINT [PK_ORDERS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Orders_fk0] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id]),
    CONSTRAINT [Orders_fk1] FOREIGN KEY ([StatusesId]) REFERENCES [dbo].[Statuses] ([Id])
);

