using System;
using EmotionalTweetsCore;

namespace EmotionalTweets
{
	public class TweetItem : Java.Lang.Object
	{
		public Tweet Tweet { get; set; }
		public SentimentResult Sentiment { get; set; }
	}
}

