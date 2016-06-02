using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Cas.Common.WPF.Behaviors
{
    /// <summary>
    /// 
    /// </summary>
    public class DraggableBehaviorBase : Behavior<FrameworkElement>
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty IsEnabledProperty =
           DependencyProperty.Register("IsEnabled", typeof(bool), typeof(DraggableBehaviorBase), new FrameworkPropertyMetadata(true, PropertyChanged));

        private enum DragState
        {
            /// <summary>
            /// The virgin state. Nothing has happened yet.
            /// </summary>
            Idle,

            /// <summary>
            /// The mouse is down, but hasn't moved enough to start dragging
            /// </summary>
            MouseDown,

            /// <summary>
            /// We're dragging folks.
            /// </summary>
            Dragging
        }

        private DragState _state = DragState.Idle;
        private Point _startPosition;
        private Window _window;

        /// <summary>
        /// Attempts to get the window associated with this user control.
        /// </summary>
        private void GetWindow()
        {
            // Only do this once
            if (_window != null)
                return;

            _window = Window.GetWindow(AssociatedObject);

            if (_window != null)
            {
                _window.KeyUp += WindowKeyUp;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += Element_MouseLeftButtonDown;
            AssociatedObject.MouseMove += Element_MouseMove;
            AssociatedObject.MouseLeftButtonUp += ElementOnMouseLeftButtonUp;
            AssociatedObject.Loaded += AssociatedObject_Loaded;
            AssociatedObject.Unloaded += AssociatedObject_Unloaded;

            GetWindow();
            
            Reset();

            base.OnAttached();
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            GetWindow();
        }

        private void AssociatedObject_Unloaded(object sender, RoutedEventArgs e)
        {
            Cleanup();
        }

        private void WindowKeyUp(object sender, KeyEventArgs e)
        {
            if (_state == DragState.Dragging)
            {
                CancelDrag();

                Reset();
            }
        }

        private void Cleanup()
        {
            AssociatedObject.MouseLeftButtonDown -= Element_MouseLeftButtonDown;
            AssociatedObject.MouseMove -= Element_MouseMove;
            AssociatedObject.MouseLeftButtonUp -= ElementOnMouseLeftButtonUp;

            if (_window != null)
            {
                _window.KeyUp -= WindowKeyUp;

                _window = null;
            }

            Reset();
        }

        /// <summary>
        /// Not sure we need this: http://stackoverflow.com/questions/30638292/ondetaching-function-of-behavior-is-not-called
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();

            Cleanup();
        }

        /// <summary>
        /// We're starting a drag operation.
        /// </summary>
        /// <param name="position"></param>
        protected virtual void StartDrag(Point position)
        {
            
        }

        /// <summary>
        /// We're still dragging.
        /// </summary>
        /// <param name="position"></param>
        protected virtual void ContinueDrag(Point position)
        {
            
        }

        /// <summary>
        /// Called when a drag operation is cancelled.
        /// </summary>
        protected virtual void CancelDrag()
        {
            
        }

        /// <summary>
        /// The drag operation is done - the user has let go of the mouse button.
        /// </summary>
        /// <param name="position"></param>
        protected virtual void FinishDrag(Point position)
        {
            
        }

        /// <summary>
        /// No drag occurred - the user just clicked the control.
        /// </summary>
        protected virtual void Clicked()
        {
            
        }

        /// <summary>
        /// Override this if you need to change what GetPosition uses for reference.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        protected virtual Point GetPositionFromMouse(MouseEventArgs e)
        {
            return e.GetPosition(null);
        }

        private void Element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsEnabled)
                return;

            if (_state == DragState.Idle)
            {
                _startPosition = GetPositionFromMouse(e);
                _state = DragState.MouseDown;

                e.Handled = true;

                AssociatedObject.Focus();

                AssociatedObject.CaptureMouse();
            }
        }

        private void Element_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsEnabled)
                return;

            var position = new Lazy<Point>(() => GetPositionFromMouse(e));

            if (_state == DragState.MouseDown)
            {
                //Check to see if we're out of the dragging min 
                //http://stackoverflow.com/questions/2068106/wpf-drag-distance-threshold

                var distanceMoved = _startPosition - position.Value;

                if (Math.Abs(distanceMoved.X) >= SystemParameters.MinimumHorizontalDragDistance &&
                    Math.Abs(distanceMoved.Y) >= SystemParameters.MinimumVerticalDragDistance)
                {
                    //Make sure that the item is selcted and start dragging.
                    _state = DragState.Dragging;
                  
                    //Focus
                    AssociatedObject.Focus();

                    //We've got this
                    e.Handled = true;    
                    
                    //Start the drag operation
                    StartDrag(position.Value);             
                }

            }
            else if (_state == DragState.Dragging)
            {
                //Drag
                ContinueDrag(position.Value);

                e.Handled = true;
            }
        }

        private void ElementOnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!IsEnabled)
                return;

            var position = new Lazy<Point>(() => GetPositionFromMouse(e));

            switch (_state)
            {
                case DragState.MouseDown:

                    Clicked();
                    break;

                case DragState.Dragging:

                    FinishDrag(position.Value);

                    break;
            }

            e.Handled = true;

            Reset();
        }

        /// <summary>
        /// Gets or sets whether this behavior is enabled.
        /// </summary>
        public bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        /// <summary>
        /// Gets the start position
        /// </summary>
        protected Point StartPosition
        {
            get { return _startPosition; }
        }

        private static void PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            (obj as DraggableBehaviorBase)?.Reset();            
        }

        /// <summary>
        /// Resets the state.
        /// </summary>
        protected virtual void Reset()
        {
            _state = DragState.Idle;
            AssociatedObject.ReleaseMouseCapture();   
        }
    }
}