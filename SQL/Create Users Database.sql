USE GymTracker
GO

CREATE TABLE UserDetail (
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
Name nvarchar(255) NOT NULL,
Email nvarchar(500) NOT NULL,
Password nvarchar(500) NOT NULL,
Validated bit,
CreatedBy nvarchar(255),
CreatedDate DATETIME2,
LastUpdatedBy nvarchar(255),
LastUpdatedDate DATETIME2
);

