using System;

namespace EmotionalTweetsCore
{
	public interface SentimentAnalysisAPI
	{
		SentimentResult analyse(string text);
	}
}

