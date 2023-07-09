using KidChecklist.Model;

namespace KidChecklist.View
{
    public class CheckBoxView : GraphicsView
    {
        public static readonly BindableProperty ItemProperty = BindableProperty.Create(
            nameof(Item),
            typeof(ChecklistItem),
            typeof(CheckBoxView),
            null,
            propertyChanged: ItemChanged);

        public ChecklistItem Item
        {
            get => (ChecklistItem)GetValue(ItemProperty);
            set => SetValue(ItemProperty, value);
        }

        public CheckBoxBehavior Behavior { get; init; }

        public CheckBoxView()
        {
            Behavior = new CheckBoxBehavior();
            Drawable = new CheckBoxDrawable();
            Behaviors.Add(Behavior);
        }

        private static void ItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var view = (CheckBoxView)bindable;
            ((CheckBoxDrawable)view.Drawable).Item = (ChecklistItem)newvalue;
            view.Behavior.Item = (ChecklistItem)newvalue;
            view.Invalidate();
        }

        public void Check(bool isChecked)
        {
            var drawable = (CheckBoxDrawable)Drawable;
            drawable.IsChecked = isChecked;
            Invalidate();
        }
    }
}
