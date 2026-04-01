using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using static Android.Preferences.PreferenceActivity;

namespace SimpleUI
{
    public class Header : LinearLayout
    {
        private TextView header;
        private TextView subheader;

        public Header(Context? context, IAttributeSet? attrs) : base(context, attrs)
        {
            //header = FindViewById<TextView>(Resource.Id.headerText);

            LayoutInflater inflater;
            inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            inflater.Inflate(Resource.Layout.header_layout, this, true);
        }
    }
}