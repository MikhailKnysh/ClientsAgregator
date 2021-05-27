CREATE TABLE [dbo].[Product_Order] (
    [Id]        INT  IDENTITY (1, 1) NOT NULL,
    [OrderId]   INT NOT NULL,
    [ProductId] INT NOT NULL,
    [Quantity]  INT NOT NULL,
    CONSTRAINT [PK_PRODUCT_ORDER] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Product_Order_fk0] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]),
    CONSTRAINT [Product_Order_fk1] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
);

