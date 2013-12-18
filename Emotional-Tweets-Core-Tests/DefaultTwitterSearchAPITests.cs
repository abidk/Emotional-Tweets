using System;
using System.Collections.Generic;
using NUnit.Framework;
using service.EmotionalTweetsCore;
using EmotionalTweetsCore;

namespace EmotionalTweetsCoreTests
{
	[TestFixture]
	public class DefaultTwitterSearchAPITests
	{
		DefaultTwitterSearchAPI api;

		[SetUp]
		public void setUp()
		{
			api = new DefaultTwitterSearchAPI();
		}

		[Test]
		public void SearchShouldReturnTweetResults()
		{
			IList<Tweet> tweets = api.search("This is a test");

			Assert.IsTrue(tweets.Count > 0);
		}
	}
}

