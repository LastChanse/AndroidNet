using Android.Content;
using Android.Util;

namespace SimpleUI
{
    public class SimpleButton : Button
    {
        public SimpleButton(Context? context, IAttributeSet? attrs) : base(context, attrs)
        {
            var padding = (int)Utils.DpToPx(context, 10);
            SetPadding(padding, padding, padding, padding);
            SetBackgroundResource(Resource.Drawable.background_button_component);
            SetTextColor(context.Resources.GetColor(Resource.Color.button, context.Theme));

            Touch += (sender, e) =>
            {
                // Изменение фона при касании кнопки c посощью изменения параметра Selected и background...xml
                Selected = Selected ? false : true;
                e.Handled = true;
            };
        }
    }
}
