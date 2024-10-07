using Comparable_Mark.Models;

namespace Comparable_Mark.Forms;

public partial class AddStudentForm : Form
{
	private readonly List<Student> _students;
	public AddStudentForm(ref List<Student> students)
    {
        InitializeComponent();

        _students = students;


		students.Add(new Student()
		{
			Id = students.Count+1,
			FullName = $"не Скоморохов Кирилл Сергеевич",
			CourseNumber = 4,
			GroupNumber = 101,
			StudyForm = StudyForm.Budget,
			Sessions = new Session[Student.COUNT_SESSION]
		});

		int aaaaq = students.Count;
		var student = students.FirstOrDefault(item => item.Id == aaaaq);

		for (int i = 0; i < Student.COUNT_SESSION; i++)
		{
			student.Sessions[i] = new Session();
		}

		foreach (var session in student.Sessions)
		{
			if (session != null)
			{
				session.Exams[0] = new Exam { Subject = "1", Grade = 4 };
				session.Exams[1] = new Exam { Subject = "2 анализ", Grade = 4 };
				session.Exams[2] = new Exam { Subject = "3", Grade = 4 };
				session.Exams[3] = new Exam { Subject = "4", Grade = 5 };
			}
		}
    }
}