using System;
using System.IO;
using System.Collections.Generic;

namespace IntroCS
{
	public class enter_health_services : MediFastInterface
	{
		public enter_health_services ()
		{
		}

		public int Go()
		{
			Console.WriteLine ("Scanning your location...");
			Console.WriteLine ("Press any key to continue...");
			Console.ReadKey ();
			Console.WriteLine ();

			StreamReader questionreader = FIO.OpenReader ("search_health_services.txt");
			while (!questionreader.EndOfStream) {
				ask_question (questionreader);
			}
			return 0;

		}

		public static void ask_question(StreamReader reader)//reads questions in from the SAT question file
		{
			int correct = 0;

			Question one = new Question (reader);
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
		}
	}
}
	