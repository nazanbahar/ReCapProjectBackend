/*
create database RentCarDb
go

CREATE TABLE Colors
(
	ColorId int primary key identity (1,1),
	ColorName nvarchar (15) not null, 
)

CREATE TABLE Brands
(
	BrandId int primary key identity (1,1),
	BrandName nvarchar (50) not null,  
)

CREATE TABLE Cars
(
	CarId int primary key identity (1,1),
	BrandId int foreign key references Brands(BrandId),
	ColorId int foreign key references Colors(ColorId),
	ModelYear int not null,
	DailyPrice decimal (30) not null,
	CarName nvarchar (30) not null,
	Description nvarchar(250) not null,
)
go

INSERT INTO Colors(ColorName)
VALUES
	('Siyah'),
	('Buz Mavisi'),
	('Beyaz'),
	('Ay Grisi'),
	('Bordo');

INSERT INTO Brands(BrandName)
VALUES
	('Toyota'),
	('BMW'),
	('Volvo'),
	('Volkswagen'),
	('Renault');

INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Carname,Description)
VALUES
	('1','1','2020','350','Toyota','Elektirikli Araç'),
	('2','2','2019','250','BMW','Dizel Araç'),
	('3','3','2018','150','Volvo','Benzinli Araç'),
	('4','4','2017','100','Volkswagen','Dizel Araç'),
	('5','5','2016','50','Renault','Otomatik Vites');

***********************************************************************************************
--LESSON-10
--Users-->Id,FirstName,LastName,Email,Password
CREATE TABLE Users
(
	UserId int primary key identity (1,1),
	FirstName nvarchar (30) not null unique,
	LastName nvarchar (30) not null unique,
	Email nvarchar(60),
	Password char (8) not null,
	
)
go


--Customers-->UserId,CompanyName
CREATE TABLE Customers
(
	CustomerId int primary key identity (1,1),
	UserId int foreign key references Users(UserId),
	CompanyName nvarchar (30) not null unique,
	
)
go

--Rentals-->Id, CarId, CustomerId, RentDate(Kiralama Tarihi), ReturnDate(Teslim Tarihi)
CREATE TABLE Rentals
(
	RentalId int primary key identity (1,1),
	CarId int foreign key references Cars(CarId),
	CustomerId int foreign key references Customers(CustomerId),
	RentDate datetime default getdate(),
	ReturnDate datetime default getdate(),
	
)
go

--Customers-->UserId,CompanyName
INSERT INTO Customers(CompanyName)
VALUES
	('Teknosa'),
	('LCW'),
	('Arçelik'),
	('Akbank'),
	('YapıKredi Bankası');

*********************************************************************************
*/

use RentCarDb
go

--Users-->Id,FirstName,LastName,Email,Password

--Rentals-->Id, CarId, CustomerId, RentDate(Kiralama Tarihi), ReturnDate(Teslim Tarihi)
