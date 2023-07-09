using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KidChecklist.Model
{
    public class ChecklistItem
    {
        public string Title { get; init; }
        public byte[] Image { get; init; }

        public ICommand CheckCommand { get; }
        public event EventHandler CheckChanged;
        public bool IsChecked { get; private set; }
        public int MediaIndex { get; private set; }

        public ChecklistItem()
        {
            CheckCommand = new Command<bool>(ExecuteChecked);
            MediaIndex = new Random().Next(1, 152);
        }

        private void ExecuteChecked(bool check)
        {
            IsChecked = check;
            CheckChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
