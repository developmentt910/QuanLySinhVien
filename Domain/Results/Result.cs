using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Results
{
    public readonly struct Result
    {
        public bool Ok { get; }
        public string? Error { get; }
        private Result(bool ok, string? error) { Ok = ok; Error = error; }
        public static Result Success() => new(true, null);
        public static Result Fail(string e) => new(false, e);
    }

    public readonly struct Result<T>
    {
        public bool Ok { get; }
        public string? Error { get; }
        public T? Value { get; }
        private Result(bool ok, T? value, string? error) { Ok = ok; Value = value; Error = error; }
        public static Result<T> Success(T v) => new(true, v, null);
        public static Result<T> Fail(string e) => new(false, default, e);
    }
}
