-- Script to assign MajorId to existing Semester rows
-- Created: 2025-11-12
-- Description: This script helps assign MajorId to semesters that don't have one yet
--              You need to manually map which semester belongs to which major

USE [QLSV]
GO

PRINT 'Checking semesters without MajorId...'
GO

-- Show all semesters that don't have MajorId assigned
SELECT 
    Id,
    SemesterCode,
    SemesterName,
    AcademicYear,
    [Year],
    SemesterNumber,
    MajorId
FROM [dbo].[Semester]
WHERE MajorId IS NULL
ORDER BY [Year], SemesterNumber;
GO

PRINT ''
PRINT 'Available Majors:'
GO

-- Show all available majors
SELECT 
    Id,
    MajorName,
    FacultyId
FROM [dbo].[Major]
ORDER BY MajorName;
GO

PRINT ''
PRINT '========================================'
PRINT 'MANUAL ASSIGNMENT REQUIRED'
PRINT '========================================'
PRINT 'Please uncomment and modify the UPDATE statements below to assign MajorId to your semesters.'
PRINT ''
GO

/*
-- Example: Assign all semesters to a specific major
-- Replace 'YOUR-MAJOR-ID-GUID-HERE' with actual Major Id from the query above

UPDATE [dbo].[Semester]
SET MajorId = 'YOUR-MAJOR-ID-GUID-HERE'
WHERE MajorId IS NULL;
GO

-- Or assign individually by SemesterCode
UPDATE [dbo].[Semester]
SET MajorId = 'MAJOR-ID-FOR-SEMESTER-1'
WHERE SemesterCode = 'HK2023-1' AND MajorId IS NULL;
GO

UPDATE [dbo].[Semester]
SET MajorId = 'MAJOR-ID-FOR-SEMESTER-2'
WHERE SemesterCode = 'HK2023-2' AND MajorId IS NULL;
GO
*/

-- After assigning MajorIds, run this to add the foreign key constraint:
/*
ALTER TABLE [dbo].[Semester]
ADD CONSTRAINT [FK_Semester_Major] 
FOREIGN KEY ([MajorId]) 
REFERENCES [dbo].[Major] ([Id])
ON DELETE NO ACTION
ON UPDATE NO ACTION;
GO

PRINT 'Foreign key constraint added successfully!'
GO
*/

-- Verify assignment
PRINT ''
PRINT 'Current status after assignment:'
GO

SELECT 
    COUNT(*) as TotalSemesters,
    SUM(CASE WHEN MajorId IS NULL THEN 1 ELSE 0 END) as SemestersWithoutMajor,
    SUM(CASE WHEN MajorId IS NOT NULL THEN 1 ELSE 0 END) as SemestersWithMajor
FROM [dbo].[Semester];
GO
