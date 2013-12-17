using NUnit.Framework;
using System;
using service.EmotionalTweetsCore;
using System.Collections.Generic;
using Spring.Social.Twitter.Api;

namespace EmotionalTweetsCoreTests
{
	[TestFixture ()]
	public class DefaultTwitterSearchAPITests
	{
		[Test ()]
		public void TestCase ()
		{
			var api = new DefaultTwitterSearchAPI();
			IList<Tweet> tweets = api.search("Test");
			Assert.AreEqual(15, tweets.Count);
		}
	}
}

