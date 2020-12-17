using StockViewerUI.State.CurrentContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace StockViewerUI.Commands
{
    public class RedirectCommand : ICommand
    {
        private IRenavigator renavigator;

        public RedirectCommand(IRenavigator renavigator)
        {
            this.renavigator = renavigator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            renavigator.Renavigate();
        }
    }
}
