using Android.App;
using Android.Widget;
using Android.OS;

namespace Pig
{
	[Activity (Label = "Pig", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		public PigLogic oink = new PigLogic ();

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);


			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.rollDiceButton);
			
			button.Click += delegate {
				setImageView();
			};
		}

		public void setImageView()
		{
			var outputText = FindViewById<TextView> (Resource.Id.outputTextView);
			var diceImageView = FindViewById<ImageView> (Resource.Id.DiceImageView);
			var numRolled = oink.getNumber ();

			switch (numRolled) {
				case(1):
					diceImageView.SetImageResource (Resource.Drawable.one);
					outputText.Text = "You rolled a one";
					break;
				case(2):
					diceImageView.SetImageResource (Resource.Drawable.two);
					outputText.Text = "You Rolled a Two";
					break;
				case(3):
					diceImageView.SetImageResource (Resource.Drawable.three);
					outputText.Text = "You Rolled a Three";
					break;
				case(4):
					diceImageView.SetImageResource (Resource.Drawable.four);
					outputText.Text = "You Rolled a Four";
					break;
				case(5):
					diceImageView.SetImageResource (Resource.Drawable.five);
					outputText.Text = "You Rolled a Five";
					break;
				case(6):
					diceImageView.SetImageResource (Resource.Drawable.six);
					outputText.Text = "You Rolled a Six";
					break;
				default:
					diceImageView.SetImageResource (Resource.Drawable.one);
					outputText.Text = "You Rolled a " + numRolled.ToString () + " You Hacker";
					break;
			}
		}
	}
}


