namespace Comparable_Mark.Models;

public class Student
{
	public const int COUNT_SESSION = 8;
	public string FullName { get; set; }
	public int CourseNumber { get; set; }
	public int GroupNumber { get; set; }
	public Session[] Sessions { get; set; }
	public StudyForm StudyForm { get; set; }

	public Student()
	{
		Sessions = new Session[COUNT_SESSION];
	}

	public Student(string fullName, int courseNumber, int groupNumber, Session[] sessions, StudyForm studyForm)
	{
		FullName = fullName;
		CourseNumber = courseNumber;
		GroupNumber = groupNumber;
		Sessions = sessions;
		StudyForm = studyForm;
	}
}