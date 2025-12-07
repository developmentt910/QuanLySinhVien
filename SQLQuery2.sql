/*
================================================================
SCRIPT DỮ LIỆU MẪU V5 (Đã thêm Sĩ số, Cố vấn)
================================================================
*/

SET NOCOUNT ON;
PRINT N'Bắt đầu quá trình tạo dữ liệu mẫu...';
PRINT N'---------------------------------------';

/* ================================================================
PHẦN 1: XÓA DỮ LIỆU CŨ 
================================================================
*/
PRINT N'Bước 1/6: Đang xóa dữ liệu cũ...';
DELETE FROM dbo.Schedule;
DELETE FROM dbo.ExamSchedule;
DELETE FROM dbo.Curriculum;
DELETE FROM dbo.Class;
DELETE FROM dbo.Specialization;
DELETE FROM dbo.Subject;
DELETE FROM dbo.Major;
DELETE FROM dbo.Faculty;
DELETE FROM dbo.Semester;
GO

/* ================================================================
PHẦN 2: THÊM KHOA, NGÀNH, CHUYÊN NGÀNH
================================================================
*/
PRINT N'Bước 2/6: Đang thêm Khoa (5)...';
INSERT INTO dbo.Faculty (Id, FacultyName)
VALUES 
(NEWID(), N'Công nghệ Thông tin'), 
(NEWID(), N'Kinh tế'),
(NEWID(), N'Cơ khí'),
(NEWID(), N'Ngoại ngữ'),
(NEWID(), N'Du lịch');
GO

PRINT N'Bước 3/6: Đang thêm Ngành (10)...';
INSERT INTO dbo.Major (Id, MajorName, FacultyId)
SELECT NEWID(), N'Công nghệ phần mềm', Id FROM dbo.Faculty WHERE FacultyName = N'Công nghệ Thông tin';
INSERT INTO dbo.Major (Id, MajorName, FacultyId)
SELECT NEWID(), N'Khoa học máy tính', Id FROM dbo.Faculty WHERE FacultyName = N'Công nghệ Thông tin';
INSERT INTO dbo.Major (Id, MajorName, FacultyId)
SELECT NEWID(), N'Hệ thống thông tin', Id FROM dbo.Faculty WHERE FacultyName = N'Công nghệ Thông tin';
INSERT INTO dbo.Major (Id, MajorName, FacultyId)
SELECT NEWID(), N'Kế toán', Id FROM dbo.Faculty WHERE FacultyName = N'Kinh tế';
INSERT INTO dbo.Major (Id, MajorName, FacultyId)
SELECT NEWID(), N'Quản trị kinh doanh', Id FROM dbo.Faculty WHERE FacultyName = N'Kinh tế';
INSERT INTO dbo.Major (Id, MajorName, FacultyId)
SELECT NEWID(), N'Tài chính - Ngân hàng', Id FROM dbo.Faculty WHERE FacultyName = N'Kinh tế';
INSERT INTO dbo.Major (Id, MajorName, FacultyId)
SELECT NEWID(), N'Cơ khí Chế tạo máy', Id FROM dbo.Faculty WHERE FacultyName = N'Cơ khí';
INSERT INTO dbo.Major (Id, MajorName, FacultyId)
SELECT NEWID(), N'Kỹ thuật Ô tô', Id FROM dbo.Faculty WHERE FacultyName = N'Cơ khí';
INSERT INTO dbo.Major (Id, MajorName, FacultyId)
SELECT NEWID(), N'Ngôn ngữ Anh', Id FROM dbo.Faculty WHERE FacultyName = N'Ngoại ngữ';
INSERT INTO dbo.Major (Id, MajorName, FacultyId)
SELECT NEWID(), N'Quản trị Lữ hành', Id FROM dbo.Faculty WHERE FacultyName = N'Du lịch';
GO

