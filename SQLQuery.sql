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


--Customers-->UserId,CompanyName
INSERT INTO Customers(CompanyName)
VALUES
	('Teknosa'),
	('LCW'),
	('Arçelik'),
	('Akbank'),
	('YapıKredi Bankası');
	
--------------------------------------------------------------------------------------------
	

use RentCarDb
go

--LESSON-10-Users-->Id,FirstName,LastName,Email,Password
--Lesson-15-PasswordHash,PasswordSalt 
--Users
CREATE TABLE Users
(
	UserId int primary key identity (1,1),
	FirstName varchar (50),
	LastName varchar (50),
	Email varchar(60),
	PasswordHash varbinary (500),
	PasswordSalt varbinary (500),
	Status bit,		
	
)
go


--Customers-->UserId,CompanyName
CREATE TABLE Customers
(
	CustomerId int primary key identity (1,1),
	UserId int foreign key references Users(UserId),
	CompanyName nvarchar (30),
	
)
go


--Rentals-->Id, CarId, CustomerId, RentDate(Kiralama Tarihi), ReturnDate(Teslim Tarihi)
CREATE TABLE Rentals
(
	RentalId int primary key identity (1,1),
	CarId int foreign key references Cars(CarId),
	CustomerId int foreign key references Customers(CustomerId),
	RentDate datetime,
	ReturnDate datetime,
	
)
go

--Lesson-15-PasswordHash,PasswordSalt 

--OperationClaims--> Id, Name
CREATE TABLE OperationClaims
(
	Id int primary key identity (1,1),
	Name varchar (50),
	
)
go


--UserOperationClaims--> Id, UserId, OperationClaimId
CREATE TABLE UserOperationClaims
(
	Id int primary key identity (1,1),
	UserId int , --int foreign key references Users(UserId),
	OperationClaimId int ,  --int foreign key references OperationClaims(Id),

)
go
	
-------------------------------------------------------------------------------------------
use RentCarDb
go
--Tablo Column Değişklikleri...
--Users tablosuna PasswordSalt ve Satus column ları eklemek
ALTER TABLE Users 
ADD PasswordSalt varbinary(500),
	Status bit;
---------------------------------------------------------

--Tabloda column ismini PasswordHash olarak değiştirmek
exec sp_rename 'Users.password','PasswordHash';
----------------------------------------------------------
--Tabloya foreignkey eklemek
ALTER TABLE UserOperationClaims
ADD FOREIGN KEY (UserId) REFERENCES Users(UserId);
------------------------------------------------------------
ALTER TABLE UserOperationClaims
ADD FOREIGN KEY (OperationClaimId) REFERENCES OperationClaims(Id);

--------------------------------------------------------------

--Tabloda column ismini PasswordHash olarak değiştirmek
exec sp_rename 'Users.UserId','Id';


------------------------------------------------------------
--SQL column veri türü değiştirmek

-----------------------------------------------------
--SQL column NOT NULL yada NULL kısıtlaması eklemek

-----------------------------------------------------------
--varolan DB sütun tanımını değiştirmek

--ALTER TABLE Users modify Status datatype NOT NULL;
--------------------------------------------------------------
