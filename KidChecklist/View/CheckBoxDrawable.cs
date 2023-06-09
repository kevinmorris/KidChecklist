using System.Reflection;
using Microsoft.Maui.Graphics.Platform;
using IImage = Microsoft.Maui.Graphics.IImage;

namespace KidChecklist.View
{
    public class CheckBoxDrawable : IDrawable
    {
        private readonly int _size;
        private readonly IImage _checkMarkImage;
        private readonly Random _random = new Random();
        public CheckBoxDrawable()
        {
            IsChecked = false;
            Application.Current!.Resources.TryGetValue("CheckBoxSize", out var sizeObj);
            _size = (int)sizeObj;

            var assembly = typeof(CheckBoxDrawable).Assembly;
            var fileIndex = _random.Next(1, 152);
            var fileName = $"{fileIndex:000}.png";
            using var stream = assembly.GetManifestResourceStream($"KidChecklist.Resources.Images.pokemon.{fileName}");

            _checkMarkImage = PlatformImage.FromStream(stream);
        }

        public bool IsChecked { get; set; }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 6;
            canvas.DrawRoundedRectangle(10, 10, _size - 20, _size - 20, 10);

            if (IsChecked)
            {
                canvas.DrawImage(_checkMarkImage, 0, 0, _size, _size);
            }
        }
    }
}
