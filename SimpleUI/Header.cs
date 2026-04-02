using Android.Content;
using Android.Content.Res;
using Android.Util;
using Android.Views;
using static SimpleUI.Utils;

namespace SimpleUI
{
    public class Header : RelativeLayout
    {
        private TextView header;
        private TextView subheader;
        private ImageView headerImage;
        private RelativeLayout box;
        private Context? _context;

        public Header(Context? context, IAttributeSet? attrs) : base(context, attrs)
        {
            // Контекст сохраняем
            _context = context;

            // Получаем кастомные атрибуты
            TypedArray custom_attrs = _context.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.Header, 0, 0);

            // Выбираем макет
            ChoseLayout(custom_attrs);

        }

        // Метод управления тенью
        private void ShadowController(TypedArray custom_attrs)
        {
            int theme_color = _context.Resources.GetColor(Resource.Color.theme_color, _context.Theme);
            if (theme_color < -100) {
            } else
            {
                box = FindViewById<RelativeLayout>(Resource.Id.box);
                box.Elevation = PxToDp(_context, 36);
            }
        }

        // Метод выбора макета в зависимости от полученых атрибутов
        private void ChoseLayout(TypedArray custom_attrs)
        {
            String header_text = custom_attrs.GetString(Resource.Styleable.Header_headerText);
            String subheader_text = custom_attrs.GetString(Resource.Styleable.Header_subheaderText);
            int image = custom_attrs.GetResourceId(Resource.Styleable.Header_image, Resource.Drawable.default_img);
            
            if (subheader_text == null)
                HeaderMinimal(custom_attrs, header_text, image);
            else
                HeaderStandart(custom_attrs, header_text, subheader_text, image);
        }

        // Метод отрисовки макета с заголовком, подзаголовком и изображением
        private void HeaderStandart(TypedArray custom_attrs, String header_text, String subheader_text, int image)
        {
            // Загружаем стандартный макет
            LayoutInflater inflater;
            inflater = (LayoutInflater)_context.GetSystemService(Context.LayoutInflaterService);
            inflater.Inflate(Resource.Layout.header_layout, this, true);

            // Получаем элементы макета
            header = FindViewById<TextView>(Resource.Id.headerText);
            subheader = FindViewById<TextView>(Resource.Id.subheaderText);
            headerImage = FindViewById<ImageView>(Resource.Id.headerImage);

            ShadowController(custom_attrs);

            // Применяем атрибуты
            header.Text = header_text != null ? header_text : "Header";
            subheader.Text = subheader_text != null ? subheader_text : "Subheader";
            headerImage.SetImageResource(image);
        }

        // Метод отрисовки макета с заголовком и изображением
        private void HeaderMinimal(TypedArray custom_attrs, String header_text, int image)
        {
            // Загружаем минимальный макет
            LayoutInflater inflater;
            inflater = (LayoutInflater)_context.GetSystemService(Context.LayoutInflaterService);
            inflater.Inflate(Resource.Layout.header_minimal_layout, this, true);

            // Получаем элементы макета
            header = FindViewById<TextView>(Resource.Id.headerText);
            headerImage = FindViewById<ImageView>(Resource.Id.headerImage);

            ShadowController(custom_attrs);

            // Применяем атрибуты
            header.Text = header_text != null ? header_text : "Header";
            headerImage.SetImageResource(image);
        }

        // Метод отрисовки макета с заголовком, подзаголовком, изображением и кнопкой
        private void HeaderMaximal()
        {

        }
    }
}