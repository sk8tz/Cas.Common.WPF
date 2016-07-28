using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace DraggableExample.ViewModel
{
    public class DraggableViewModel : INotifyPropertyChanged
    {
        private Point _location;
        public event PropertyChangedEventHandler PropertyChanged;

        private Point _startLocation;

        public Point Location
        {
            get { return _location; }
            set
            {
                _location = value; 
                OnPropertyChanged();
            }
        }

        public void StartMove()
        {
            _startLocation = Location;
        }

        public void ContinueMove(Vector vector)
        {
            Location = _startLocation + vector;
        }

        public void CancelMove()
        {
            Location = _startLocation;
        }

        public void CompleteMove(Vector vector)
        {
            Location = _startLocation + vector;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}