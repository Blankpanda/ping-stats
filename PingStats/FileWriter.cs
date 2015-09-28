using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PingStats
{
	class FileWriter
	{

		public FileWriter()
		{
			// constructor
		}

		// creates a file in the the working directory
		public void CreateFile(string name , string extension)
		{
			File.Create(name + extension);
		}

		// overload to create a file in a set working directory
		public void CreateFile(string name, string extension, string wd)
		{
			// todo: this :D 
		}

		public void WriteToFile(string File, string content)
		{
			using (StreamWriter s = new StreamWriter(File))
			{
				s.WriteLine(content);
			}
		}
	
		internal void ChangeFileExten(string path, string newExten)
		{
			File.Move(path, Path.ChangeExtension(path, newExten));
		}


		/// <summary>
		/// creates a text fileText File
		/// </summary>
		/// <returns></returns>
		public string CreateFileName()
		{
			
			// get the number of stat.txt items in the directory 
			// and append a number to a name that coresponds with this number

			   DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
			   FileInfo[] files = di.GetFiles();
			   List<string> TextFiles = new List<string>();

				for (int i = 0; i < files.Length; i++)
				{
					if (files[i].ToString().Contains(".json"))					
						TextFiles.Add((files[i].ToString()));					
				}

				string NewFile = "stats" + "_" + TextFiles.Count.ToString() + ".txt"; // new file
				   
			return NewFile;
		}
	}
}
