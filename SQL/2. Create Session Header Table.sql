USE GymTracker
GO

CREATE TABLE SessionHeader (
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
UserID int NOT NULL ,
SessionNumber int,
SessionName nvarchar(255),
CreatedBy nvarchar(255),
CreatedDate DATETIME2,
LastUpdatedBy nvarchar(255),
LastUpdatedDate DATETIME2,
CONSTRAINT FK_UserId FOREIGN KEY (UserID)
    REFERENCES UserDetail(ID)
);

