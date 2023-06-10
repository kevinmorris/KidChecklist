using System.Reflection;
using KidChecklist.Model;
using Microsoft.Maui.Graphics.Platform;
using IImage = Microsoft.Maui.Graphics.IImage;

namespace KidChecklist.View
{
    public class CheckBoxDrawable : IDrawable
    {
        private readonly int _size;
        private IImage _checkMarkImage;

        private ChecklistItem _item;

        public ChecklistItem Item
        {
            get => _item;
            set
            {
                _item = value;
                var fileIndex = Item.MediaIndex;
                var fileName = $"{fileIndex:000}.png";
                var assembly = typeof(CheckBoxDrawable).Assembly;
                using var stream = assembly.GetManifestResourceStream($"KidChecklist.Resources.Images.pokemon.{fileName}");

                _checkMarkImage = PlatformImage.FromStream(stream);
            }
        }

        public CheckBoxDrawable()
        {
            IsChecked = false;
            Application.Current!.Resources.TryGetValue("CheckBoxSize", out var sizeObj);
            _size = (int)sizeObj;
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
