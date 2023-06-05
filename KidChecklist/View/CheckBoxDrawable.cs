namespace KidChecklist.View
{
    public class CheckBoxDrawable : IDrawable
    {
        public bool IsChecked { get; set; }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 6;
            if (IsChecked)
            {
                canvas.DrawLine(10, 10, 60, 60);
                canvas.DrawLine(60, 10, 10, 60);
            }

            canvas.DrawRoundedRectangle(10, 10, 60, 60, 10);
        }
    }
}
