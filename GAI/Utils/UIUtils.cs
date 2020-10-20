using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace GAI.Utils
{
    class UIUtils
    {
        public static T GetParent<T>(DependencyObject child) where T : DependencyObject

        {

            DependencyObject dependencyObject = VisualTreeHelper.GetParent(child);

            if (dependencyObject != null)

            {

                T parent = dependencyObject as T;

                if (parent != null)

                {

                    return parent;

                }

                else

                {

                    return GetParent<T>(dependencyObject);

                }

            }

            else

            {

                return null;

            }

        }
        
    }
    public static class DisableNavigation
    {
        public static bool GetDisable(DependencyObject o)
        {
            return (bool)o.GetValue(DisableProperty);
        }
        public static void SetDisable(DependencyObject o, bool value)
        {
            o.SetValue(DisableProperty, value);
        }

        public static readonly DependencyProperty DisableProperty =
            DependencyProperty.RegisterAttached("Disable", typeof(bool), typeof(DisableNavigation),
                                                new PropertyMetadata(false, DisableChanged));



        public static void DisableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var frame = (Frame)sender;
            frame.Navigated += DontNavigate;
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        public static void DontNavigate(object sender, NavigationEventArgs e)
        {
            ((Frame)sender).NavigationService.RemoveBackEntry();
        }
    }
}
