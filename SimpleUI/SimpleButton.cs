using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Views;
using Java.Lang;
using System.Reflection;

namespace SimpleUI
{
    public class SimpleButton : RelativeLayout
    {
        Button button;
        public SimpleButton(Context? context, IAttributeSet? attrs) : base(context, attrs)
        {
            // Загружаем макет кнопки
            var inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            inflater.Inflate(Resource.Layout.button_layout, this, true);

            // Получаем кастомные атрибуты
            var custom_attrs = context.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.SimpleButton, 0, 0);

            var functionName = custom_attrs.GetString(Resource.Styleable.SimpleButton_onClick);
            var buttonText = custom_attrs.GetString(Resource.Styleable.SimpleButton_buttonText);

            buttonText = (buttonText == null) ? "Button" : buttonText;
            functionName = (functionName == null) ? "undefined" : functionName;
            MethodInfo functionOnClick = context.GetType().GetMethod(functionName);

            button = FindViewById<Button>(Resource.Id.button);
            button.Text = buttonText;
            button.Touch += (sender, e) =>
            {
                // Изменение фона при касании кнопки c посощью изменения параметра Selected и background...xml
                button.Selected = button.Selected?false:true;
                // Действие при нажатии кнопки
                if (functionOnClick != null)
                    functionOnClick.Invoke(button, null);
            };
            


        }
    }
}