PRINT N'Bước 4/6: Đang thêm Chuyên ngành (13)...';
INSERT INTO dbo.Specialization (Id, SpecializationName, MajorId)
SELECT NEWID(), N'Công nghệ phần mềm', Id FROM dbo.Major WHERE MajorName = N'Công nghệ phần mềm';
INSERT INTO dbo.Specialization (Id, SpecializationName, MajorId)
SELECT NEWID(), N'Phát triển Web & Ứng dụng', Id FROM dbo.Major WHERE MajorName = N'Công nghệ phần mềm';
INSERT INTO dbo.Specialization (Id, SpecializationName, MajorId)
SELECT NEWID(), N'Trí tuệ nhân tạo (AI)', Id FROM dbo.Major WHERE MajorName = N'Khoa học máy tính';
INSERT INTO dbo.Specialization (Id, SpecializationName, MajorId)
SELECT NEWID(), N'Hệ thống thông tin doanh nghiệp', Id FROM dbo.Major WHERE MajorName = N'Hệ thống thông tin';
INSERT INTO dbo.Specialization (Id, SpecializationName, MajorId)
SELECT NEWID(), N'Kế toán doanh nghiệp', Id FROM dbo.Major WHERE MajorName = N'Kế toán';
INSERT INTO dbo.Specialization (Id, SpecializationName, MajorId)
SELECT NEWID(), N'Kiểm toán', Id FROM dbo.Major WHERE MajorName = N'Kế toán';
INSERT INTO dbo.Specialization (Id, SpecializationName, MajorId)
SELECT NEWID(), N'Quản trị doanh nghiệp', Id FROM dbo.Major WHERE MajorName = N'Quản trị kinh doanh';
INSERT INTO dbo.Specialization (Id, SpecializationName, MajorId)
SELECT NEWID(), N'Marketing', Id FROM dbo.Major WHERE MajorName = N'Quản trị kinh doanh';
INSERT INTO dbo.Specialization (Id, SpecializationName, MajorId)
SELECT NEWID(), N'Tài chính doanh nghiệp', Id FROM dbo.Major WHERE MajorName = N'Tài chính - Ngân hàng';
INSERT INTO dbo.Specialization (Id, SpecializationName, MajorId)
SELECT NEWID(), N'Cơ điện tử', Id FROM dbo.Major WHERE MajorName = N'Cơ khí Chế tạo máy';
INSERT INTO dbo.Specialization (Id, SpecializationName, MajorId)
SELECT NEWID(), N'Tiếng Anh thương mại', Id FROM dbo.Major WHERE MajorName = N'Ngôn ngữ Anh';
INSERT INTO dbo.Specialization (Id, SpecializationName, MajorId)
SELECT NEWID(), N'Hướng dẫn viên Du lịch', Id FROM dbo.Major WHERE MajorName = N'Quản trị Lữ hành';
INSERT INTO dbo.Specialization (Id, SpecializationName, MajorId)
SELECT NEWID(), N'Công nghệ Động cơ Đốt trong', Id FROM dbo.Major WHERE MajorName = N'Kỹ thuật Ô tô';
GO

