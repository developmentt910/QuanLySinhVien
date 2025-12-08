using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IForgotPasswordService
    {
        Task<Guid?> GetUserIdByEmailAsync(string email);
        Task<bool> InsertOtpAsync(Guid userId, string otp);
        Task<bool> SendOtpAsync(string email);
        Task<string> ResetPasswordAsync(string email, string otp, string newPassword);
        Task<bool> VerifyOtpAsync(Guid userId, string otp);
        Task UpdatePasswordAsync(string emailSchool, string newPassword);

    }

}
