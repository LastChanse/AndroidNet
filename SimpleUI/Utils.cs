using Android.Content;

namespace SimpleUI
{
    public static class Utils
    {
        // Конвертация пикселей в dp для адаптации к плотности экрана
        public static float PxToDp(Context? _context, float px)
        {
            float density = _context.Resources.DisplayMetrics.Density;
            return (px / density);
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
        public static bool SystemThemeIsDark(Context? _context)
        {
            // При задании белого цвета #FFF атрибут равен -1, при чёрном -16.... большое число
            int theme_color = _context.Resources.GetColor(Resource.Color.theme_color, _context.Theme);
            return theme_color < -100;
        }
    }
}
