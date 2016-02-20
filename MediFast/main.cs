using System;
using System.IO;
using System.Collections.Generic;

namespace IntroCS
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Thank you for using Medifast!");
			List <string> service_choices = new List<string> ();
			service_choices.Add ("a Symptoms");
			service_choices.Add ("b Doctors");
			service_choices.Add ("c Health Services");
			service_choices.Add ("d Physical");
			service_choices.Add ("e Uber");


			Question services = new Question ("What service would you like to use?", service_choices);
			string service_response = ask_question (services);

			if (service_response == "a") {
				enter_symptom symptom1 = new enter_symptom ();
				int symptom_score = symptom1.Go ();

				Console.WriteLine ("You appear to have: ");
				Console.WriteLine ("Common Cold");
				Console.WriteLine ();
				Console.WriteLine ("You should: ");
				Console.WriteLine ("Drink Fluids,");
				Console.WriteLine ("Rest");
				Console.WriteLine ();
				Console.WriteLine ("Should Symptoms Persist: ");
				Console.WriteLine ("Visit Health Center at: \n (555)555-555 \n 1234 Road Street \n 60660 Chicago, IL \n 3.2 miles away");
				Console.ReadKey ();
			}

			else if (service_response == "b"){
				enter_doctor doctor1 = new enter_doctor ();
				int doctor_score = doctor1.Go ();
			}

			else if (service_response == "c"){
				enter_health_services services1 = new enter_health_services ();
				int services_score = services1.Go ();
			}

			else if (service_response == "d"){
				enter_physical physical1 = new enter_physical ();
				int physical_score = physical1.Go();
			}

			else if (service_response == "e"){
				
			}

		}

		public static string ask_question (Question one)
		{
			one.Print ();
			string answer = UI.PromptLine ("Your answer: ");
			while (answer.Length < 1) {
				answer = UI.PromptLine ("Invalid, Try again: ");
			}
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
