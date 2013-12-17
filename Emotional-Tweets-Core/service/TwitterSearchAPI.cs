using System;
using System.Collections.Generic;
using Spring.Social.Twitter.Api;

namespace service.EmotionalTweetsCore
{
	public interface TwitterSearchAPI
	{
		IList<Tweet> search(string text);
	}
}