PRINT N'Bước 5/6: Đang thêm Lớp học (15)...';
/* 4. Thêm Lớp học (15) - ĐÃ THÊM SĨ SỐ VÀ CỐ VẤN */
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId, StudentCount, AdvisorName)
SELECT NEWID(), 'D18CNPM1', N'D18CNPM1', (SELECT Id FROM dbo.Major WHERE MajorName = N'Công nghệ phần mềm'), (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Công nghệ phần mềm'), 50, N'ThS. Nguyễn Văn A';
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId, StudentCount, AdvisorName)
SELECT NEWID(), 'D18CNPM2', N'D18CNPM2', (SELECT Id FROM dbo.Major WHERE MajorName = N'Công nghệ phần mềm'), (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Công nghệ phần mềm'), 55, N'ThS. Trần Thị B';
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId, StudentCount, AdvisorName)
SELECT NEWID(), 'D19WEB1', N'D19WEB1', (SELECT Id FROM dbo.Major WHERE MajorName = N'Công nghệ phần mềm'), (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Phát triển Web & Ứng dụng'), 60, N'ThS. Lê Văn C';
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId, StudentCount, AdvisorName)
SELECT NEWID(), 'D19AI1', N'D19AI1', (SELECT Id FROM dbo.Major WHERE MajorName = N'Khoa học máy tính'), (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Trí tuệ nhân tạo (AI)'), 45, N'TS. Phạm Thị D';
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId, StudentCount, AdvisorName)
SELECT NEWID(), 'D18HTTT1', N'D18HTTT1', (SELECT Id FROM dbo.Major WHERE MajorName = N'Hệ thống thông tin'), (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Hệ thống thông tin doanh nghiệp'), 50, N'ThS. Hoàng Văn E';
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId, StudentCount, AdvisorName)
SELECT NEWID(), 'D18KT1', N'D18KT1', (SELECT Id FROM dbo.Major WHERE MajorName = N'Kế toán'), (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Kế toán doanh nghiệp'), 70, N'ThS. Ngô Thị F';
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId, StudentCount, AdvisorName)
SELECT NEWID(), 'D18KT2', N'D18KT2', (SELECT Id FROM dbo.Major WHERE MajorName = N'Kế toán'), (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Kế toán doanh nghiệp'), 72, N'ThS. Vũ Văn G';
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId, StudentCount, AdvisorName)
SELECT NEWID(), 'D19KT', N'D19KT1', (SELECT Id FROM dbo.Major WHERE MajorName = N'Kế toán'), (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Kiểm toán'), 65, N'TS. Đặng Thị H';
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId, StudentCount, AdvisorName)
SELECT NEWID(), 'D18QTKD1', N'D18QTKD1', (SELECT Id FROM dbo.Major WHERE MajorName = N'Quản trị kinh doanh'), (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Quản trị doanh nghiệp'), 80, N'ThS. Bùi Văn I';
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId, StudentCount, AdvisorName)
SELECT NEWID(), 'D18QTKD2', N'D18QTKD2', (SELECT Id FROM dbo.Major WHERE MajorName = N'Quản trị kinh doanh'), (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Marketing'), 85, N'ThS. Đỗ Thị K';
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId, StudentCount, AdvisorName)
SELECT NEWID(), 'D19TC1', N'D19TC1', (SELECT Id FROM dbo.Major WHERE MajorName = N'Tài chính - Ngân hàng'), (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Tài chính doanh nghiệp'), 70, N'TS. Lại Văn L';
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId, StudentCount, AdvisorName)
SELECT NEWID(), 'D18CK1', N'D18CK1', (SELECT Id FROM dbo.Major WHERE MajorName = N'Cơ khí Chế tạo máy'), (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Cơ điện tử'), 60, N'PGS.TS. Mạc Văn M';
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId, StudentCount, AdvisorName)
SELECT NEWID(), 'D19TA1', N'D19TA1', (SELECT Id FROM dbo.Major WHERE MajorName = N'Ngôn ngữ Anh'), (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Tiếng Anh thương mại'), 40, N'ThS. Hà Thị N';
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId, StudentCount, AdvisorName)
SELECT NEWID(), 'D19DL1', N'D19DL1', (SELECT Id FROM dbo.Major WHERE MajorName = N'Quản trị Lữ hành'), (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Hướng dẫn viên Du lịch'), 45, N'ThS. Phí Văn P';
INSERT INTO dbo.Class (Id, ClassCode, ClassName, MajorId, SpecializationId, StudentCount, AdvisorName)
SELECT NEWID(), 'D18OTO1', N'D18OTO1', (SELECT Id FROM dbo.Major WHERE MajorName = N'Kỹ thuật Ô tô'), (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Công nghệ Động cơ Đốt trong'), 50, N'TS. Trương Văn Q';
GO

PRINT N'Bước 6/6: Đang tạo Học kỳ (8) và Môn học (30)...';
/* 5. Thêm Học kỳ (8) */
DECLARE @year INT = 2025;
WHILE @year <= 2028
BEGIN
    INSERT INTO dbo.Semester (Id, SemesterCode, SemesterName, AcademicYear)
    VALUES
    (NEWID(), 'HK1_' + CAST(@year AS NVARCHAR(4)), N'Học kỳ 1', CAST(@year AS NVARCHAR(4)) + '-' + CAST(@year + 1 AS NVARCHAR(4))),
    (NEWID(), 'HK2_' + CAST(@year AS NVARCHAR(4)), N'Học kỳ 2', CAST(@year AS NVARCHAR(4)) + '-' + CAST(@year + 1 AS NVARCHAR(4)));
    SET @year = @year + 1;
END
GO

/* 6. Thêm Môn học (30) - [SỬA LỖI] Đã thêm MajorId và SpecializationId */
PRINT N'Đang gán ID Ngành/Chuyên ngành...';

-- Lấy ID Ngành (Major)
DECLARE @MajorCNPM UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Major WHERE MajorName = N'Công nghệ phần mềm');
DECLARE @MajorKTPM UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Major WHERE MajorName = N'Khoa học máy tính');
DECLARE @MajorHTTT UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Major WHERE MajorName = N'Hệ thống thông tin');
DECLARE @MajorKT UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Major WHERE MajorName = N'Kế toán');
DECLARE @MajorQTKD UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Major WHERE MajorName = N'Quản trị kinh doanh');
DECLARE @MajorTCNH UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Major WHERE MajorName = N'Tài chính - Ngân hàng');
DECLARE @MajorCKCTM UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Major WHERE MajorName = N'Cơ khí Chế tạo máy');
DECLARE @MajorOTO UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Major WHERE MajorName = N'Kỹ thuật Ô tô');
DECLARE @MajorNNN UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Major WHERE MajorName = N'Ngôn ngữ Anh');
DECLARE @MajorDL UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Major WHERE MajorName = N'Quản trị Lữ hành');

