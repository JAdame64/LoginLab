/* Run this entire script in SQL Server Management Studio (SSMS).
   It creates the LoginLab database and the Users table. */

IF DB_ID(N'LoginLab') IS NULL
BEGIN
    CREATE DATABASE LoginLab;
END;
GO

USE LoginLab;
GO

IF OBJECT_ID(N'dbo.Users', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users
    (
        UserID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Username NVARCHAR(50) NOT NULL,
        PasswordHash VARBINARY(32) NOT NULL,
        PasswordSalt VARBINARY(16) NOT NULL,
        PasswordIterations INT NOT NULL,
        CreatedAt DATETIME2 NOT NULL CONSTRAINT DF_Users_CreatedAt DEFAULT SYSUTCDATETIME(),
        CONSTRAINT UQ_Users_Username UNIQUE (Username)
    );
END;
GO
