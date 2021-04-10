using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("Grade must be positive!");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("Min Grade must be positive!");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("MAx Grade must be more than Min Grade!");
        }

        if (grade < minGrade || maxGrade < grade)
        {
            throw new ArgumentOutOfRangeException("Grade is out of range!");
        }

        if (comments == null)
        {
            throw new ArgumentNullException("Comments is null!");
        }

        if (comments == string.Empty)
        {
            throw new ArgumentOutOfRangeException("Comments is empty!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
