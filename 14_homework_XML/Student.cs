using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _14_homework_XML
{
	public class Student
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string FullName { get; set; }
		public int Age { get; set; }
		public double AverageMark { get; set; }

		public override string ToString()
		{
			return
				$"\nFullName     : {FullName}" +
				$"\nAge          : {Age}" +
				$"\nAverage mark : {AverageMark}";
		}
	}
}
