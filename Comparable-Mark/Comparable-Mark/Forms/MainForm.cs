using Comparable_Mark.FileProcessors;
using Comparable_Mark.Models;

namespace Comparable_Mark.Forms;

public partial class MainForm : Form
{
	private List<Student> students = new List<Student>();

	public MainForm()
	{
		InitializeComponent();


		panel1.Location = new Point(0, 0);
		panel1.Size = new Size(Width - 20, Height - 20);
		panel1.AutoScroll = true;

		students.Add(
		new Student()
		{
			FullName = $"Скоморохов Кирилл Сергеевич",
			CourseNumber = 4,
			GroupNumber = 101,
			StudyForm = StudyForm.Budget,
			Sessions = new Session[Student.COUNT_SESSION]
		}
		);

		students.Add(new Student()
		{
			FullName = $"не Скоморохов Кирилл Сергеевич",
			CourseNumber = 4,
			GroupNumber = 101,
			StudyForm = StudyForm.Budget,
			Sessions = new Session[Student.COUNT_SESSION]
		});

		foreach (var student in students)
		{
			for (int i = 0; i < Student.COUNT_SESSION; i++)
			{
				student.Sessions[i] = new Session();
			}

			foreach (var session in student.Sessions)
			{
				if (session != null)
				{
					session.Exams[0] = new Exam { Subject = "Криптология", Grade = 4 };
					session.Exams[1] = new Exam { Subject = "Математический анализ", Grade = 4 };
					session.Exams[2] = new Exam { Subject = "Программирование", Grade = 4 };
					session.Exams[3] = new Exam { Subject = "История", Grade = 5 };
				}
			}
		}



		DisplayStudents();
	}

	private void MainForm_Load(object sender, EventArgs e)
	{

	}

	private void DisplayStudents()
	{
		panel1.Controls.Clear();
		int y = 10;
		foreach (var student in students)
		{
			Panel panel = new Panel();
			panel.AutoScroll = true;
			panel.Name = student.FullName;
			panel.Size = new Size(panel1.Size.Width - 30, 280);
			panel.Location = new Point(5, y);
			panel.BorderStyle = BorderStyle.FixedSingle;

			Label labelFullName = new Label();
			labelFullName.AutoSize = true;
			labelFullName.Text = $"ФИО: {student.FullName.ToString()}";
			labelFullName.Location = new Point(10, 5);

			Label labelCourse = new Label();
			labelCourse.Text = "Курс: " + student.CourseNumber.ToString().PadRight(5, ' ') +
				"Группа: " + student.GroupNumber.ToString().PadRight(8, ' ') +
				(student.StudyForm == StudyForm.Budget ? "Бюджет" : "Договор");
			labelCourse.Location = new Point(10, labelFullName.Height + 5);
			labelCourse.AutoSize = true;

			int start = 55;
			int weight = 10;

			if (student.Sessions.FirstOrDefault() is not null)
			{
				Label labelExams = new Label();
				labelExams.Text = "Экзамены:";
				labelExams.Location = new Point(10, labelFullName.Height + 30);
				labelExams.AutoSize = true;

				int count = 1;

				foreach (var session in student.Sessions)
				{
					if (session is null)
					{
						continue;
					}
					Panel panelExs = new Panel();
					panelExs.Name = student.FullName;
					panelExs.Size = new Size(250, 125);
					panelExs.Location = new Point(weight, labelFullName.Height + start);
					panelExs.BackColor = Color.White;
					panelExs.BorderStyle = BorderStyle.FixedSingle;
					panelExs.AutoScroll = true;

					Label labelNumber = new Label();
					labelNumber.Text = $"{count} сессия: ";
					labelNumber.AutoSize = true;

					panelExs.Controls.Add(labelNumber);
					int examY = 25;
					foreach (var exam in session.Exams)
					{
						if (exam is null)
						{
							continue;
						}
						Label labelExam = new Label();
						labelExam.Text = exam.Subject;
						labelExam.Location = new Point(10, examY);
						labelExam.AutoSize = true;
						panelExs.Controls.Add(labelExam);
						Label labelGrade = new Label();
						labelGrade.Text = exam.Grade.ToString();
						labelGrade.Location = new Point(230, examY);
						labelGrade.AutoSize = true;
						panelExs.Controls.Add(labelGrade);
						examY += labelExam.Height + 5;
					}
					count++;
					weight += 250;
					if (count == 5)
					{
						panel.Size = new Size(panel1.Size.Width - 30, 405);
						start = 55 + 125;
						weight = 10;
					}
					panel.Controls.Add(panelExs);
				}
				panel.Controls.Add(labelExams);

				start += 125;
			}

			panel.Controls.Add(labelFullName);
			panel.Controls.Add(labelCourse);

			Button buttonAdd = new Button();
			buttonAdd.Text = "Удалить";
			buttonAdd.Size = new Size(150, 40);
			buttonAdd.Location = new Point(10, labelFullName.Height + start + 15);
			buttonAdd.Click += (sender, e) =>
			{
				// Получаем студента из имени панели 
				Student studentToRemove = students.FirstOrDefault(s => s.FullName == panel.Name);
				if (studentToRemove != null)
				{
					//TO DO спросить действительно хитим ли удалить
					// Удаляем студента из списка
					students.Remove(studentToRemove);
					// Обновляем отображение
					DisplayStudents();
				}
			};



			Button buttonEdit = new Button();
			buttonEdit.Text = "Редактировать";
			buttonEdit.Size = new Size(150, 40);
			buttonEdit.Location = new Point(180, labelFullName.Height + start + 15);

			panel.Controls.Add(buttonEdit);
			panel.Controls.Add(buttonAdd);

			panel1.Controls.Add(panel);

			y += panel.Size.Height + 10;
		}
	}

	private void MainForm_Resize(object sender, EventArgs e)
	{
		panel1.Size = new Size(Width - 20, Height - 20);
		DisplayStudents();
	}

	/*private void OpenFileMenuItem_Click(object sender, EventArgs e)
{
   OpenFileDialog dialog = new OpenFileDialog();
   if (dialog.ShowDialog() == DialogResult.OK)
   {
	   string filename = dialog.FileName;
	   string extension = Path.GetExtension(filename);
	   IFileProcessor processor = null;
	   switch (extension)
	   {
		   case ".xml":
			   processor = new XmlFileProcessor();
			   break;
		   case ".bin":
			   processor = new BinaryFileProcessor();
			   break;
		   case ".txt":
			   processor = new TextFileProcessor();
			   break;
	   }

	   if (processor != null)
	   {
		   processor.Load(filename);
		   UpdateListView();
	   }
   }
}

private void ButtonAdd_Click(object sender, EventArgs e)
{
   AddStudentForm addForm = new AddStudentForm();
   if (addForm.ShowDialog() == DialogResult.OK)
   {
	   Student newStudent = addForm.GetNewStudent();
	   object students;
	   students.Add(newStudent);
	   UpdateListView();
   }
}
private void UpdateListView()
{
   object listView;
   listView.Items.Clear();
   foreach (Student student in students)
   {
	   ListViewItem item = new ListViewItem(student.FullName);
	   item.SubItems.Add(student.CourseNumber.ToString());
	   item.SubItems.Add(student.GroupNumber.ToString());
	   item.SubItems.Add(student.StudyForm);
	   listView.Items.Add(item);
   }
}*/
}