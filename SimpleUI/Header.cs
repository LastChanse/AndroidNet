using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;

namespace SimpleUI
{
    public class Header : LinearLayout
    {

        public Header(Context? context, IAttributeSet? attrs) : base(context, attrs)
        {
            LayoutInflater inflater;
            inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            inflater.Inflate(Resource.Layout.Header2, this, true);
        }
    }
}