using System;

namespace RiddleMeThis
{
	public class Riddles
	{
		private string riddleOne = "When you have me, you feel like sharing me but if you do share me, you don't have me what am I?";
		private string answerOne = "Secret";
		private string riddleTwo = "I am the beginning of eternity, the end of time and space, the beginning of the end and the end of every space. What am I?";
		private string answerTwo = "e";
		private string riddleThree = "I have a bed, but I do not sleep, I have a mouth but I don't eat. You hear me whisper, but I never talk. You can see me run, yet I never walk. What am I?";
		private string answerThree = "river";
		private string riddleFour = "I have keys but no locks. I have a space but no room. You can enter but can't go outside what am I?";
		private string answerFour = "keyboard";
		private string riddleFive = "What can bring back the dead; make us cry, make us laugh, make us young; born in an instant yet lasts a life time?";
		private string answerFive = "memories";

		public Riddles ()
		{
		}

		public string ShowRiddles (int riddleNum)
		{
			switch (riddleNum) 
			{
			case (1):
				return riddleOne;
				break;
			case(2):
				return riddleTwo;
				break;
			case(3):
				return riddleThree;
				break;
			case(4):
				return riddleFour;
				break;
			case(5):
				return riddleFive;
				break;
			default:
				return riddleOne;
				break;
			}
		}
	}
}

