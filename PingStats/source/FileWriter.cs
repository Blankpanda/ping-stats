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

		public void WriteToFile(string file, string content)
		{
			using (StreamWriter s = new StreamWriter(file))
			{
				s.WriteLine(content);
			}
		}
	
		internal void ChangeFileExten(string path, string newExten)
		{
			File.Move(path, Path.ChangeExtension(path, newExten));
		}


		/// <summary>
		/// creates a text File
		/// </summary>
		/// <returns></returns>
		public string CreateFileName(string name)
		{
			
			// get the number of stat.txt items in the directory 
			// and append a number to a name that coresponds with this 

			  DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
			  FileInfo[] files = di.GetFiles();
			  List<string> TextFiles = new List<string>();

			   //  if the filename already exists create add it to the list of files.
			   //  we use this value to determine the number of files with the same name
				
				for (int i = 0; i < files.Length; i++)
				{
					if (files[i].ToString().Contains(".json"))					
						TextFiles.Add((files[i].ToString()));					
				}


			   // we want to get rid of characters like / \ < >, etc. windows cannot create files with these characters 
			   name = RemoveIllegalFileCreationCharacters(name);			
			   string NewFile =  name + "_" + TextFiles.Count.ToString() + ".txt"; // new file
				   
			return NewFile;
		}


		// remove illegal characters from the the inputed name of the file.
		private string RemoveIllegalFileCreationCharacters(string name)
		{
			string NewName = "";
			string[] IllegalCharacters = { @"\", @"/", ":", "?", '\u0022'.ToString(), "|", "<", ">", "." };  // '\u0022' = "


			for (int i = 0; i < name.Length - 1; i++)
			{
				for (int j = 0; j < IllegalCharacters.Length - 1; j++)
				{
					name.Replace(IllegalCharacters[j], "");
				}
			}

			NewName = name;

			return NewName;
		}
	}
}
