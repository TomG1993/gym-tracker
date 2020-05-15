USE GymTracker
GO

CREATE TABLE SessionExercise (
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,  
HeaderId int NOT NULL ,
ExerciseId nvarchar(255),
CreatedBy nvarchar(255),
CreatedDate DATETIME2,
LastUpdatedBy nvarchar(255),
LastUpdatedDate DATETIME2,
CONSTRAINT FK_HeaderId FOREIGN KEY (HeaderID)

    REFERENCES SessionHeader(ID),
	CONSTRAINT FK_ExerciseId FOREIGN KEY (ID)
    REFERENCES Exercise(ID)

);

