using System;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;

namespace Cas.Common.WPF.Converters
{
    /// <summary>
    /// Triggers an animation when a value changes.
    /// </summary>
    public class AnimateOnChangeBehavior : Behavior<UIElement>
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value",
            typeof(object),
            typeof(AnimateOnChangeBehavior),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, ValueChangedCallback));

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty StoryboardProperty = DependencyProperty.Register("Storyboard",
            typeof(Storyboard),
            typeof(AnimateOnChangeBehavior));

        /// <summary>
        /// That value to monitor for changes.
        /// </summary>
        public object Value
        {
            get { return (object)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// The storyboard.
        /// </summary>
        public Storyboard Storyboard
        {
            get { return (Storyboard)GetValue(StoryboardProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private static void ValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var item = d as AnimateOnChangeBehavior;

            if (item == null || item.AssociatedObject == null)
            {
                return;
            }

            item.Storyboard?.Begin();
        }
    }
}