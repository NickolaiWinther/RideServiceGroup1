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
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES RideCategories(RideCategoryId),
	Status INT NOT NULL
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
VALUES ('Vandforlystelse', 'Baner der har med vand at gøre')

INSERT INTO RideCategories
VALUES ('Pendulforlystelse', 'Baner der har med penduler at gøre')

INSERT INTO RideCategories
VALUES ('Rutsjebane', 'En rutsjebane')


-- Rides
INSERT INTO Rides
VALUES ('Vandfaldet', '42 meter lang vandrutsjebane, der kun går en vej: Ned!', 1, 3)

INSERT INTO Rides
VALUES ('Regnskoven', 'Stort vandlegeland med masser of forhindringer og rutsjebaner', 1, 1)

INSERT INTO Rides
VALUES ('Hvirvelvinden', 'En forlystelse for de største vovehalse', 2, 1)

INSERT INTO Rides
VALUES('Nøddesvinget', 'Nyhed 2019! Kører både forlæns og baglæns', 2, 2)

INSERT INTO Rides
VALUES ('Falken', 'Danmarks hurtigste trærutsjebane', 3, 2)

INSERT INTO Rides
VALUES ('Orkanen', 'Orkanen er en fantastisk og hæsblæsende rutsjebane for hele familien', 3, 3)


-- Reports
INSERT INTO Reports
VALUES (''