using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;

namespace Cas.Common.WPF.Behaviors
{
    /// <summary>
    /// Behavior for dealing with multiple selection.
    /// </summary>
    public class MultiSelectorSelectedItemsBehavior : Behavior<MultiSelector>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>
        /// Override this to hook up functionality to the AssociatedObject.
        /// </remarks>
        protected override void OnAttached()
        {
            AssociatedObject.SelectionChanged += AssociatedObjectSelectionChanged;
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>
        /// Override this to unhook functionality from the AssociatedObject.
        /// </remarks>
        protected override void OnDetaching()
        {
            AssociatedObject.SelectionChanged -= AssociatedObjectSelectionChanged;
        }

        void AssociatedObjectSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var array = new object[AssociatedObject.SelectedItems.Count];
            AssociatedObject.SelectedItems.CopyTo(array, 0);
            SelectedItems = array;
        }

        /// <summary>
        /// Dependency Property
        /// </summary>
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(IEnumerable), typeof(MultiSelectorSelectedItemsBehavior),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// Gets or sets the selected items.
        /// </summary>
        public IList SelectedItems
        {
            get { return (IList)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }
    }
}
