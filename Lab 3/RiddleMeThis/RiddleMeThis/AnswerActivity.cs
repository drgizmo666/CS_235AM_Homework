
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RiddleMeThis
{
	[Activity (Label = "Riddle Me This", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]			
	public class AnswerActivity : Activity
	{
		private int answerNum;
		private int riddleNum = 1;
		private string answerText;
		private int correct;
		private int wrong;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.Answer);

			Button showNextRiddle = FindViewById<Button> (Resource.Id.nextRiddleButton);

			showNextRiddle.Click += delegate {
				var showRiddle = new Intent (this, typeof(MainActivity));
				showRiddle.PutExtra ("riddleNum", riddleNum);
				riddleNum++;
				StartActivity (showRiddle);
			};


		}

		protected override void OnResume ()
		{
			base.OnResume ();

			answerNum = Intent.GetIntExtra ("answerNum", 0);
			answerText = Intent.GetStringExtra ("answerText").ToLower();

			//Riddles riddles = new Riddles ();
			RiddleMaster riddles = new RiddleMaster("StuffandThings");
			var answerTextView = FindViewById<TextView> (Resource.Id.answerTextView);
			var feedback = FindViewById<TextView> (Resource.Id.feedbackTextView);

			answerTextView.Text = riddles.GetAnswer (answerNum);

			if (answerText == riddles.GetAnswer (answerNum)) {
				correct++;
				feedback.Text = "Correct \n the answer is";
			} else {
				wrong++;
				feedback.Text = "Wrong \n the answer is";
			}

			riddles.updateScore (correct, wrong);



		}

		protected override void OnNewIntent (Intent intent)
		{
			base.OnNewIntent (intent);

			Intent = intent;
		}
	}
		

}

