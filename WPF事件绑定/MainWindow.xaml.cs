using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF事件绑定.Common;

namespace WPF事件绑定
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            this.DataContext = new MainModel();
        }
    }


    public class MainModel : BaseViewModel
    {
        public MainModel()
        {
            MouseLeftDownHandler = (s, b) => { MessageBox.Show("测试通过,点击左键"); };
        }
        public MouseButtonEventHandler MouseLeftDownHandler { get; set; }

    }
}
