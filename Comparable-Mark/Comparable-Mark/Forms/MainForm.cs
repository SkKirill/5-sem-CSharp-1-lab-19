using Comparable_Mark.Models;

namespace Comparable_Mark.Forms;

public partial class MainForm : Form
{
	private static List<Student> _students = [];

	public MainForm()
	{
		InitializeComponent();
		panelStudents.Location = new Point(0, 0);
		panelStudents.Size = new Size(Width - 20, Height - 60);
		panelStudents.AutoScroll = true;



		_students.Add(
		new Student()
		{
			Id = 1,
			FullName = $"Скоморохов Кирилл Сергеевич",
			CourseNumber = 4,
			GroupNumber = 101,
			StudyForm = StudyForm.Budget,
			Sessions = new Session[Student.COUNT_SESSION]
		}
		);

		_students.Add(new Student()
		{
			Id = 2,
			FullName = $"не Скоморохов Кирилл Сергеевич",
			CourseNumber = 4,
			GroupNumber = 101,
			StudyForm = StudyForm.Budget,
			Sessions = new Session[Student.COUNT_SESSION]
		});

		foreach (var student in _students)
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

	public void DisplayStudents()
	{
		// Очистка главной панели с информацией для перерисовки 
		panelStudents.Controls.Clear();

		// Ширина окна на данный момент
		int FullWidth = panelStudents.Size.Width - 40;
		// Отступ от самого верха формы и между каждой панелью с информацией о студенте
		int startHeightPanelStudents = 10;
		// отступ от левого края
		int leftWidht = 10;

		Panel panelAddNew = CreatePanelAdd(FullWidth, ref startHeightPanelStudents, 5, leftWidht);
		// Добавляем панель для добавления нового студента
		panelStudents.Controls.Add(panelAddNew);

		foreach (var student in _students) // для каждого студента из списка отрисовываем
		{
			// отступ между элементами 
			int middleHeight = 5;
			// панель в которой будут храниться все элементы с информацией
			Panel panelStudent = new()
			{
				AutoScroll = true, // добавление возможности прокрутки при изменении размера главного окна
				Size = new Size(FullWidth, 200),
				Name = student.Id.ToString(), // название панели будет хранить индивидуальный номер каждого
											  // студента, по которому его можно будет идентифицировать
				Location = new Point(leftWidht, startHeightPanelStudents), // расположение левого верхнего угла на panelStudents
				BorderStyle = BorderStyle.FixedSingle // отрисовка черным по контуру
			};

			// Первая строчка, которая содержит номер студента (самогенерируемый) и его ФИО
			Label labelFullName = new()
			{
				AutoSize = true,
				Text = $"{student.Id}  |  ФИО: {student.FullName}",
				Location = new Point(leftWidht, middleHeight)
			};
			middleHeight += 25;
			panelStudent.Controls.Add(labelFullName); // Добавление этой надписи на panelStudent

			// Вторая строка с информацией (курс группа)
			Label labelCourse = new()
			{
				Text = $"Курс: {student.CourseNumber} | Группа: {student.GroupNumber} | {(student.StudyForm == StudyForm.Budget ? "Бюджет" : "Договор")}",
				Location = new Point(leftWidht, middleHeight),
				AutoSize = true
			};
			middleHeight += 25;
			panelStudent.Controls.Add(labelCourse);

			middleHeight = CreateExsamList(FullWidth, leftWidht, student, middleHeight, panelStudent);

			Button buttonDelete = new()
			{
				Text = "Удалить",
				Size = new Size(150, 40),
				Location = new Point(leftWidht, middleHeight)
			};
			buttonDelete.Click += (sender, e) => ButtonDeleteClick(panelStudent);
			panelStudent.Controls.Add(buttonDelete);

			Button buttonEdit = new()
			{
				Text = "Редактировать",
				Size = new Size(150, 40),
				Location = new Point(180, middleHeight)
			};
			buttonEdit.Click += (sender, e) => ButtonDeleteClick(panelStudent);
			panelStudent.Controls.Add(buttonEdit);
			middleHeight += 45;

			panelStudent.Size = new Size(FullWidth, middleHeight);

			panelStudents.Controls.Add(panelStudent);
			startHeightPanelStudents += panelStudent.Size.Height + 10;
		}
	}
	private static int CreateExsamList(int FullWidth, int leftWidht, Student student, int middleHeight, Panel panelStudent)
	{
		if (student.Sessions.FirstOrDefault() is not null)
		{
			Label labelExams = new()
			{
				Text = "Экзамены:",
				Location = new Point(leftWidht, middleHeight),
				AutoSize = true
			};
			middleHeight += 25;
			int widthExam = leftWidht;
			int countSession = 1;

			foreach (var session in student.Sessions)
			{
				if (session is null)
				{
					continue;
				}

				Panel panelExs = new()
				{
					Name = student.FullName,
					Size = new Size(250, 125), // Размеры панели под 1 сессию всегда такой
					Location = new Point(widthExam, middleHeight),
					BackColor = Color.White,
					BorderStyle = BorderStyle.FixedSingle,
					AutoScroll = true
				};
				widthExam += 255;
				if (countSession != Student.COUNT_SESSION && FullWidth - widthExam < 250) // Не хватит место для вывода следущей сессии
				{
					middleHeight += 130; // переход на новую строчку 
					widthExam = leftWidht; // дефолтный отступ
				}

				Label labelNumber = new()
				{
					Text = $"{countSession} сессия:",
					AutoSize = true
				};
				panelExs.Controls.Add(labelNumber);

				int examHeight = 25;
				foreach (var exam in session.Exams)
				{
					if (exam is null)
					{
						continue;
					}

					Label labelExam = new()
					{
						Text = exam.Subject,
						Location = new Point(leftWidht, examHeight),
						AutoSize = true
					};
					panelExs.Controls.Add(labelExam);

					Label labelGrade = new()
					{
						Text = exam.Grade.ToString(),
						Location = new Point(230, examHeight),
						AutoSize = true
					};
					panelExs.Controls.Add(labelGrade);
					examHeight += labelExam.Height + 5;
				}

				countSession++;
				panelStudent.Controls.Add(panelExs);
			}
			panelStudent.Controls.Add(labelExams);
			middleHeight += 130;
		}

		return middleHeight;
	}
	private Panel CreatePanelAdd(int FullWidth, ref int startHeightPanelStudents, int middleHeight, int leftWidht)
	{
		// Добавляем отрисовку самой первой панели которая будет кнопкой добавления
		Panel panelAddNew = new()
		{
			Size = new Size(FullWidth, 35),
			Location = new Point(leftWidht, startHeightPanelStudents), // расположение правого верхнего угла на panelStudents
			BorderStyle = BorderStyle.FixedSingle // отрисовка черным по контуру
		};

		// Делаем обработку события при нажатии на панель
		panelAddNew.Click += (sender, e) => ButtonAddStudent();

		// Первая строчка, которая содержит номер студента (самогенерируемый) и его ФИО
		Label labelPlus = new()
		{
			AutoSize = true,
			Text = "+ нажмите, чтобы добавить студента",
			Location = new Point(leftWidht, middleHeight)
		};

		// Делаем обработку события при нажатии на надпись пользователем
		labelPlus.Click += (sender, e) => ButtonAddStudent();
		panelAddNew.Controls.Add(labelPlus); // Добавление этой надписи на panelAddNew

		// Меняем стартовый отступ для следующего элемента
		startHeightPanelStudents += panelAddNew.Size.Height + 10;
		return panelAddNew;
	}

	private void ButtonAddStudent()
	{
		AddStudentForm addStudentForm = new(ref _students);
		addStudentForm.ShowDialog();
		DisplayStudents();
	}

	private void ButtonDeleteClick(Panel panel)
	{
		// Получаем студента из имени панели 
		Student studentToRemove = _students.FirstOrDefault(s => s.Id.ToString() == panel.Name);
		if (studentToRemove != null)
		{
			//TO DO спросить действительно хотим ли удалить
			// Удаляем студента из списка
			_students.Remove(studentToRemove);
			// Обновляем отображение
			DisplayStudents();
		}
	}

	private void MainForm_Resize(object sender, EventArgs e)
	{
		panelStudents.Location = new Point(0, 0);
		panelStudents.Size = new Size(Width - 20, Height - 60);
		DisplayStudents();
	}

	private void fileToolStripMenuItem_Click(object sender, EventArgs e)
	{

	}
}