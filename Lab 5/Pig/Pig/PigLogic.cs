using System;

namespace Pig
{
	public class PigLogic
	{
		Random d6 = new Random();
		int tempScore;

		int player1Score;
		int player2Score;

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

		public int saveScore(int score, string turn)
		{
			if (turn == "p1") {
				player1Score += score;
				emptyTempScore ();
				return player1Score;
			} else {
				player2Score += score;
				emptyTempScore ();
				return player2Score;
			}
		}
	}
}

