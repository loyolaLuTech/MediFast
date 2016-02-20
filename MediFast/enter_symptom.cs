using System;
using System.IO;
using System.Collections.Generic;

namespace IntroCS
{
	public class enter_symptom : MediFastInterface
	{
		public enter_symptom ()
		{
			
		}

		public int Go()
		{
			StreamReader questionreader = FIO.OpenReader ("symptoms.txt");
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

