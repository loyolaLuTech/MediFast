using System;
using System.IO;
using System.Collections.Generic;

namespace IntroCS
{
	public class enter_physical : MediFastInterface
	{
		public enter_physical ()
		{
		}

		public int Go()
		{



			Console.WriteLine ("First name: ");
			Console.ReadLine ();
			Console.WriteLine ("Middle name: ");
			Console.ReadLine ();
			Console.WriteLine ("Last name: ");
			Console.ReadLine();
			Console.WriteLine ("Date of Birth: ");
			Console.ReadLine ();
			Console.WriteLine ("Pre-existing health concerns?");
			Console.ReadLine();
			Console.WriteLine ("Do you smoke?");
			Console.ReadLine ();
			Console.WriteLine ("Insurance Information: ");
			Console.ReadLine();
			Console.WriteLine("Provider: ");
			Console.ReadLine ();
			Console.WriteLine ("Policy #: ");
			Console.ReadLine();

			Console.WriteLine ("Thank you. Your form has been submitted.");

			return 0;
		}

		public static void ask_question(StreamReader reader)
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