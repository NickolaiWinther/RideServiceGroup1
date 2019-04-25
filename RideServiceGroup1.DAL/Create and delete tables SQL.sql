USE RideServiceGroup1

IF EXISTS(select * from INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Reports')
DROP TABLE Reports

IF EXISTS(select * from INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Rides')
DROP TABLE Rides

IF EXISTS(select * from INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'RideCategories')
DROP TABLE RideCategories

CREATE TABLE RideCategories (
	RideCategoryId INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(MAX) NOT NULL
);

CREATE TABLE Rides (
	RideId INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(MAX) NOT NULL,
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES RideCategories(RideCategoryId)
);

CREATE TABLE Reports (
	ReportId INT PRIMARY KEY IDENTITY(1,1),
	Status INT NOT NULL,
	ReportTime DATETIME2(7) NOT NULL,
	Notes NVARCHAR(MAX) NOT NULL,
	RideId INT NOT NULL FOREIGN KEY REFERENCES Rides(RideId)
);


-- RideCategory
INSERT INTO RideCategories
VALUES ('Vandforlystelse', 'Baner der har med vand at g�re')

INSERT INTO RideCategories
VALUES ('Pendulforlystelse', 'Baner der har med penduler at g�re')

INSERT INTO RideCategories
VALUES ('Rutsjebane', 'En rutsjebane')


-- Rides
INSERT INTO Rides
VALUES ('Vandfaldet', '42 meter lang vandrutsjebane, der kun g�r en vej: Ned!', 1)

INSERT INTO Rides
VALUES ('Regnskoven', 'Stort vandlegeland med masser of forhindringer og rutsjebaner', 1)

INSERT INTO Rides
VALUES ('Hvirvelvinden', 'En forlystelse for de st�rste vovehalse', 2)

INSERT INTO Rides
VALUES('N�ddesvinget', 'Nyhed 2019! K�rer b�de forl�ns og bagl�ns', 2)

INSERT INTO Rides
VALUES ('Tr�stammerne', 'Vild sejltur op af skovfloden og med tr� br�lende vandfald', 3)

INSERT INTO Rides
VALUES ('Orkanen', 'Orkanen er en fantastisk og h�sbl�sende rutsjebane for hele familien', 3)


-- Reports
INSERT INTO Reports
VALUES (2, '2018-06-22', 'Vogn nummer 2 tager vand ind', 5)

INSERT INTO Reports
VALUES (3, '2019-03-15', 'N�d nummer 12 sidder l�st', 4)

INSERT INTO Reports
VALUES (3, '2018-06-28', 'Et vandr�r er g�et i stykker', 5)