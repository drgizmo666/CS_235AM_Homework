using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;

namespace RiddleMeThis
{
	[Activity (Label = "Riddle Me This", MainLauncher = true, Icon = "@mipmap/icon", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
	public class MainActivity : Activity
	{
		public int riddleCount;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.answerButton);
			var answerEditText = FindViewById<EditText> (Resource.Id.answerEditText);
			
			button.Click += delegate {
				var showAnswer = new Intent(this, typeof(AnswerActivity)); 
				showAnswer.PutExtra("answerNum", riddleCount);
				showAnswer.PutExtra("answerText", answerEditText.Text);
				StartActivity(showAnswer);
			};
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			//Riddles riddles = new Riddles ();
			RiddleMaster riddles = new RiddleMaster("StuffandThings");

			var riddleTextView = FindViewById<TextView> (Resource.Id.riddleTextView);
			var correctTextView = FindViewById<TextView> (Resource.Id.CorrectTextView);
			var wrongTextView = FindViewById<TextView> (Resource.Id.wrongTextView);
			var answerEditText = FindViewById<EditText> (Resource.Id.answerEditText);

			riddleCount = Intent.GetIntExtra ("riddleNum", 0);
			answerEditText.Text	= "";

			if (riddles.SaveScore.Count == 0) {
				riddles.updateScore (0, 0);
			} else {
				correctTextView.Text = riddles.GetCorrect ().ToString ();
				wrongTextView.Text = riddles.GetWrong ().ToString ();
			}


			if (riddleCount <= 4) {
				riddleTextView.Text = riddles.GetRiddle (riddleCount);

			} else {
				riddleCount = 0;
				riddleTextView.Text = riddles.GetRiddle (riddleCount);
			}
		}

		protected override void OnNewIntent (Intent intent)
		{
			base.OnNewIntent (intent);

			Intent = intent;
		}
	}
}


