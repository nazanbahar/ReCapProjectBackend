create database RecapProjectTest
go

use RecapProjectTest
go

--Color-->Id,Name
CREATE TABLE Colors
(
	Id int primary key identity (1,1) not null,
	Name nvarchar (50) not null, 
)

--Brand-->Id,Name
CREATE TABLE Brands
(
	Id int primary key identity (1,1) not null,
	Name nvarchar (50) not null,  
)

--Car--> Id, BrandId, ColorId, ModelYear, DailyPrice, Description
CREATE TABLE Cars
(
	Id int primary key identity (1,1) not null,
	BrandId int foreign key references Brands(Id),
	ColorId int foreign key references Colors(Id),
	ModelYear int not null,
	DailyPrice decimal (30) not null,
	CarName nvarchar (30) not null,
	Description nvarchar(250) not null,
)
go

--------------------------------------------------------------------------------------------------
use RecapProjectTest
go

--LESSON-10-Users-->Id,FirstName,LastName,Email,Password
--Lesson-15-PasswordHash,PasswordSalt 
CREATE TABLE Users
(
	Id int primary key identity (1,1) not null,
	FirstName nvarchar (50) not null,
	LastName nvarchar (50) not null,
	Email nvarchar(60) not null,
	PasswordHash varbinary (128) not null,
	PasswordSalt varbinary (128) not null,
	Status bit not null,		
	
)
go

--Customers-->UserId,CompanyName
CREATE TABLE Customers
(
	Id int primary key identity (1,1) not null,
	UserId int foreign key references Users(Id),
	CompanyName nvarchar (50) not null,
	
)
go

--Rentals-->Id, CarId, CustomerId, RentDate(Kiralama Tarihi), ReturnDate(Teslim Tarihi)
CREATE TABLE Rentals
(
	Id int primary key identity (1,1) not null,
	CarId int foreign key references Cars(Id),
	CustomerId int foreign key references Customers(Id),
	RentDate date,
	ReturnDate date,
	
)
go

-----------------------------------------------------------------------------------------------------------------
use RecapProjectTest
go
--CarImage--> Id,CarId,ImagePath,Date
CREATE TABLE CarImages(
    Id int primary key identity (1,1) not null,
    CarId int foreign key references Cars(Id),
    ImagePath nvarchar(MAX),
    Date date,
	
);


----------------------------------------------------------------------------------------------------------------
use RecapProjectTest
go

--OperationClaims--> Id, Name
CREATE TABLE OperationClaims
(
	Id int primary key identity (1,1) not null,
	Name nvarchar (50) not null,
	
)
go

--UserOperationClaims--> Id, UserId, OperationClaimId
CREATE TABLE UserOperationClaims
(
	Id int primary key identity (1,1) not null,
	UserId int foreign key references Users(Id) not null,
	OperationClaimId int foreign key references OperationClaims(Id) not null,

)
go

------------------------------------------------------------------------------------------------------------------
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
	('1','1','2020','350','Toyota','Elektrikli Araç','Toyota Bilgisi Notu'),
	('2','2','2019','250','BMW','Dizel Araç','BMW Bilgisi Notu'),
	('3','3','2018','150','Volvo','Benzinli Araç','Volvo Bilgisi Notu'),
	('4','4','2017','100','Volkswagen','Dizel Araç','Volswagen Bilgisi Notu'),
	('5','5','2016','50','Renault','Otomatik Vites','Renault Bilgisi Notu');


INSERT INTO Customers(CompanyName)
VALUES
	('Teknosa'),
	('LCW'),
	('Arçelik'),
	('Akbank'),
	('YapıKredi Bankası');

---------------------------------------------------------------------------------------------------------------------------