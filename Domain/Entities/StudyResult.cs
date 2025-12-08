using System;

namespace StudentCourseManagement.Domain.Entities
{
    public class StudyResult
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SubjectId { get; set; }
        public string SemesterId { get; set; } // Guid dạng string

        public double? Midterm { get; set; } // Điểm giữa kỳ
        public double? Final { get; set; }   // Điểm cuối kỳ
        public double? Other { get; set; }   // Điểm khác
        public double? FinalNumeric { get; private set; }
        public string LetterGrade { get; private set; }
        public bool? Passed { get; private set; }
        public DateTime? UpdatedAtUtc { get; set; }

        // Tính điểm và xếp loại
        public void ComputeGrades()
        {
            if (Midterm.HasValue && Final.HasValue && Other.HasValue)
            {
                FinalNumeric = Midterm.Value * 0.2 + Other.Value * 0.1 + Final.Value * 0.7;
            }
            else
            {
                FinalNumeric = null;
            }

            if (FinalNumeric.HasValue)
            {
                if (FinalNumeric >= 8.5) LetterGrade = "A";
                else if (FinalNumeric >= 7) LetterGrade = "B";
                else if (FinalNumeric >= 5.5) LetterGrade = "C";
                else if (FinalNumeric >= 4) LetterGrade = "D";
                else LetterGrade = "F";

                Passed = FinalNumeric >= 5.5;
            }
            else
            {
                LetterGrade = null;
                Passed = null;
            }
        }
    }

    public class ListItem
    {
        public string? Text { get; set; }
        public string? Value { get; set; }

        public override string ToString() => Text;
    }
}
