using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF事件绑定.Common
{
    public class BaseCommand : ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// 
        /// </summary>
        public Action<object> commandExecute;
        /// <summary>
        /// 
        /// </summary>
        public Func<object, bool> commandCanExecute;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandExecute"></param>
        /// <param name="commandCanExecute"></param>
        public BaseCommand(Action<object> commandExecute, Func<object, bool> commandCanExecute)
        {
            this.commandExecute = commandExecute;
            this.commandCanExecute = commandCanExecute;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return commandCanExecute?.Invoke(parameter) ?? true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            commandExecute?.Invoke(parameter);
        }
    }

}
