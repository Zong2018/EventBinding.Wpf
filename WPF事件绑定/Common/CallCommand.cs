using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF事件绑定.Common
{
    /// <summary>
    /// 事件调用附加类
    /// </summary>
    public static class CallCommand
    {
        public static bool GetIsAttackCommand(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsAttackCommandProperty);
        }

        public static void SetIsAttackCommand(DependencyObject obj, bool value)
        {
            obj.SetValue(IsAttackCommandProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsAttackCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsAttackCommandProperty =
            DependencyProperty.RegisterAttached("IsAttackCommand", typeof(bool), typeof(CallCommand), new PropertyMetadata(false));


        public static object GetDataContext(DependencyObject obj)
        {
            return (object)obj.GetValue(DataContextProperty);
        }

        public static void SetDataContext(DependencyObject obj, object value)
        {
            obj.SetValue(DataContextProperty, value);
        }

        // Using a DependencyProperty as the backing store for DataContext.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataContextProperty =
            DependencyProperty.RegisterAttached("DataContext", typeof(object), typeof(CallCommand), new PropertyMetadata(null, DataContextPropertyChangedCallback));


        public static void DataContextPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null && e.NewValue != e.OldValue)
            {
                EventInfo evt = d.GetType().GetEvent(d.GetValue(EventNameProperty) as string, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (evt != null)
                {
                    var pInfo = e.NewValue.GetType().GetProperty(d.GetValue(PathProperty) as string, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                    evt.RemoveEventHandler(d, pInfo.GetValue(e.NewValue) as Delegate);
                    evt.AddEventHandler(d, pInfo.GetValue(e.NewValue) as Delegate);
                }
            }
        }


        public static string GetEventName(DependencyObject obj)
        {
            return (string)obj.GetValue(EventNameProperty);
        }

        public static void SetEventName(DependencyObject obj, string value)
        {
            obj.SetValue(EventNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for EventName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EventNameProperty =
            DependencyProperty.RegisterAttached("EventName", typeof(string), typeof(CallCommand), new PropertyMetadata(null));



        public static string GetPath(DependencyObject obj)
        {
            return (string)obj.GetValue(PathProperty);
        }

        public static void SetPath(DependencyObject obj, string value)
        {
            obj.SetValue(PathProperty, value);
        }

        // Using a DependencyProperty as the backing store for Path.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PathProperty =
            DependencyProperty.RegisterAttached("Path", typeof(string), typeof(CallCommand), new PropertyMetadata(null));
    }
}
