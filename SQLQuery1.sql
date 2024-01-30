Create DATABASE Assignment2
use Assignment2
Create table Customers(
CustomerID int primary key,
Passwords varchar,
ContactName nvarchar,
Address nvarchar,
Phone varchar
)
Create table Catelogies(
CateloryID int primary key,
CatelogyName nvarchar,
Descriptions nvarchar
)
Create table Suppliers(
SupplierID int primary key,
CompanyName nvarchar,
Address nvarchar,
Phone nvarchar
)
Create table Account(
AccountID int primary key,
UserName varchar,
Passwords varchar,
FullName varchar,
Type nvarchar
)
Create table Orders(
OrderID int primary key,
CustomerID int foreign key references Customers(CustomerID),
OrderDate date,
RequiredDate date,
ShippedDate date,
Freight nvarchar,
ShipAddress nvarchar
)
Create table Products(
ProductID int primary key,
ProductName nvarchar,
SupplierID int foreign key references Suppliers(SupplierID),
CateloryID int foreign key references Catelogies(CateloryID),
QuantityPerUnit int,
UnitPrice float,
ProductImage binary
)
Create table OrderDetails(
OrderID int foreign key references Orders(OrderID),
ProductID int foreign key references Products(ProductID),
UnitPrice float,
Quantity int
)