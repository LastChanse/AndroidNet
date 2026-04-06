using Android.Content;

namespace SimpleUI
{
    public static class Utils
    {
        // Конвертация пикселей в dp для адаптации к плотности экрана
        public static float DpToPx(Context? context, float px)
        {
            var density = context.Resources.DisplayMetrics.Density;
            return (px * density);
        }
    }
}
