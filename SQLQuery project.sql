create database demo_project

create table Product(
ProductID uniqueidentifier primary key default newid(),
Sellerid uniqueidentifier foreign key references UserTable(Id),
P_Name varchar(100) not null,
P_Description varchar(250) not null,
Is_Cancelable bit default(0),
Is_Returnable bit default(0),
Brand varchar(100) not null,
Is_Active bit default(0),
date_created date default getdate(),
last_updated date,
created_by varchar(100),
updated_by varchar(100),
)

create table Product_Variation(
ProductVariationID uniqueidentifier primary key default newid(),
ProductID uniqueidentifier foreign key references Product(ProductID),
Qunatity_Available int ,
Price numeric(10,2),
Variation_Metadata nvarchar(4000),
Primary_Image_Name varchar(1000),
Is_Active bit,
date_created datetime,
last_updated datetime,
created_by varchar(100),
updated_by varchar(100),
)


create table OrderTable(
OrderId uniqueidentifier primary key default newid(),
CustomerID uniqueidentifier foreign key references UserTable(ID),
Amount_Paid numeric(10,2),
AddressId uniqueidentifier foreign key references Addresses(ID),
Date_created date default getdate(),
last_updated datetime,
created_by varchar(100),
updated_by varchar(100),
)


create table OrderStatus(
OrderProductId uniqueidentifier foreign key references OrderProduct(OrderProductId),
FromStatus date default getdate(),
ToStatus date,
TRANSITION_NOTES_COMMENTS varchar(100)
)                                      



create table CART(
CustomerID  uniqueidentifier foreign key references UserTable(ID),
QUANTITY int,
IS_WISHLIST_ITEM bit default(0),
ProductVariationID uniqueidentifier foreign key references Product_Variation(ProductVariationID),
)

create table OrderProduct(
OrderProductId uniqueidentifier primary key default newid(),
OrderId uniqueidentifier foreign key references OrderTable(OrderId), 
Quantity int ,
Price numeric(10,2),
ProductVariationID uniqueidentifier foreign key references Product_Variation(ProductVariationID),
date_created date default getdate(),
last_updated date,
created_by varchar(100),
updated_by varchar(100)
)

create table UserTable(
ID uniqueidentifier primary key default newid(),
Email varchar(100) not null,
First_Name varchar(100) not null,
Last_Name varchar(100) not null,
UPassword nvarchar(max) not null,
Is_Deleted bit default(0),
Is_Active bit default(0),
date_created date default getdate(),
last_updated date,
created_by varchar(500),
updated_by varchar(500),
)

create table Seller(
Sellerid uniqueidentifier foreign key  references UserTable(ID),
GST nvarchar(15) not null,
Company_Contact numeric(10) not null,
Company_Name varchar(100) not null,
date_created date default getdate(),
last_updated date,
created_by varchar(100),
updated_by varchar(100),
SellerNote nvarchar(max)
)


create table Addresses(
ID uniqueidentifier primary key default newid(),
City varchar(100) not null,
[State] varchar(100) not null,
Country varchar(100) not null,
AddressLine1 varchar(100) not null,
AddressLine2 varchar(100) ,
Zip_Code int not null ,
[Label] varchar(100),
UserID uniqueidentifier foreign key references UserTable(ID),
date_created date default getdate(),
last_updated date,
created_by varchar(100),
updated_by varchar(100),
)


create table RoleTable(
RoleID int primary key identity(1,1),
Authority varchar(50),
date_created date default getdate(),
last_updated date,
created_by varchar(100),
updated_by varchar(100),
)


create table UserRole(
UserID uniqueidentifier foreign key references UserTable(ID),
RoleID int foreign key references RoleTable(RoleID),
date_created date default getdate(),
last_updated date,
created_by varchar(100),
updated_by varchar(100),
)


create table Customer(
UserID uniqueidentifier foreign key references UserTable(ID),
Customer_Contact numeric(10) not null primary key,
date_created date default getdate(),
last_updated date,
created_by varchar(100),
updated_by varchar(100),
)






create table Category(
CategoryID uniqueidentifier primary key default newid(),
CategoryName varchar(100) not null,
ProductID uniqueidentifier foreign key references Product(ProductID),
date_created date default getdate(),
last_updated date,
created_by varchar(100),
updated_by varchar(100),
)



create table CATEGORY_METADATA_FIELD(
CategoryMetadataFieldID uniqueidentifier primary key default newid(),
CategoryFIELDName nvarchar(4000) not null,
date_created date default getdate(),
last_updated date,
created_by varchar(100),
updated_by varchar(100)
)



create table CATEGORY_METADATA_FIELD_VALUES(
CategoryMetadataFieldID uniqueidentifier foreign key references CATEGORY_METADATA_FIELD(CategoryMetadataFieldID),
CategoryID uniqueidentifier foreign key references Category(CategoryID),
[Values] nvarchar(4000) not null,
date_created date default getdate(),
last_updated date,
created_by varchar(100),
updated_by varchar(100)
)

create table Product_Review(
Customer_User_ID uniqueidentifier foreign key references UserTable(ID),
Review varchar(1000),
Rating float,
ProductID uniqueidentifier foreign key references Product(ProductID),
date_created date default getdate(),
last_updated date,
created_by varchar(100),
updated_by varchar(100)
)