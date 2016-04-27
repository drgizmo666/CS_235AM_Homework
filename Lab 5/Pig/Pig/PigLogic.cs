using System;

namespace Pig
{
	public class PigLogic
	{
		Random d6 = new Random();

		public PigLogic ()
		{
		}

		public int getNumber()
		{
			int roll = d6.Next (1, 7);

			return roll;
		}
	}
}

