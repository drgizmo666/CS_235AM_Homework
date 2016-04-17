using System;
using System.Collections.Generic;

namespace RiddleMeThis
{
		public class Riddle
		{
			public string riddle { get; set; }
			public string answer { get; set; }
		}

		public class RiddleMaster
		{
			private List<Riddle> riddles = new List<Riddle>();
			public List<Riddle> Riddles { get { return riddles; } }

			public int riddleNum;
			public int correctScore;
			public int wrongScore;
			//default constructor
			public RiddleMaster ()
			{
			}

			//Temporary will be replaced latter with a database
			public RiddleMaster(string mrNobody)
			{
				riddles.Add (new Riddle (){ 
					riddle = "When you have me, you feel like sharing me but if you do share me, you don't have me \n what am I?", 
					answer = "secret" });
				riddles.Add (new Riddle (){ 
					riddle = "I am the beginning of eternity, the end of time and space, the beginning of the end and the end of every space. \n What am I", 
					answer = "e"});
				riddles.Add (new Riddle () {
					riddle = "I have a bed, but I do not sleep, I have a mouth but I don't eat. You hear me whisper, but I never talk. You can see me run, yet I never walk. \n What am I?",
					answer = "river"});
				riddles.Add (new Riddle(){
					riddle = "I have keys but no locks. I have a space but no room. You can enter but can't go outside \n what am I?",
					answer = "keyboard"});
				riddles.Add (new Riddle () {
					riddle = "What can bring back the dead; make us cry, make us laugh, make us young; born in an instant yet lasts a life time?",
					answer = "memories"});

			}
			
			public string GetRiddle (int riddleNum)
			{
				return riddles [riddleNum].riddle;
			}

			public string GetAnswer (int answerNum)
			{
				return riddles [answerNum].answer;
			}

			public string checkAnswer (string guess)
			{
				if (riddles [riddleNum].answer == guess.ToLower ()) {	
					correctScore += 1;
					return "Correct";

				} 
				else 
				{
					wrongScore += 1;
					return "Wrong";
				}
			}

			public string showScore()
			{
				string scoreString = correctScore.ToString () + " correct / " + wrongScore.ToString () + " Wrong"; 
				return scoreString;
			}
	}
}