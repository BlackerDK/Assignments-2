INSERT INTO Catelories( CatelogyName, Descriptions)
VALUES
    ('Margherita', 'Classic pizza with tomato, mozzarella, and basil'),
    ('Pepperoni', 'Pizza topped with pepperoni slices'),
    ('Vegetarian', 'Pizza with assorted vegetables and cheese'),
    ('Hawaiian', 'Pizza with ham and pineapple topping')
    ;
INSERT INTO Products (ProductName, QuantityPerUnit, UnitPrice, ProductImage ,CateloryID,SupplierID)
VALUES
    ('Pizza Margherita', 1, 9.99, 'Piza4.jpg',1 ,1), -- Assuming Images are stored as NULL for simplicity
    ('Pepperoni Pizza', 1, 11.99, 'Piza3.jpg',2,1),
    ('Vegetarian Pizza', 1, 10.99, 'Piza2.jpg',3,2),
    ('Hawaiian Pizza', 1, 12.99, 'Piza1.jpg',4,2)
    ;
INSERT INTO Accounts(UserName, Password, FullName, Type)
VALUES
    ('member', '1234', 'Member Full Name', 0),
    ('staff', '1234', 'Staff Full Name', 1);

	INSERT INTO Suppliers (CompanyName, Address, Phone)
VALUES
    ('Supplier A', '789 Elm St', '555-9876'),
    ('Supplier B', '321 Pine St', '555-5432');