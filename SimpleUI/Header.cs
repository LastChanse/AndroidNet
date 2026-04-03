using Android.Content;
using Android.Content.Res;
using Android.Util;
using Android.Views;
using static SimpleUI.Utils;

namespace SimpleUI
{
    public class Header : RelativeLayout
    {
        TextView header;
        TextView subheader;
        ImageView headerImage;
        Button headerButton;
        RelativeLayout box;
        Context? headerContext;

        public Header(Context? context, IAttributeSet? attrs) : base(context, attrs)
        {
            // Контекст сохраняем
            headerContext = context;

            // Получаем кастомные атрибуты
            var custom_attrs = headerContext.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.Header, 0, 0);

            // Выбираем макет
            ChoseLayout(custom_attrs);
            // Тень при белой теме
            ShadowController();
        }

        // Метод управления тенью
        void ShadowController()
        {
            int theme_color = headerContext.Resources.GetColor(Resource.Color.theme_color, headerContext.Theme);
            if (theme_color < -100) {
            } else
            {
                box = FindViewById<RelativeLayout>(Resource.Id.box);
                box.Elevation = PxToDp(headerContext, 36);
            }
        }

        // Метод выбора макета в зависимости от полученых атрибутов
        void ChoseLayout(TypedArray custom_attrs)
        {
            var header_text = custom_attrs.GetString(Resource.Styleable.Header_headerText);
            var subheader_text = custom_attrs.GetString(Resource.Styleable.Header_subheaderText);
            var image = custom_attrs.GetResourceId(Resource.Styleable.Header_image, Resource.Drawable.default_img);
            
            if (subheader_text == null)
                HeaderMinimal(custom_attrs, header_text, image);
            else
                HeaderStandart(custom_attrs, header_text, subheader_text, image);
        }

        // Метод отрисовки макета с заголовком, подзаголовком и изображением
        void HeaderStandart(TypedArray custom_attrs, String header_text, String subheader_text, int image)
        {
            // Загружаем стандартный макет
            var inflater = (LayoutInflater)headerContext.GetSystemService(Context.LayoutInflaterService);
            inflater.Inflate(Resource.Layout.header_layout, this, true);

            // Получаем элементы макета
            header = FindViewById<TextView>(Resource.Id.headerText);
            subheader = FindViewById<TextView>(Resource.Id.subheaderText);
            headerImage = FindViewById<ImageView>(Resource.Id.headerImage);


            // Применяем атрибуты
            header.Text = header_text != null ? header_text : "Header";
            subheader.Text = subheader_text != null ? subheader_text : "Subheader";
            headerImage.SetImageResource(image);
        }

        // Метод отрисовки макета с заголовком и изображением
        void HeaderMinimal(TypedArray custom_attrs, String header_text, int image)
        {
            // Загружаем минимальный макет
            var inflater = (LayoutInflater)headerContext.GetSystemService(Context.LayoutInflaterService);
            inflater.Inflate(Resource.Layout.header_minimal_layout, this, true);

            // Получаем элементы макета
            header = FindViewById<TextView>(Resource.Id.headerText);
            headerImage = FindViewById<ImageView>(Resource.Id.headerImage);


            // Применяем атрибуты
            header.Text = header_text != null ? header_text : "Header";
            headerImage.SetImageResource(image);
        }

        // Метод отрисовки макета с заголовком, подзаголовком, изображением и кнопкой
        void HeaderMaximal()
        {

        }
    }
}