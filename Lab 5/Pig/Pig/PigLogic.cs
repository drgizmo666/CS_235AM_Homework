using System;

namespace Pig
{
	public class PigLogic
	{
		public class Player
		{
			public string name { get; set;}
			public int score { get; set;}
		}

		Random d6 = new Random();

		int tempScore;

		Player  p1 = new Player();
		Player p2 = new Player();

		public PigLogic ()
		{
		}

		public int getNumber()
		{
			int roll = d6.Next (1, 7);

			return roll;
		}

		public int trackTempScore(int num)
		{
			tempScore += num;

			return tempScore;
		}

		public void emptyTempScore()
		{
			tempScore = 0;
		}

		public string showTempScore()
		{
			return tempScore.ToString();
		}

		public void saveScore(string turn)
		{
			if (turn == "p1") {
				p1.score += tempScore;
				emptyTempScore ();
			} else {
				p2.score += tempScore;
				emptyTempScore ();
			}
		}

		public string switchPlayer(string Turn)
		{
			if (Turn == "p1") {
				return "p2";
			} else {
				return "p1";
			}
		}

		public void createPlayers(string player1, string player2)
		{
			//create player 1
			p1.name = player1;
			p1.score = 0;
			//create player 2;
			p2.name = player2;
			p2.score = 0;
		}

		public string getPlayer1Name()
		{
			return p1.name;
		}

		public string getPlayer2Name()
		{
			return p2.name;
		}

		public int getP1Score()
		{
			return p1.score;
		}

		public int getP2Score()
		{
			return p2.score;
		}

		public bool checkWin()
		{
			if (p1.score >= 100 || p2.score >= 100) 
				return true;
			else
				return false;

		}

		public string winnerHamDinner()
		{
			if (p1.score > p2.score)
				return p1.name + " is the winner";
			else
				return p2.name + " is the winner";
		}
	}
}

