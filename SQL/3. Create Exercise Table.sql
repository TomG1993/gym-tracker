USE GymTracker
GO

CREATE TABLE Exercise (
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
BodyPartTypeID int,
Description nvarchar(500),
CreatedBy nvarchar(255),
CreatedDate DATETIME2,
LastUpdatedBy nvarchar(255),
LastUpdatedDate DATETIME2,
Frozen bit
);

