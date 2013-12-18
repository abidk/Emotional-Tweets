using System;
using System.Collections.Generic;
using EmotionalTweetsCore;

namespace service.EmotionalTweetsCore
{
	public interface TwitterSearchAPI
	{
		IList<Tweet> search(string text);
	}
}

