-- Migration Script: Alter Semester Table to match application logic
-- Created: 2025-11-12
-- Description: Add new columns to support semester management per major
-- This script is idempotent and can be run multiple times safely

USE [QLSV]
GO

-- Step 0: Make old columns nullable (to avoid insert errors during transition)
PRINT 'Step 0: Making old columns nullable...'
GO

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
           WHERE TABLE_NAME = 'Semester' AND COLUMN_NAME = 'SemesterCode' AND IS_NULLABLE = 'NO')
BEGIN
    ALTER TABLE [dbo].[Semester]
    ALTER COLUMN [SemesterCode] NVARCHAR(20) NULL;
    PRINT 'SemesterCode is now nullable.'
END
ELSE
BEGIN
    PRINT 'SemesterCode is already nullable or does not exist.'
END
GO

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
           WHERE TABLE_NAME = 'Semester' AND COLUMN_NAME = 'AcademicYear' AND IS_NULLABLE = 'NO')
BEGIN
    ALTER TABLE [dbo].[Semester]
    ALTER COLUMN [AcademicYear] NVARCHAR(20) NULL;
    PRINT 'AcademicYear is now nullable.'
END
ELSE
BEGIN
    PRINT 'AcademicYear is already nullable or does not exist.'
END
GO

-- Step 1: Add new columns to Semester table (only if they don't exist)
PRINT 'Step 1: Adding new columns to Semester table...'
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Semester' AND COLUMN_NAME = 'Year')
BEGIN
    ALTER TABLE [dbo].[Semester] ADD [Year] INT NULL;
    PRINT 'Column Year added.'
END
ELSE PRINT 'Column Year already exists.'
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Semester' AND COLUMN_NAME = 'SemesterNumber')
BEGIN
    ALTER TABLE [dbo].[Semester] ADD [SemesterNumber] INT NULL;
    PRINT 'Column SemesterNumber added.'
END
ELSE PRINT 'Column SemesterNumber already exists.'
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Semester' AND COLUMN_NAME = 'StartDate')
BEGIN
    ALTER TABLE [dbo].[Semester] ADD [StartDate] DATETIME2(7) NULL;
    PRINT 'Column StartDate added.'
END
ELSE PRINT 'Column StartDate already exists.'
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Semester' AND COLUMN_NAME = 'EndDate')
BEGIN
    ALTER TABLE [dbo].[Semester] ADD [EndDate] DATETIME2(7) NULL;
    PRINT 'Column EndDate added.'
END
ELSE PRINT 'Column EndDate already exists.'
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Semester' AND COLUMN_NAME = 'IsActive')
BEGIN
    ALTER TABLE [dbo].[Semester] ADD [IsActive] BIT NULL;
    PRINT 'Column IsActive added.'
END
ELSE PRINT 'Column IsActive already exists.'
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Semester' AND COLUMN_NAME = 'MajorId')
BEGIN
    ALTER TABLE [dbo].[Semester] ADD [MajorId] UNIQUEIDENTIFIER NULL;
    PRINT 'Column MajorId added.'
END
ELSE PRINT 'Column MajorId already exists.'
GO

PRINT 'All columns checked/added successfully.'
GO

-- Step 2: Migrate existing data (if any)
PRINT 'Step 2: Migrating existing data...'
GO

-- Only update if there are existing rows
DECLARE @RowCount INT;
SELECT @RowCount = COUNT(*) FROM [dbo].[Semester];

IF @RowCount > 0
BEGIN
    PRINT 'Found ' + CAST(@RowCount AS NVARCHAR(10)) + ' existing rows. Migrating...'
    
    -- Check if AcademicYear column exists for migration
    IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'Semester' AND COLUMN_NAME = 'AcademicYear')
    BEGIN
        UPDATE [dbo].[Semester]
        SET [Year] = CAST(LEFT([AcademicYear], 4) AS INT),
            [SemesterNumber] = 1,
            [StartDate] = DATEFROMPARTS(CAST(LEFT([AcademicYear], 4) AS INT), 9, 1),
            [EndDate] = DATEFROMPARTS(CAST(LEFT([AcademicYear], 4) AS INT) + 1, 1, 31),
            [IsActive] = 1,
            [SemesterCode] = CASE 
                WHEN [SemesterCode] IS NULL THEN 'HK' + LEFT(CAST(NEWID() AS NVARCHAR(36)), 8)
                ELSE [SemesterCode]
            END
        WHERE [Year] IS NULL;
        
        PRINT 'Data migrated from AcademicYear column.'
    END
    ELSE
    BEGIN
        -- If no AcademicYear column, set default values for any existing rows
        UPDATE [dbo].[Semester]
        SET [Year] = YEAR(GETDATE()),
            [SemesterNumber] = 1,
            [StartDate] = DATEFROMPARTS(YEAR(GETDATE()), 1, 1),
            [EndDate] = DATEFROMPARTS(YEAR(GETDATE()), 6, 30),
            [IsActive] = 1,
            [SemesterCode] = CASE 
                WHEN [SemesterCode] IS NULL THEN 'HK' + LEFT(CAST(NEWID() AS NVARCHAR(36)), 8)
                ELSE [SemesterCode]
            END,
            [AcademicYear] = CASE
                WHEN [AcademicYear] IS NULL THEN CAST(YEAR(GETDATE()) AS NVARCHAR(4)) + '-' + CAST(YEAR(GETDATE()) + 1 AS NVARCHAR(4))
                ELSE [AcademicYear]
            END
        WHERE [Year] IS NULL;
        
        PRINT 'Default values set for existing rows.'
    END
