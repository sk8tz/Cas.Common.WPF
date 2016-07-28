using System.Windows;
using Cas.Common.WPF.Behaviors;
using DraggableExample.ViewModel;

namespace DraggableExample.Behaviors
{
    public class MyDraggableBehavior : DraggableBehaviorBase
    {
        private DraggableViewModel Draggable
        {
            get {  return AssociatedObject.DataContext as DraggableViewModel; }
        }

        protected override void StartDrag(Point position)
        {
            Draggable?.StartMove();
        }

        protected override void ContinueDrag(Point position)
        {
            var vector = position - StartPosition;

            Draggable?.ContinueMove(vector);
        }

        protected override void CancelDrag()
        {
            Draggable?.CancelMove();
        }

        protected override void FinishDrag(Point position)
        {
            Draggable?.CompleteMove(position - StartPosition);
        }
    }
}