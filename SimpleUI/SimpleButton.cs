using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Views;

namespace SimpleUI
{
    public class SimpleButton : RelativeLayout
    {
        Button button;
        public SimpleButton(Context? context, IAttributeSet? attrs) : base(context, attrs)
        {
            // Загружаем макет кнопки
            LayoutInflater inflater;
            inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            inflater.Inflate(Resource.Layout.button_layout, this, true);
            
            button = FindViewById<Button>(Resource.Id.button);
            button.Touch += (sender, e) =>
            {
                button.Selected = button.Selected?false:true;
            };

        }
    }
}
