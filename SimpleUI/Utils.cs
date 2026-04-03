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

        // Если тема системы тёмная то вернёт true
        /**
         * Для работы требует наличия values и values-night c colors.xml
         * В первой папке в файле прописан белый цвет для атрибута theme_color
         * В второй чёрный
         * Пример для тёмной темы:
	        <!-- Индикатор текущей темы -->
	        <color name="theme_color">#000</color>
         */
        public static bool SystemThemeIsDark(Context? context)
        {
            // При задании белого цвета #FFF атрибут равен -1, при чёрном -16.... большое число
            var theme_color = context.Resources.GetColor(Resource.Color.theme_color, context.Theme);
            return theme_color < -100;
        }
    }
}
