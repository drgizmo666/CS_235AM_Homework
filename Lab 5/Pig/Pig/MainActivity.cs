using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace Pig
{
	[Activity (Label = "Pig", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		public PigLogic oink = new PigLogic ();
		public string whosTurn = "p1";

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);


			// Get our button from the layout resource,
			// and attach an event to it
			Button rollButton = FindViewById<Button> (Resource.Id.rollDiceButton);
			Button scoreButton = FindViewById<Button> (Resource.Id.endTurnButton);
			var tempScoreText = FindViewById<TextView> (Resource.Id.tempScoreTextView);
			var player1Score = FindViewById<TextView> (Resource.Id.player1ScoreTextView);
			var player2Score = FindViewById<TextView> (Resource.Id.player2ScoreTextView);
			var outputTextView = FindViewById<TextView> (Resource.Id.outputTextView);

			rollButton.Click += delegate {
				setImageView();
			};

			scoreButton.Click += delegate {
				if(whosTurn == "p1")
				{
					player1Score.Text = oink.saveScore(Convert.ToInt32(tempScoreText.Text), whosTurn).ToString();
					tempScoreText.Text = oink.showTempScore();
					outputTextView.Text = "Player 2 Turn";
					whosTurn = "p2";
				}
				else{
					player2Score.Text = oink.saveScore(Convert.ToInt32(tempScoreText.Text), whosTurn).ToString();
					tempScoreText.Text = oink.showTempScore();
					outputTextView.Text = "Player 1 Turn";
					whosTurn = "p1";
				}
			};
		}

		public void setImageView()
		{
			var tempScoreText = FindViewById<TextView> (Resource.Id.tempScoreTextView);
			var diceImageView = FindViewById<ImageView> (Resource.Id.DiceImageView);
			var numRolled = oink.getNumber ();

			switch (numRolled) {
			case(1):
					diceImageView.SetImageResource (Resource.Drawable.one);
					oink.emptyTempScore ();
					tempScoreText.Text = oink.showTempScore();
					break;
			case(2):
					diceImageView.SetImageResource (Resource.Drawable.two);
					oink.trackTempScore (numRolled);
					tempScoreText.Text = oink.showTempScore();
					break;
				case(3):
					diceImageView.SetImageResource (Resource.Drawable.three);
					oink.trackTempScore (numRolled);
					tempScoreText.Text = oink.showTempScore();
					break;
				case(4):
					diceImageView.SetImageResource (Resource.Drawable.four);
					oink.trackTempScore (numRolled);
					tempScoreText.Text =  oink.showTempScore();
					break;
				case(5):
					diceImageView.SetImageResource (Resource.Drawable.five);
					oink.trackTempScore (numRolled);
					tempScoreText.Text =  oink.showTempScore();
					break;
				case(6):
					diceImageView.SetImageResource (Resource.Drawable.six);
					oink.trackTempScore (numRolled);
					tempScoreText.Text =  oink.showTempScore();
					break;
				default:
					diceImageView.SetImageResource (Resource.Drawable.one);
					tempScoreText.Text = "You Rolled a " + numRolled.ToString () + " You Hacker";
					break;
			}
		}
	}
}


