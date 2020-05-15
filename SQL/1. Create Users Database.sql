USE GymTracker
GO

CREATE TABLE UserDetail (
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
Name nvarchar(255),
Email nvarchar(500),
Password nvarchar(500),
Validated bit,
CreatedBy nvarchar(255),
CreatedDate DATETIME2,
LastUpdatedBy nvarchar(255),
LastUpdatedDate DATETIME2
);

