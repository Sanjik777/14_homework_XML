using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _14_homework_XML
{
	public class Item
	{
		public string Title { get; set; }
		public string Link { get; set; }
		public string Description { get; set; }
		public DateTime PubDate { get; set; }		

		public override string ToString()
		{
			return
				$"\nTitle       : {Title}"
				//+$"\nlink        : {Link}"
				//+$"\nDescription : {Description}"
				//+$"\nPubDate     : {PubDate}"
				//+$"\n-----------------------------"
				;
		}
	}
}
