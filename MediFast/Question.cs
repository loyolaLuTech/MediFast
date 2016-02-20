using System;
using System.IO;
using System.Collections.Generic;

namespace IntroCS
{
	public class Question
	{
		const int CONSOLE_LENGTH = 80;
		private string question;
		private List<string> choices;

		public Question (string question, List<string> choices)
		{
			this.question = question;
			this.choices = choices;
		}

		public static string printlist (List<string> choices)
		{
			string multiple = "";
			foreach (string a in choices) {
				multiple += a + "\n";
			}
			return multiple;

		}

		public override string ToString ()
		{
			string toreturn = question;
			return toreturn;
		}

		public Question (StreamReader reader)
		{
			choices = new List<string> ();
			string line = reader.ReadLine ();
			int questionlength = line.Length;
			for (int i = 0; i < questionlength; i++) {
				if (line[i] == '.') {
					line.Insert(i, "\n");
				}
			}
			if (line.Trim ().Length > 0) {
				this.question = line + "\n";
				reader.ReadLine ();
			} else {
				string otherline = reader.ReadLine();
				int otherquestionlength = otherline.Length;
				for (int i = 0; i < questionlength; i++) {
					if (otherline[i] == '.') {
						otherline.Insert(i, "\n");
					}
				}
				this.question = otherline;
				reader.ReadLine ();
			}


			string newline = reader.ReadLine();

			while (newline.Length > 0) {
				choices.Add (newline);
				newline = reader.ReadLine();
				if (newline == null) {
					Console.WriteLine ();
					break;
				}
			}
			//reader.ReadLine ();


		}



		public List<char> Get_Choices ()
		{
			List<char> all_choices = new List<char> ();
			foreach (string a in choices) {
				char b = char.ToLower (a [0]);
				all_choices.Add (b);
			}
			return all_choices;
		}


		public void Print ()
		{
			OutputLines (ToString ());
			Console.WriteLine (printlist (choices));
			Console.WriteLine ();
		}

		public static void OutputLines(string toSplit, int lineLength = CONSOLE_LENGTH) {
			while (toSplit.Length > lineLength) {
				string output = toSplit.Substring (0, lineLength); // get next potential output line
				if (toSplit[lineLength] == ' ') { // if the next character in the line is a space ...
					if (lineLength == CONSOLE_LENGTH)
						Console.Write (output); // write the entire set of lineLength characters
					else
						Console.WriteLine (output);
					toSplit = toSplit.Substring(lineLength+1); // remove those plus the space
					continue; // and restart the loop
				}
				int spaceIndex = output.LastIndexOf (' '); // find the last space character before lineLength
				if (spaceIndex == -1) { // if none of those characters is a space ...
					if (lineLength == CONSOLE_LENGTH)
						Console.Write (output); // write the entire set of lineLength characters
					else
						Console.WriteLine (output);
					toSplit = toSplit.Substring (lineLength); // remove those characters
					continue;
				}
				Console.WriteLine(output.Substring (0, spaceIndex)); // print all of the characters before the last space
				toSplit = toSplit.Substring(spaceIndex+1); // and remove the printed characters plus the space
			}
			if (toSplit.Length == CONSOLE_LENGTH) // if there are exactly CONSOLE_LENGTH characters left to print
				Console.Write (toSplit); // print them without a following newline character
			else if (toSplit.Length > 0) // if there is something smaller left to print ...
				Console.WriteLine(toSplit); // print it
		}

		public static string ask_question (Question one)
		{
			one.Print ();
			string answer = UI.PromptLine ("Your answer: ");
			char letteranswer = char.ToLower (answer [0]);
			List<char> these_choices = one.Get_Choices ();
			int wrong_type = 0; 


			for (int i = 0; i < these_choices.Count; i++) {
				if (letteranswer == these_choices [i]) {
					wrong_type++;
				}
			}

			if (wrong_type != 1) {
				while (wrong_type != 1) {
					answer = UI.PromptLine ("That's not one of the options. Try again: ");
					letteranswer = char.ToLower (answer [0]);

					for (int i = 0; i < these_choices.Count; i++) {
						if (letteranswer == these_choices [i]) {
							wrong_type++;
						}
					}
				}
			}
			return answer;
		}
	}
}

