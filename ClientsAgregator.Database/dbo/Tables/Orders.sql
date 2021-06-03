CREATE TABLE [dbo].[Orders] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [ClientId]      INT           NOT NULL,
    [StatusesId]    INT           NOT NULL,
    [OrderReview] VARCHAR (MAX) NULL,
    [OrderDate]     VARCHAR (255) NULL,
    [TotalPrice]    FLOAT         NOT NULL,  
    CONSTRAINT [PK_ORDERS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Orders_fk0] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id]),
    CONSTRAINT [Orders_fk1] FOREIGN KEY ([StatusesId]) REFERENCES [dbo].[Statuses] ([Id])
);

