using KidChecklist.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
// ReSharper disable All

namespace KidChecklist
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ChecklistItem> Items { get; }

        private bool _isAllChecked;
        public bool IsAllChecked
        {
            get => _isAllChecked;
            set
            {
                if(IsAllChecked != value)
                {
                    _isAllChecked = value;
                    RaisePropertyChanged();
                }
            }
        }

        public MainViewModel()
        {
            Items = new ObservableCollection<ChecklistItem>
            {
                new()
                {
                    Title = "10 minute playroom/bedroom clean-up",
                    Image = Array.Empty<byte>()
                },

                new()
                {
                    Title = "Undress",
                    Image = Array.Empty<byte>()

                },

                new()
                {
                    Title = "Put dirty clothes in closet",
                    Image = Array.Empty<byte>()

                },

                new()
                {
                    Title = "Go potty",
                    Image = Array.Empty<byte>()

                },
                
                new()
                {
                    Title = "Take bath or shower",
                    Image = Array.Empty<byte>()

                },
                
                new()
                {
                    Title = "Take Vitamins",
                    Image = Array.Empty<byte>()

                },
                
                new()
                {
                    Title = "Brush teeth",
                    Image = Array.Empty<byte>()

                },

                new()
                {
                    Title = "Hug brother",
                    Image = Array.Empty<byte>()

                },

                new()
                {
                    Title = "Hugs with Mom and Dad",
                    Image = Array.Empty<byte>()

                },

                new()
                {
                    Title = "Read books or relax",
                    Image = Array.Empty<byte>()

                },

                new()
                {
                    Title = "Go to sleep",
                    Image = Array.Empty<byte>()

                },
            };

            foreach (var item in Items)
            {
                item.CheckChanged += ChecklistItem_CheckChanged;
            }
        }

        private void ChecklistItem_CheckChanged(object sender, EventArgs args)
        {
            IsAllChecked = Items.All(x => x.IsChecked);
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
