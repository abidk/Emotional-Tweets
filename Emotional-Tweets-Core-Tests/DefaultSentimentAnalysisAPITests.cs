using System;
using System.Collections.Generic;
using NUnit.Framework;
using service.EmotionalTweetsCore;
using EmotionalTweetsCore;

namespace EmotionalTweetsCoreTests
{
	[TestFixture]
	public class DefaultSentimentAnalysisAPITests
	{
		DefaultSentimentAnalysisAPI api;

		[SetUp]
		public void setUp()
		{
			api = new DefaultSentimentAnalysisAPI();
		}

		[Test]
		public void ShouldReturnAPositiveNumberWhenHappyText()
		{
			var result = api.analyse("happy :)");

			Assert.IsTrue( result.Value > 0 );
		}

		[Test]
		public void ShouldReturnANegaticeNumberWhenSadText()
		{
			var result = api.analyse("sad :(");

			Assert.IsTrue( result.Value < 0 );
		}
	}
}

