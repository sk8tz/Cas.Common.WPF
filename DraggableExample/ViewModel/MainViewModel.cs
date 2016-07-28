using System.Windows;

namespace DraggableExample.ViewModel
{
    public class MainViewModel
    {
        private readonly DraggableViewModel _draggable = new DraggableViewModel()
        {
            Location = new Point(10, 10)
        };

        public MainViewModel()
        {
            
        }


        public DraggableViewModel Draggable
        {
            get { return _draggable; }
        }
    }
}