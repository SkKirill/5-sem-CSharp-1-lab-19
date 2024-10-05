using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparable_Mark.Models
{
	public class Session
	{
		public const int COUNT_EXAMS = 4;
		public int number {  get; set; }
		public Exam[] Exams { get; set; }

		public Session()
		{
			Exams = new Exam[COUNT_EXAMS];
		}

		public Session(int number, Exam[] exams)
		{
			this.number = number;
			Exams = exams;
		}
	}
}
