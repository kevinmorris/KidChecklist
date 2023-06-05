namespace KidChecklist.View
{
    public class CheckBoxDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 6;
            canvas.DrawRoundedRectangle(10, 10, 60, 60, 10);
        }
    }
}
