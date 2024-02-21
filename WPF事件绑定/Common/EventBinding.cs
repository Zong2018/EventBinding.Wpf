using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace WPF事件绑定.Common
{
    /// <summary>
    /// 事件标记扩展
    /// </summary>
    public class EventBinding : MarkupExtension
    {
        public EventBinding()
        {
        }

        /// <summary>
        /// 事件名称
        /// </summary>
        public string EventName { get; set; }
        /// <summary>
        /// 绑定的属性名
        /// </summary>
        public string Path { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget t = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
            var d = t.TargetObject as FrameworkElement;

            if (d == null) return false;

            CallCommand.SetEventName(d, EventName);
            CallCommand.SetPath(d, Path);
            Binding binding = new Binding();
            //设置要绑定源
            binding.Source = d;
            //设置要绑定属性
            binding.Path = new PropertyPath("DataContext");
            binding.Mode = BindingMode.OneWay;
            //设置绑定到要绑定的控件
            d.SetBinding(CallCommand.DataContextProperty, binding);

            return true;
        }
    }
}
