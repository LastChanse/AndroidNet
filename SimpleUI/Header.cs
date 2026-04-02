using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Media;
using Android.Util;
using Android.Views;

namespace SimpleUI
{
    public class Header : LinearLayout
    {
        private TextView header;
        private TextView subheader;
        private ImageView headerImage;

        public Header(Context? context, IAttributeSet? attrs) : base(context, attrs)
        {
            // Загружаем макет
            LayoutInflater inflater;
            inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            inflater.Inflate(Resource.Layout.header_layout, this, true);

            // Получаем элементы макета
            header = FindViewById<TextView>(Resource.Id.headerText);
            subheader = FindViewById<TextView>(Resource.Id.subheaderText);
            headerImage = FindViewById<ImageView>(Resource.Id.headerImage);

            // Получаем атрибуты
            TypedArray custom_attrs = context.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.Header, 0,0);
            String header_text = custom_attrs.GetString(Resource.Styleable.Header_headerText);
            String subheader_text = custom_attrs.GetString(Resource.Styleable.Header_subheaderText);
            int image = custom_attrs.GetResourceId(Resource.Styleable.Header_image, Resource.Drawable.default_img);
            
            // Применяем атрибуты
            header.Text = header_text != null ? header_text : "Header";
            subheader.Text = subheader_text != null ? subheader_text : "Subeader";
            headerImage.SetImageResource(image);
        }
    }
}