using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using service.EmotionalTweetsCore;
using System.Collections.Generic;
using EmotionalTweetsCore;
using Android.Text.Format;

namespace EmotionalTweets
{
	public class TweetAdapter : BaseAdapter
	{
		private IList<TweetItem> _items;
		private Context _context;

		public TweetAdapter(Context context, IList<TweetItem> items)
		{
			_context = context;
			_items = items;
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return _items[position];
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			var itemView = convertView;

			if (itemView == null) 
			{
				var layoutInflater = (LayoutInflater)_context.GetSystemService(Context.LayoutInflaterService);
				itemView = layoutInflater.Inflate(Resource.Layout.list_item_tweet, parent, false);
			}

			var item = _items[position];


			var name = itemView.FindViewById<TextView>(Resource.Id.tweet_screenname);
			name.Text = "@" + item.tweet.ScreenName;

			var text = itemView.FindViewById<TextView>(Resource.Id.tweet_text);
			text.Text = item.tweet.Text;


			var time = itemView.FindViewById<TextView>(Resource.Id.tweet_time);
			time.Text = DateUtils.GetRelativeTimeSpanString(item.tweet.CreatedDate.ToFileTime());

			return itemView;
		}

		public override int Count {
			get {
				return _items.Count;
			}
		}
	}
}


