USE GymTracker
GO

CREATE TABLE BodyPartType (
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
Description nvarchar(500),
CreatedBy nvarchar(255),
CreatedDate DATETIME2,
LastUpdatedBy nvarchar(255),
LastUpdatedDate DATETIME2,
Frozen int
);

