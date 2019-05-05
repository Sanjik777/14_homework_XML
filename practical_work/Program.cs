using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
/*
Основы XML.

1.	С помощью класса XDocument прочитать XML файл
и вывести название всех его тегов с сохранением иерархии.
В качестве отступов для иерархии использовать 2 пробела.
*/
namespace practical_work
{
	class Program
	{
		static void Main(string[] args)
		{
			//------------------------ 1 - способ через XDocument--------------------------------

			XDocument xDocument = XDocument.Load(
				@"C:\Users\Санжар\source\repos\14_homework_XML\practical_work\dataFromPractical.xml");

			XElement rootElement = xDocument.Element("students");
			foreach (XElement element in xDocument.Element("students").Elements("student"))
			{
				Console.WriteLine($"{rootElement.Name}");
				Console.WriteLine($"  {element.Name}");
				XElement nameElelement = element.Element("name");
				XElement ageElelement = element.Element("age");
				XElement markElelement = element.Element("mark");
				Console.WriteLine($"    {nameElelement.Name}");
				Console.WriteLine($"    {ageElelement.Name}");
				Console.WriteLine($"    {markElelement.Name}");
			}

			//------------------------ 2 - способ через XmlDocument--------------------------------

			//XmlDocument xmlDocument = new XmlDocument();
			//xmlDocument.Load(
			//	@"C:\Users\Санжар\source\repos\14_homework_XML\practical_work\dataFromPractical.xml");
			//XmlElement rootElement = xmlDocument.DocumentElement;
			//foreach (XmlElement root in rootElement)
			//{
			//	if (root.Name == "students")
			//	{
			//		Console.WriteLine(root.Name);
			//	}
			//	foreach (XmlElement element in root)
			//	{
			//		if (element.Name == "student")
			//		{
			//			Console.WriteLine(element.Name);
			//		}
			//		if (element.Name == "name")
			//		{
			//			Console.WriteLine(element.Name);
			//		}
			//		if (element.Name == "age")
			//		{
			//			Console.WriteLine(element.Name);
			//		}
			//		if (element.Name == "mark")
			//		{
			//			Console.WriteLine(element.Name);
			//		}
			//	}
			//}
			Console.ReadKey();
		}
	}
}
