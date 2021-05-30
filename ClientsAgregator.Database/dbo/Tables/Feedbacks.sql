CREATE TABLE [dbo].[Feedbacks] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [ClientId]    INT           NOT NULL,
    [ProductId]   INT           NOT NULL,
    [OrderId]   INT           NOT NULL,
    [Description] VARCHAR (800) NULL,
    [Date]        VARCHAR (255) NULL,
    [Rate]        INT           NULL,
    CONSTRAINT [PK_FEEDBACKS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Feedbacks_fk0] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id]),
    CONSTRAINT [Feedbacks_fk1] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
);

