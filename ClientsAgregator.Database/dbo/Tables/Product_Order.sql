CREATE TABLE [dbo].[Product_Order] (
    [OrderId]   INT NOT NULL,
    [ProductId] INT NOT NULL,
    [Quantity]  INT NULL,
    PRIMARY KEY CLUSTERED ([OrderId] ASC, [ProductId] ASC),
    CONSTRAINT [Product_Order_fk0] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]),
    CONSTRAINT [Product_Order_fk1] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ID])
);

