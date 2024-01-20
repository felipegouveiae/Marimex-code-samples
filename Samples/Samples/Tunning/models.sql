

CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1),
    CreatedAt DATETIME NOT NULL,
    ClientId INT NOT NULL,
    CONSTRAINT PK_Order primary key (OrderId)
)

CREATE TABLE Items (
    Id INT IDENTITY(1,1),
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    CONSTRAINT PK_Item primary key (OrderId DESC, Id DESC)
    CONSTRAINT FK_Orders FOREIGN KEY Orders(Id)
)







