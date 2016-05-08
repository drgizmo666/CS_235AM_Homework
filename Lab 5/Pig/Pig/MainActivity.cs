using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Views;

namespace Pig
{
	[Activity (Label = "Pig", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		public PigLogic oink = new PigLogic ();
		public string whosTurn = "p1";
		public int numRolled;

		Button rollButton;
		Button scoreButton;
		Button newGameButton;
		EditText player1Name;
		EditText player2Name;
		TextView tempScoreText;
		TextView player1Score;
		TextView player2Score;
		TextView outputTextView;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);


			// Get our button from the layout resource,
			// and attach an event to it
			rollButton = FindViewById<Button> (Resource.Id.rollDiceButton);
			scoreButton = FindViewById<Button> (Resource.Id.endTurnButton);
			newGameButton = FindViewById<Button> (Resource.Id.newGameButton);
			player1Name = FindViewById<EditText> (Resource.Id.player1EditText);
			player2Name = FindViewById<EditText> (Resource.Id.player2EditText);
			tempScoreText = FindViewById<TextView> (Resource.Id.tempScoreTextView);
			player1Score = FindViewById<TextView> (Resource.Id.player1ScoreTextView);
			player2Score = FindViewById<TextView> (Resource.Id.player2ScoreTextView);
			outputTextView = FindViewById<TextView> (Resource.Id.outputTextView);

			rollButton.Visibility = ViewStates.Invisible;
			scoreButton.Visibility = ViewStates.Invisible;

			newGameButton.Click += delegate {
				if(player1Name.Text=="" || player2Name.Text=="")
				{
					oink.createPlayers("Beavis", "Butt-Head");
					player1Name.Text = oink.getPlayer1Name();
					player2Name.Text = oink.getPlayer2Name();
					outputTextView.Text = oink.getPlayer1Name() + "'s turn";
					player1Name.Enabled = false;
					player2Name.Enabled = false;
					rollButton.Visibility = ViewStates.Visible;
					scoreButton.Visibility = ViewStates.Visible;
					newGameButton.Visibility = ViewStates.Invisible;
				}
				else
				{
					oink.createPlayers(player1Name.Text, player2Name.Text);
					player1Name.Text = oink.getPlayer1Name();
					player2Name.Text = oink.getPlayer2Name();
					outputTextView.Text = oink.getPlayer1Name() + "'s turn";
					player1Name.Enabled = false;
					player2Name.Enabled = false;
					rollButton.Visibility = ViewStates.Visible;
					scoreButton.Visibility = ViewStates.Visible;
					newGameButton.Visibility = ViewStates.Invisible;
				}
				
			};

			rollButton.Click += delegate {
				numRolled = oink.getNumber();

				if(numRolled == 1)
				{
					Android.Widget.Toast.MakeText(this,
						"Sorry, you rolled a 1 and lost all your points earned during this turn.",
						Android.Widget.ToastLength.Short).Show();
					
					if(whosTurn == "p1")
					{
						whosTurn = "p2";
						outputTextView.Text = oink.getPlayer2Name() + "'s turn";
						setImageView();
					}
					else
					{
						whosTurn = "p1";
						outputTextView.Text = oink.getPlayer1Name() + "'s turn";
						setImageView();
					}
				}
				else{ setImageView(); }
			};

			scoreButton.Click += delegate {
				oink.saveScore(whosTurn);
				reDrawScreen();
				if(oink.checkWin())
					endGame();
				else{
					whosTurn = oink.switchPlayer(whosTurn);
					if(whosTurn == "p1")
						outputTextView.Text = oink.getPlayer1Name() + "'s turn";
					else
						outputTextView.Text = oink.getPlayer2Name() + "'s turn";
				}
					
			};
		}

		public void setImageView()
		{
			var diceImageView = FindViewById<ImageView> (Resource.Id.DiceImageView);
		
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

		public void endGame()
		{
			string p1Win = oink.getPlayer1Name() + "'s has got a 100 points, " + oink.getPlayer2Name() + " You have one more turn to win";
				
			if (whosTurn == "p1") {
				Android.Widget.Toast.MakeText (this,
					p1Win,
					Android.Widget.ToastLength.Short).Show ();
				whosTurn = oink.switchPlayer (whosTurn);
				reDrawScreen ();
			} else {
				outputTextView.Text = oink.winnerHamDinner ();
				resetGame ();
			}
		}

		public void reDrawScreen()
		{
			tempScoreText.Text = "0";
			player1Score.Text = oink.getP1Score ().ToString ();
			player2Score.Text = oink.getP2Score ().ToString ();

			if (whosTurn == "p1") {
				outputTextView.Text = oink.getPlayer1Name() + "'s turn";
			}
			else
				outputTextView.Text = oink.getPlayer2Name() + "'s turn";
		}

		public void resetGame()
		{
			player1Name.Enabled = true;
			player2Name.Enabled = true;
			rollButton.Visibility = ViewStates.Invisible;
			scoreButton.Visibility = ViewStates.Invisible;
			newGameButton.Visibility = ViewStates.Visible;

			player1Score.Text = "0";
			player2Score.Text = "0";

			whosTurn = "p1";
		}
	}
}