-- Lấy ID Chuyên ngành (Specialization)
DECLARE @SpecCNPM UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Công nghệ phần mềm');
DECLARE @SpecWeb UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Phát triển Web & Ứng dụng');
DECLARE @SpecAI UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Trí tuệ nhân tạo (AI)');
DECLARE @SpecHTTTDN UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Hệ thống thông tin doanh nghiệp');
DECLARE @SpecKTDN UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Kế toán doanh nghiệp');
DECLARE @SpecKiemToan UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Kiểm toán');
DECLARE @SpecQTKD UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Quản trị doanh nghiệp');
DECLARE @SpecMkt UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Marketing');
DECLARE @SpecTCDN UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Tài chính doanh nghiệp');
DECLARE @SpecCDT UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Cơ điện tử');
DECLARE @SpecTATM UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Tiếng Anh thương mại');
DECLARE @SpecDL UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Hướng dẫn viên Du lịch');
DECLARE @SpecOto UNIQUEIDENTIFIER = (SELECT Id FROM dbo.Specialization WHERE SpecializationName = N'Công nghệ Động cơ Đốt trong');

PRINT N'Đang thêm 30 môn học...';
INSERT INTO dbo.Subject (Id, SubjectCode, SubjectName, Credit, LectureHours, PracticeHours, MajorId, SpecializationId)
VALUES
-- Môn chung CNTT (MajorId = @MajorCNPM, SpecializationId = NULL)
(NEWID(), 'CS102', N'Cấu trúc dữ liệu & Giải thuật', 3, 30, 15, @MajorCNPM, NULL),
(NEWID(), 'DB101', N'Cơ sở Dữ liệu', 4, 30, 30, @MajorCNPM, NULL),
-- Môn chuyên ngành CNPM
(NEWID(), 'CS101', N'Lập trình C#', 3, 30, 30, @MajorCNPM, @SpecCNPM),
(NEWID(), 'CS201', N'Lập trình Hướng đối tượng', 3, 30, 30, @MajorCNPM, @SpecCNPM),
(NEWID(), 'CS301', N'Mẫu thiết kế (Design Patterns)', 3, 45, 0, @MajorCNPM, @SpecCNPM),
(NEWID(), 'CS305', N'Kiểm thử phần mềm', 3, 30, 15, @MajorCNPM, @SpecCNPM),
-- Môn chuyên ngành Web
(NEWID(), 'WEB101', N'Lập trình web', 2, 15, 30, @MajorCNPM, @SpecWeb),
(NEWID(), 'NET101', N'Lập trình .NET', 3, 30, 30, @MajorCNPM, @SpecWeb),
-- Môn chuyên ngành AI
(NEWID(), 'AI101', N'Nhập môn Trí tuệ nhân tạo', 3, 45, 0, @MajorKTPM, @SpecAI),
(NEWID(), 'AI201', N'Học máy (Machine Learning)', 4, 45, 15, @MajorKTPM, @SpecAI),
-- Môn chuyên ngành HTTT
(NEWID(), 'IS101', N'Phân tích thiết kế HTTT', 3, 45, 0, @MajorHTTT, @SpecHTTTDN),
(NEWID(), 'IS201', N'Quản trị dự án phần mềm', 3, 45, 0, @MajorHTTT, @SpecHTTTDN),
-- Môn chung Kinh tế (Kế toán)
(NEWID(), 'KT101', N'Nguyên lý kế toán', 4, 45, 15, @MajorKT, NULL),
-- Môn chuyên ngành Kế toán DN
(NEWID(), 'KT201', N'Kế toán tài chính 1', 3, 30, 15, @MajorKT, @SpecKTDN),
(NEWID(), 'KT202', N'Kế toán quản trị', 3, 30, 15, @MajorKT, @SpecKTDN),
-- Môn chuyên ngành Kiểm toán
(NEWID(), 'AUD101', N'Kiểm toán căn bản', 3, 45, 0, @MajorKT, @SpecKiemToan),
-- Môn chung Quản trị KD
(NEWID(), 'QT101', N'Quản trị học', 3, 45, 0, @MajorQTKD, NULL),
-- Môn chuyên ngành Marketing
(NEWID(), 'MK101', N'Marketing căn bản', 3, 45, 0, @MajorQTKD, @SpecMkt),
(NEWID(), 'MK201', N'Marketing số (Digital Marketing)', 3, 30, 15, @MajorQTKD, @SpecMkt),
-- Môn chuyên ngành Quản trị DN
(NEWID(), 'QT201', N'Quản trị chiến lược', 3, 45, 0, @MajorQTKD, @SpecQTKD),
(NEWID(), 'QT301', N'Quản trị Nhân sự', 3, 30, 15, @MajorQTKD, @SpecQTKD),
-- Môn chung Tài chính NH
(NEWID(), 'TC101', N'Tài chính tiền tệ', 3, 45, 0, @MajorTCNH, NULL),
(NEWID(), 'NH101', N'Ngân hàng thương mại', 3, 45, 0, @MajorTCNH, NULL),
-- Môn chuyên ngành Tài chính DN
(NEWID(), 'TC201', N'Tài chính doanh nghiệp', 3, 30, 15, @MajorTCNH, @SpecTCDN),
-- Môn chung Cơ khí
(NEWID(), 'CK101', N'Cơ lý thuyết', 2, 30, 0, @MajorCKCTM, NULL),
(NEWID(), 'CKCDT1', N'Vật liệu cơ khí', 3, 30, 15, @MajorCKCTM, @SpecCDT),
-- Môn chuyên ngành Kỹ thuật Ô tô
(NEWID(), 'CK201', N'Kỹ thuật Ô tô 1', 4, 45, 30, @MajorOTO, @SpecOto),
-- Môn chung Ngoại ngữ / Du lịch
(NEWID(), 'TA301', N'Tiếng Anh giao tiếp thương mại', 3, 30, 15, @MajorNNN, @SpecTATM),
(NEWID(), 'DL101', N'Tổng quan Du lịch', 2, 30, 0, @MajorDL, @SpecDL),
-- Môn chung toàn trường (Không thuộc khoa nào)
(NEWID(), 'TA101', N'Tiếng Anh 1', 2, 15, 30, NULL, NULL),
(NEWID(), 'TA102', N'Tiếng Anh 2', 2, 15, 30, NULL, NULL);
GO

PRINT N'---------------------------------------';
PRINT N'HOÀN TẤT!';
SET NOCOUNT OFF;