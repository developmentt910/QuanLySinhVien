using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using StudentCourseManagement.Domain.Entities;

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    /// <summary>
    /// Định nghĩa các phương thức làm việc với dữ liệu Sinh viên (Student)
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// Lấy toàn bộ danh sách sinh viên
        /// </summary>
        List<Student> GetAll();

        /// <summary>
        /// Thêm một sinh viên mới
        /// </summary>
        void Add(Student student);

        /// <summary>
        /// Cập nhật thông tin sinh viên
        /// </summary>
        void Update(Student student);

        /// <summary>
        /// Xóa sinh viên theo mã
        /// </summary>
        void Delete(string studentId);

        /// <summary>
        /// Tìm sinh viên theo mã
        /// </summary>
        Student? GetById(string studentId);
    }
}
