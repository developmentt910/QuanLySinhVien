using System.Data;
using System.Data.SqlClient;
using System;
using StudentCourseManagement.Infrastructure.Data;
using StudentCourseManagement.Domain.Abstractions.Repositories;
using System.Collections.Generic;

namespace StudentCourseManagement.Infrastructure.Repositories.SqlServer.Academic
{
    public class ClassRepository : IClassRepository
    {
        private readonly SqlConnectionFactory _dbFactory;

        public ClassRepository(SqlConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        private DataTable GetData(string query, SqlParameter[]? parameters = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection conn = _dbFactory.Create())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi CSDL", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return dataTable;
        }

        private void ExecuteCommand(string query, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = _dbFactory.Create())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi thực thi: " + ex.Message, "Lỗi CSDL", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private object? ExecuteScalar(string query, SqlParameter[] parameters)
        {
            object? result = null;
            try
            {
                using (SqlConnection conn = _dbFactory.Create())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters);
                        result = cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi kiểm tra dữ liệu: " + ex.Message, "Lỗi CSDL", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return result;
        }

        public DataTable GetAllClasses()
        {
            string query = @"
                SELECT 
                    c.Id, c.ClassCode, c.ClassName, c.StudentCount, c.AdvisorName,
                    c.SpecializationId, c.MajorId, m.FacultyId
                FROM 
                    dbo.Class c
                JOIN dbo.Major m ON c.MajorId = m.Id
                JOIN dbo.Specialization s ON c.SpecializationId = s.Id
                ORDER BY c.ClassCode";

            return GetData(query);
        }

        public void AddClass(string classCode, string className, int studentCount, string advisorName, Guid majorId, Guid specializationId)
        {
            string query = @"
                INSERT INTO dbo.Class 
                    (Id, ClassCode, ClassName, MajorId, SpecializationId, StudentCount, AdvisorName)
                VALUES 
                    (NEWID(), @ClassCode, @ClassName, @MajorId, @SpecializationId, @StudentCount, @AdvisorName)";

            var parameters = new[]
            {
                new SqlParameter("@ClassCode", classCode),
                new SqlParameter("@ClassName", className),
                new SqlParameter("@MajorId", SqlDbType.UniqueIdentifier) { Value = majorId },
                new SqlParameter("@SpecializationId", SqlDbType.UniqueIdentifier) { Value = specializationId },
                new SqlParameter("@StudentCount", studentCount),
                new SqlParameter("@AdvisorName", (object)advisorName ?? DBNull.Value)
            };
            ExecuteCommand(query, parameters);
        }

        public void UpdateClass(Guid classId, string classCode, string className, int studentCount, string advisorName, Guid majorId, Guid specializationId)
        {
            string query = @"
                UPDATE dbo.Class 
                SET 
                    ClassCode = @ClassCode, 
                    ClassName = @ClassName, 
                    MajorId = @MajorId, 
                    SpecializationId = @SpecializationId, 
                    StudentCount = @StudentCount, 
                    AdvisorName = @AdvisorName
                WHERE 
                    Id = @Id";

            var parameters = new[]
            {
                new SqlParameter("@ClassCode", classCode),
                new SqlParameter("@ClassName", className),
                new SqlParameter("@MajorId", SqlDbType.UniqueIdentifier) { Value = majorId },
                new SqlParameter("@SpecializationId", SqlDbType.UniqueIdentifier) { Value = specializationId },
                new SqlParameter("@StudentCount", studentCount),
                new SqlParameter("@AdvisorName", (object)advisorName ?? DBNull.Value),
                new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = classId }
            };
            ExecuteCommand(query, parameters);
        }

        public void RemoveClass(Guid classId)
        {
            string query = "DELETE FROM dbo.Class WHERE Id = @Id";
            var parameters = new[]
            {
                new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = classId }
            };
            ExecuteCommand(query, parameters);
        }

        public bool CheckClassCodeExists(string classCode, Guid? currentId = null)
        {
            string query = "SELECT 1 FROM dbo.Class WHERE ClassCode = @ClassCode";

            if (currentId.HasValue)
            {
                query += " AND Id <> @Id";
            }

            var paramList = new List<SqlParameter>
            {
                new SqlParameter("@ClassCode", classCode)
            };

            if (currentId.HasValue)
            {
                paramList.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = currentId.Value });
            }

            object? result = ExecuteScalar(query, paramList.ToArray());
            return result != null && result != DBNull.Value;
        }

        public DataTable GetFilteredClasses(Guid? facultyId, Guid? majorId, Guid? specializationId)
        {
            string query = @"
                SELECT 
                    c.Id, c.ClassCode, c.ClassName, c.StudentCount, c.AdvisorName,
                    c.SpecializationId, c.MajorId, m.FacultyId
                FROM 
                    dbo.Class c
                JOIN dbo.Major m ON c.MajorId = m.Id
                JOIN dbo.Specialization s ON c.SpecializationId = s.Id
                WHERE 1=1";

            var parameters = new List<SqlParameter>();

            if (specializationId.HasValue)
            {
                query += " AND c.SpecializationId = @SpecializationId";
                parameters.Add(new SqlParameter("@SpecializationId", SqlDbType.UniqueIdentifier) { Value = specializationId.Value });
            }
            else if (majorId.HasValue)
            {
                query += " AND c.MajorId = @MajorId";
                parameters.Add(new SqlParameter("@MajorId", SqlDbType.UniqueIdentifier) { Value = majorId.Value });
            }
            else if (facultyId.HasValue)
            {
                query += " AND m.FacultyId = @FacultyId";
                parameters.Add(new SqlParameter("@FacultyId", SqlDbType.UniqueIdentifier) { Value = facultyId.Value });
            }

            query += " ORDER BY c.ClassCode";

            return GetData(query, parameters.ToArray());
        }
    }
}