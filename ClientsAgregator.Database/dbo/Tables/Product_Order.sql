CREATE TABLE [dbo].[Product_Order] (
    [OrderID]   INT NOT NULL,
    [ProductID] INT NOT NULL,
    [Quantity]  INT NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC, [ProductID] ASC),
    CONSTRAINT [Product_Order_fk0] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([Id]),
    CONSTRAINT [Product_Order_fk1] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ID])
);

