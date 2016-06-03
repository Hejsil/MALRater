using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MALRater.GUI
{
    /// <summary>
    /// A command that executes delegates.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// The action to run when Execute is called.
        /// </summary>
        public Action<object> ExecuteAction { get; set; }

        /// <summary>
        /// The function to run when CanExecute is called.
        /// </summary>
        public Func<object, bool> CanExecuteFunc { get; set; }

        public DelegateCommand(Action<object> execute, Func<object, bool> canexecute)
        {
            ExecuteAction = execute;
            CanExecuteFunc = canexecute;
        }

        /// <summary>
        /// The events that are triggered, when CanExecute changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        public void OnCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
                handler(this, null);
        }

        /// <summary>
        /// The CanExecute for the command.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc(parameter);
        }

        /// <summary>
        /// The Execute for the command.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            ExecuteAction(parameter);
        }
    }
}
