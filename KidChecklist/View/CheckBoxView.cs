using KidChecklist.Model;

namespace KidChecklist.View
{
    public class CheckBoxView : GraphicsView
    {
        public void Check(bool isChecked)
        {
            var drawable = (CheckBoxDrawable)Drawable;
            drawable.IsChecked = isChecked;
            Invalidate();
        }
    }
}