END
ELSE
BEGIN
    PRINT 'No existing rows found. Skipping data migration.'
END
GO

PRINT 'Data migration completed.'
GO

-- Step 3: Make columns NOT NULL after data migration
PRINT 'Step 3: Setting columns to NOT NULL...'
GO

ALTER TABLE [dbo].[Semester]
ALTER COLUMN [Year] INT NOT NULL;
GO

ALTER TABLE [dbo].[Semester]
ALTER COLUMN [SemesterNumber] INT NOT NULL;
GO

ALTER TABLE [dbo].[Semester]
ALTER COLUMN [StartDate] DATETIME2(7) NOT NULL;
GO

ALTER TABLE [dbo].[Semester]
ALTER COLUMN [EndDate] DATETIME2(7) NOT NULL;
GO

ALTER TABLE [dbo].[Semester]
ALTER COLUMN [IsActive] BIT NOT NULL;
GO

PRINT 'Columns set to NOT NULL successfully.'
GO

-- Step 4: Add default constraints
PRINT 'Step 4: Adding default constraints...'
GO

-- Default for IsActive (check if not exists first)
IF NOT EXISTS (SELECT 1 FROM sys.default_constraints WHERE name = 'DF_Semester_IsActive' AND parent_object_id = OBJECT_ID('dbo.Semester'))
BEGIN
    ALTER TABLE [dbo].[Semester]
    ADD CONSTRAINT [DF_Semester_IsActive] DEFAULT ((1)) FOR [IsActive];
    PRINT 'Default constraint added for IsActive.'
END
ELSE PRINT 'Default constraint for IsActive already exists.'
GO

-- Default for SemesterCode (auto-generate if not provided)
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
           WHERE TABLE_NAME = 'Semester' AND COLUMN_NAME = 'SemesterCode')
   AND NOT EXISTS (SELECT 1 FROM sys.default_constraints WHERE name = 'DF_Semester_SemesterCode' AND parent_object_id = OBJECT_ID('dbo.Semester'))
BEGIN
    ALTER TABLE [dbo].[Semester]
    ADD CONSTRAINT [DF_Semester_SemesterCode] DEFAULT ('HK' + LEFT(CAST(NEWID() AS NVARCHAR(36)), 8)) FOR [SemesterCode];
    PRINT 'Default constraint added for SemesterCode.'
END
ELSE PRINT 'Default constraint for SemesterCode already exists or column does not exist.'
GO

-- Default for AcademicYear (use current year)
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
           WHERE TABLE_NAME = 'Semester' AND COLUMN_NAME = 'AcademicYear')
   AND NOT EXISTS (SELECT 1 FROM sys.default_constraints WHERE name = 'DF_Semester_AcademicYear' AND parent_object_id = OBJECT_ID('dbo.Semester'))
BEGIN
    ALTER TABLE [dbo].[Semester]
    ADD CONSTRAINT [DF_Semester_AcademicYear] DEFAULT (CAST(YEAR(GETDATE()) AS NVARCHAR(4)) + '-' + CAST(YEAR(GETDATE()) + 1 AS NVARCHAR(4))) FOR [AcademicYear];
    PRINT 'Default constraint added for AcademicYear.'
