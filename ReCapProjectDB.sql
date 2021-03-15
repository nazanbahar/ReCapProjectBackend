create database RecapProjectDB
go

use RecapProjectDB
go

--Color-->Id,Name
CREATE TABLE Colors
(
	Id int primary key identity (1,1) not null,
	ColorName nvarchar (50) not null, 
)

--Brand-->Id,Name
CREATE TABLE Brands
(
	Id int primary key identity (1,1) not null,
	BrandName nvarchar (50) not null,  
)

--Car--> Id, BrandId, ColorId, ModelYear, DailyPrice, Description,IsRented
CREATE TABLE Cars
(
	Id int primary key identity (1,1) not null,
	BrandId int foreign key references Brands(Id),
	ColorId int foreign key references Colors(Id),
	CarName nvarchar (50) not null,
	ModelYear int not null,
	DailyPrice decimal (30) not null,
	Description nvarchar(250) not null,
	IsRented bit,
)
go

--------------------------------------------------------------------------------------------------
use RecapProjectDB
go

--LESSON-10-Users-->Id,FirstName,LastName,Email,Password
--Lesson-15-PasswordHash,PasswordSalt 
CREATE TABLE Users
(
	Id int primary key identity (1,1) not null,
	FirstName nvarchar (50) not null,
	LastName nvarchar (50) not null,
	Email nvarchar(60) not null,
	PasswordHash varbinary (128) null,
	PasswordSalt varbinary (128) null,
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
	CarId int foreign key references Cars(Id) not null,
	CustomerId int foreign key references Customers(Id)not null,
	RentDate date not null,
	ReturnDate date not null,
	
)
go

-----------------------------------------------------------------------------------------------------------------
use RecapProjectDB
go
--CarImage--> Id,CarId,ImagePath,Date
CREATE TABLE CarImages(
    Id int primary key identity (1,1) not null,
    CarId int foreign key references Cars(Id)not null,
    ImagePath nvarchar(MAX)not null,
    CreateDate date not null,
	
);


----------------------------------------------------------------------------------------------------------------
use RecapProjectDB
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
	('1','1','2020','350','Toyota','Elektrikli Araç'),
	('2','2','2019','250','BMW','Dizel Araç'),
	('3','3','2018','150','Volvo','Benzinli Araç'),
	('4','4','2017','100','Volkswagen','Dizel Araç'),
	('5','5','2016','50','Renault','Otomatik Vites');


INSERT INTO Customers(CompanyName)
VALUES
	('Teknosa'),
	('LCW'),
	('Arçelik'),
	('Akbank'),
	('YapıKredi Bankası');

---------------------------------------------------------------------------------------------------------------------------