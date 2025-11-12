-- Fix script: Drop and recreate default constraint for SemesterCode
-- Created: 2025-11-12
-- Description: Fix the SemesterCode default constraint to generate shorter values

USE [QLSV]
GO

PRINT 'Fixing SemesterCode default constraint...'
GO

-- Drop existing constraint if it exists
IF EXISTS (SELECT 1 FROM sys.default_constraints 
           WHERE name = 'DF_Semester_SemesterCode' 
           AND parent_object_id = OBJECT_ID('dbo.Semester'))
BEGIN
    ALTER TABLE [dbo].[Semester]
    DROP CONSTRAINT [DF_Semester_SemesterCode];
    PRINT 'Old constraint dropped.'
END
GO

-- Create new constraint with shorter value (max 10 chars: HK + 8 chars from GUID)
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
           WHERE TABLE_NAME = 'Semester' AND COLUMN_NAME = 'SemesterCode')
BEGIN
    ALTER TABLE [dbo].[Semester]
    ADD CONSTRAINT [DF_Semester_SemesterCode] 
    DEFAULT ('HK' + LEFT(REPLACE(CAST(NEWID() AS NVARCHAR(36)), '-', ''), 8)) FOR [SemesterCode];
    PRINT 'New constraint added with shorter format.'
END
GO

PRINT 'Fix completed!'
GO

-- Test by checking current constraint definition
SELECT 
    o.name AS TableName,
    dc.name AS ConstraintName,
    dc.definition AS ConstraintDefinition
FROM sys.default_constraints dc
INNER JOIN sys.objects o ON dc.parent_object_id = o.object_id
WHERE o.name = 'Semester' AND dc.name = 'DF_Semester_SemesterCode';
GO
