
using Android.Graphics.Drawables;

namespace SimpleUI
{
    public class ItemData
    {
        public int Id;
        public string Title;
        public string Description;
        public Drawable icon;
        public bool closeButtonVisible = false;
        public Action? closeButtonOnClick;

        public ItemData(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public ItemData(int id, string title, string description, Drawable icon)
        {
            Id = id;
            Title = title;
            Description = description;
            this.icon = icon;
        }

        public ItemData(int id, string title, string description, Drawable icon, bool closeButtonVisible)
        {
            Id = id;
            Title = title;
            Description = description;
            this.icon = icon;
            this.closeButtonVisible = closeButtonVisible;
        }

        public ItemData(int id, string title, string description, Drawable icon, bool closeButtonVisible, Action? closeButtonOnClick)
        {
            Id = id;
            Title = title;
            Description = description;
            this.icon = icon;
            this.closeButtonVisible = closeButtonVisible;
            this.closeButtonOnClick = closeButtonOnClick;
        }
    }
}
