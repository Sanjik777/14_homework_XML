using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
/*
Основы XML.

1.	Прочитать содержимое XML файла со списком последних новостей
по ссылке https://habrahabr.ru/rss/interesting/
Создать класс Item со свойствами: Title, Link, Description, PubDate.
Создать коллекцию типа List<Item> и записать в нее данные из файла.
2.	С помощью класса XmlDocument создать класс который будет
описывать студента и вывести его на консоль или сохранить в текстовый файл
*/
namespace _14_homework_XML
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("\n-------------------------1-------------------------\n");
			string origin = @"https://habrahabr.ru/rss/interesting/";

			List<Item> items = new List<Item>();

			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(origin);
			int counter = 0;
			XmlElement root = xmlDocument.DocumentElement;

			foreach (XmlElement element in root)
			{
				foreach (XmlElement child in element)
				{
					if (child.Name == "item")
					{
						counter++;
						Item item = new Item();
						foreach (XmlElement childItem in child)
						{
							if (childItem.Name == "title")
							{
								//Console.WriteLine($"\nTITLE = {childItem.InnerText}");
								item.Title = childItem.InnerText;
							}
							if (childItem.Name == "link")
							{
								//Console.WriteLine($"\nLINK = {childItem.InnerText}");
								item.Link = childItem.InnerText;
							}
							if (childItem.Name == "description")
							{
								//Console.WriteLine($"\nDESCRIPTION = {childItem.InnerText}");
								item.Description = childItem.InnerText;
							}
							if (childItem.Name == "pubDate")
							{
								//Console.WriteLine($"\nPUBDATE = {childItem.InnerText}");
								item.PubDate = DateTime.Parse(childItem.InnerText);
							}
						}
						items.Add(item);
					}
					else { continue; }
				}
			}
			for (int i = 0; i < items.Count; i++)
			{
				Console.WriteLine(items[i].ToString());
			}
			Console.WriteLine($"\nкол-во статьей <item> = {counter}");

			Console.WriteLine("\n-------------------------2-------------------------\n");
			/*
			2.	С помощью класса XmlDocument создать класс который будет
            описывать студента и вывести его на консоль или сохранить в текстовый файл
			*/
			Student student = new Student
			{
				FullName = "Ivanov",
				Age = 23,
				AverageMark = 11.5
			};

			//Создаем xml документ
			XmlDocument xmlSecondDocument = new XmlDocument();
			
			var studentElement = xmlSecondDocument.CreateElement("student");
			var rootElement = xmlSecondDocument.CreateElement("students");
			rootElement.AppendChild(studentElement);

			var idElement = xmlSecondDocument.CreateElement("id");
			idElement.SetAttribute("type", "Guid");
			idElement.InnerText = student.Id.ToString();
			studentElement.AppendChild(idElement);

			var nameElement = xmlSecondDocument.CreateElement("name");
			nameElement.InnerText = student.FullName;
			studentElement.AppendChild(nameElement);

			var ageElement = xmlSecondDocument.CreateElement("age");
			ageElement.InnerText = student.Age.ToString();
			studentElement.AppendChild(ageElement);

			var markElement = xmlSecondDocument.CreateElement("mark");
			markElement.InnerText = student.AverageMark.ToString();
			studentElement.AppendChild(markElement);

			xmlSecondDocument.AppendChild(xmlSecondDocument.CreateXmlDeclaration("1.0", "UTF-8", null));
			xmlSecondDocument.AppendChild(rootElement);
			xmlSecondDocument.Save("data2.xml");			
		}
	}
}