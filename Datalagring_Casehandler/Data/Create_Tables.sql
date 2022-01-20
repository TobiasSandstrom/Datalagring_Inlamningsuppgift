DROP TABLE Cases
DROP TABLE Customers
DROP TABLE CustomerContactInfos
DROP TABLE CustomerAddresses
DROP TABLE CaseStatuses
DROP TABLE CaseManagers

CREATE TABLE Casemanagers (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null
)
GO

CREATE TABLE CaseStatuses (
	Id int not null identity primary key,
	Status nvarchar(50) not null unique
)
GO

CREATE TABLE CustomerAddresses (
	Id int not null identity primary key,
	StreetAdress nvarchar(100) not null,
	ZipCode char(5) not null,
	City nvarchar(50) not null,
	Country nvarchar(50) not null
)
GO

CREATE TABLE CustomerContactInfos (
	Id int not null identity primary key,
	Email nvarchar(100) not null,
	PhoneNumber nvarchar(20) not null

)
GO
CREATE TABLE Customers (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	SocialSecurityNumber char(12) not null unique,
	AdressId int not null references CustomerAddresses(Id),
	ContactId int not null references CustomerContactInfos(Id)

)
GO

CREATE TABLE Cases (
	Id int not null identity primary key,
	CaseHeader nvarchar(50) not null,
	CaseDescription nvarchar(max),
	CaseCreated DATE not null,
	CaseLastChanged DATE null,
	StatusId int not null references CaseStatuses(Id),
	ManagerId int null references CaseManagers(Id),
	CustomerId int not null references Customers(Id)
)
GO