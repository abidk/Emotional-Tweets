using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace EmotionalTweets
{
	[Activity (Label = "Tweets")]
	public class TweetsActivity : Activity
	{
		public const string SEARCH_TEXT_KEY = "search_text_key";

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Tweets);

			string searchText = Intent.GetStringExtra (SEARCH_TEXT_KEY) ?? null;

			var search = FindViewById<TextView> (Resource.Id.textView1);
			search.Text = searchText;
		}

	}
}


