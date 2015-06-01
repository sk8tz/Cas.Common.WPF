using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Cas.Common.WPF.Behaviors
{

    /// <summary>
    /// Allows the selected item property to be bound for MVVM.
    /// </summary>
    /// <remarks>
    /// Got this from here: Seems to work fine
    /// http://stackoverflow.com/a/5118406/232566
    /// </remarks>
    public class BindableSelectedTreeViewItemBehavior : Behavior<TreeView>
    {
        #region SelectedItem Property

        /// <summary>
        /// 
        /// </summary>
        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(BindableSelectedTreeViewItemBehavior), new UIPropertyMetadata(null, OnSelectedItemChanged));

        private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var item = e.NewValue as TreeViewItem;
            if (item != null)
            {
                item.SetValue(TreeViewItem.IsSelectedProperty, true);
            }
        }

        #endregion

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>
        /// Override this to hook up functionality to the AssociatedObject.
        /// </remarks>
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.SelectedItemChanged += OnTreeViewSelectedItemChanged;
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>
        /// Override this to unhook functionality from the AssociatedObject.
        /// </remarks>
        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (this.AssociatedObject != null)
            {
                AssociatedObject.SelectedItemChanged -= OnTreeViewSelectedItemChanged;
            }
        }

        private void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedItem = e.NewValue;
        }
    }
}
