USE GymTracker
GO

CREATE TABLE SessionExerciseSet (
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,  
SessionExerciseID int,
Weight int,
Repetitions int,
CreatedBy nvarchar(255),
CreatedDate DATETIME2,
LastUpdatedBy nvarchar(255),
LastUpdatedDate DATETIME2,
Frozen bit,
CONSTRAINT FK_UserIdSet FOREIGN KEY (SessionExerciseID)
    REFERENCES SessionExercise(ID)
);

