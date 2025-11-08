/* 1. Thêm Khoa */
INSERT INTO dbo.Faculty (Id, FacultyName)
VALUES (NEWID(), N'Công nghệ Thông tin'), (NEWID(), N'Kinh tế');
GO

/* 2. Thêm Ngành */
INSERT INTO dbo.Major (Id, MajorName, FacultyId)
SELECT NEWID(), N'Công nghệ phần mềm', Id FROM dbo.Faculty WHERE FacultyName = N'Công nghệ Thông tin';
INSERT INTO dbo.Major (Id, MajorName, FacultyId)
SELECT NEWID(), N'Thương mại điện tử', Id FROM dbo.Faculty WHERE FacultyName = N'Công nghệ Thông tin';
INSERT INTO dbo.Major (Id, MajorName, FacultyId)
SELECT NEWID(), N'Kế toán', Id FROM dbo.Faculty WHERE FacultyName = N'Kinh tế';
INSERT INTO dbo.Major (Id, MajorName, FacultyId)
SELECT NEWID(), N'Quản trị kinh doanh', Id FROM dbo.Faculty WHERE FacultyName = N'Kinh tế';
GO

/* 3. Thêm Chuyên ngành */
INSERT INTO dbo.Specialization (Id, SpecializationName, MajorId)
SELECT NEWID(), N'Công nghệ phần mềm', Id FROM dbo.Major WHERE MajorName = N'Công nghệ phần mềm';
INSERT INTO dbo.Specialization (Id, SpecializationName, MajorId)
SELECT NEWID(), N'Marketing trực tuyến', Id FROM dbo.Major WHERE MajorName = N'Thương mại điện tử';
INSERT INTO dbo.Specialization (Id, SpecializationName, MajorId)
SELECT NEWID(), N'Kế toán doanh nghiệp', Id FROM dbo.Major WHERE MajorName = N'Kế toán';
INSERT INTO dbo.Specialization (Id, SpecializationName, MajorId)
SELECT NEWID(), N'Quản trị doanh nghiệp', Id FROM dbo.Major WHERE MajorName = N'Quản trị kinh doanh';
GO

/* 4. Thêm Lớp học */
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId)
SELECT NEWID(), 'D18CNPM', N'D18CNPM2', 
    (SELECT Id FROM dbo.Major WHERE MajorName = N'Công nghệ phần mềm'),
    (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Công nghệ phần mềm');
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId)
SELECT NEWID(), 'D18TMDT', N'D18TMDT1', 
    (SELECT Id FROM dbo.Major WHERE MajorName = N'Thương mại điện tử'),
    (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Marketting trực tuyến');
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId)
SELECT NEWID(), 'D18KT', N'D18KT3', 
    (SELECT Id FROM dbo.Major WHERE MajorName = N'Kế toán'),
    (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Kế toán doanh nghiệp');
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId)
SELECT NEWID(), 'D18QTKD', N'D18QTKD4', 
    (SELECT Id FROM dbo.Major WHERE MajorName = N'Quản trị kinh doanh'),
    (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Quản trị doanh nghiệp');
GO

/* 5. Thêm Học kỳ */
INSERT INTO dbo.Semester (Id, SemesterCode, SemesterName, AcademicYear)
VALUES
(NEWID(), 'HK1_2025', N'Học kỳ 1', '2025-2026'),
(NEWID(), 'HK2_2025', N'Học kỳ 2', '2025-2026');
GO

/* 6. Thêm Môn học */
-- (Script này sẽ chạy thành công vì MajorId đã được phép NULL)
INSERT INTO dbo.Subject (Id, SubjectCode, SubjectName, Credit, LectureHours, PracticeHours)
VALUES
(NEWID(), 'CS101', N'Lập trình C#', 3, 30, 30),
(NEWID(), 'DB101', N'Cơ sở Dữ liệu', 4, 30, 30),
(NEWID(), 'WEB101', N'Lập trình web', 2, 15, 30),
(NEWID(), 'MK101', N'Marketing công nghệ số', 3, 30, 30),
(NEWID(), 'KT101', N'Nguyên lý kế toán', 4, 15, 30);
GO

PRINT N'Hoàn tất thêm dữ liệu mẫu.';