END
ELSE PRINT 'Default constraint for AcademicYear already exists or column does not exist.'
GO

-- Step 5: Add Foreign Key constraint to Major table
PRINT 'Step 5: Adding foreign key constraint (MajorId can be NULL for backward compatibility)...'
GO

-- Only add foreign key if there are no NULL MajorId values OR table is empty
DECLARE @NullMajorCount INT;
SELECT @NullMajorCount = COUNT(*) FROM [dbo].[Semester] WHERE [MajorId] IS NULL;

IF @NullMajorCount = 0
BEGIN
    ALTER TABLE [dbo].[Semester]
    ADD CONSTRAINT [FK_Semester_Major] 
    FOREIGN KEY ([MajorId]) 
    REFERENCES [dbo].[Major] ([Id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;
    
    PRINT 'Foreign key constraint added successfully.'
END
ELSE
BEGIN
    PRINT 'WARNING: ' + CAST(@NullMajorCount AS NVARCHAR(10)) + ' rows have NULL MajorId. Foreign key constraint NOT added.'
    PRINT 'Please assign MajorId to all rows before adding the constraint manually.'
    PRINT 'SQL: ALTER TABLE [dbo].[Semester] ADD CONSTRAINT [FK_Semester_Major] FOREIGN KEY ([MajorId]) REFERENCES [dbo].[Major] ([Id]);'
END
GO

-- Step 6: Add check constraints for data validation
PRINT 'Step 6: Adding check constraints...'
GO

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CHK_Semester_Year' AND parent_object_id = OBJECT_ID('dbo.Semester'))
BEGIN
    ALTER TABLE [dbo].[Semester]
    ADD CONSTRAINT [CHK_Semester_Year] 
    CHECK ([Year] >= 2000 AND [Year] <= 2100);
    PRINT 'Check constraint CHK_Semester_Year added.'
END
ELSE PRINT 'Check constraint CHK_Semester_Year already exists.'
GO

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CHK_Semester_SemesterNumber' AND parent_object_id = OBJECT_ID('dbo.Semester'))
BEGIN
    ALTER TABLE [dbo].[Semester]
    ADD CONSTRAINT [CHK_Semester_SemesterNumber] 
    CHECK ([SemesterNumber] >= 1 AND [SemesterNumber] <= 3);
    PRINT 'Check constraint CHK_Semester_SemesterNumber added.'
END
ELSE PRINT 'Check constraint CHK_Semester_SemesterNumber already exists.'
GO

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CHK_Semester_Dates' AND parent_object_id = OBJECT_ID('dbo.Semester'))
BEGIN
    ALTER TABLE [dbo].[Semester]
    ADD CONSTRAINT [CHK_Semester_Dates] 
    CHECK ([StartDate] < [EndDate]);
    PRINT 'Check constraint CHK_Semester_Dates added.'
END
ELSE PRINT 'Check constraint CHK_Semester_Dates already exists.'
GO

PRINT 'Check constraints completed.'
GO

-- Step 7: Create indexes for better query performance
PRINT 'Step 7: Creating indexes...'
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Semester_MajorId' AND object_id = OBJECT_ID('dbo.Semester'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Semester_MajorId] 
    ON [dbo].[Semester] ([MajorId])
    INCLUDE ([Year], [SemesterNumber], [IsActive]);
    PRINT 'Index IX_Semester_MajorId created.'
END
ELSE PRINT 'Index IX_Semester_MajorId already exists.'
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Semester_Year_Number' AND object_id = OBJECT_ID('dbo.Semester'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Semester_Year_Number] 
    ON [dbo].[Semester] ([Year], [SemesterNumber])
    INCLUDE ([MajorId], [IsActive]);
    PRINT 'Index IX_Semester_Year_Number created.'
END
ELSE PRINT 'Index IX_Semester_Year_Number already exists.'
GO

PRINT 'Indexes completed.'
GO

PRINT 'Migration completed successfully!'
GO

-- Optional: Print current structure of Semester table
PRINT ''
PRINT 'Current Semester table structure:'
GO

SELECT 
    COLUMN_NAME, 
    DATA_TYPE, 
    IS_NULLABLE,
    COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Semester'
ORDER BY ORDINAL_POSITION;
GO
