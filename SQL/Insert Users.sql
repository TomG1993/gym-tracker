USE GymTracker
GO

INSERT INTO dbo.UserDetail(Name, Email, Password, Validated, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
Values('Tom Gorton',
 'gorton.tom@hotmail.co.uk',
 'test',
 1,
 'TGO',
 GETUTCDATE(),
 'TGO',
 GETUTCDATE())


