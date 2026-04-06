using Android.Content;

namespace SimpleUI
{
    public static class Utils
    {
        public static float DpToPx(Context? context, float px)
        {
            var density = context.Resources.DisplayMetrics.Density;
            return (px * density);
        }
    }
}
