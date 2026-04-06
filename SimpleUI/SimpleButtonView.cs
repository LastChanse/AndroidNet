using Android.Content;
using Android.Util;
using Android.Views;

namespace SimpleUI
{
    public class SimpleButtonView : Button
    {
        public SimpleButtonView(Context? context, IAttributeSet? attrs) : base(context, attrs)
        {
            if (Text != "X") {
                var padding = (int)Utils.DpToPx(context, 10);
                SetPadding(padding, padding, padding, padding);
                SetTextColor(context.Resources.GetColor(Resource.Color.button, context.Theme));
            }
            SetBackgroundResource(Resource.Drawable.background_button_component);

            Touch += (sender, e) =>
            {
                // Изменение фона при касании кнопки c посощью изменения параметра Selected и background...xml
                Selected = e.Event.Action == MotionEventActions.Up ? false : true;
                e.Handled = true;
            };
        }
    }
}
