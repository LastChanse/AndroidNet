using AndroidX.Collection;
using AndroidX.Startup;

namespace SimpleUI
{
    class ItemService
    {
        List<ItemData> items;
        public List<ItemData> Items
        {
            get => items;
            set => items = value;
        }

        public ItemService()
        {
            Initialize();
        }

        void Initialize()
        {
            items = new List<ItemData>() { 
                new ItemData(1, "Задача 1", "Создать макет"),
                new ItemData(2, "Задача 2", "Внести 2 правки"), 
                new ItemData(3, "Задача 3", "Реализовать доп. функционал"),
                new ItemData(4, "Задача 4", "Описание"),
                new ItemData(5, "Задача 5", "Описание"),
                new ItemData(6, "Задача 6", "Описание"),
                new ItemData(7, "Задача 7", "Описание"),
                new ItemData(8, "Задача 8", "Описание")
            };
        }
    }
}
