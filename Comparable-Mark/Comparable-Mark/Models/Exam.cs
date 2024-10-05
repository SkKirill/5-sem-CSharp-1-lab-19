namespace Comparable_Mark.Models;

public class Exam
{
	public string Subject { get; set; }
	public int Grade { get; set; }

	public Exam(string subject, int grade)
	{
		Subject = subject;
		Grade = grade;
	}
	public Exam() { }
}