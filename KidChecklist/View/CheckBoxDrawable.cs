namespace KidChecklist.View
{
    public class CheckBoxDrawable : IDrawable
    {
        public bool IsChecked { get; set; }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            App.Current.Resources.TryGetValue("CheckBoxSize", out var sizeObj);
            var size = (int)sizeObj;

            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 6;
            if (IsChecked)
            {
                canvas.DrawLine(10, 10, size - 10, size - 10);
                canvas.DrawLine(size - 10, 10, 10, size - 10);
            }

            canvas.DrawRoundedRectangle(10, 10, size - 10, size - 10, 10);
        }
    }
}
