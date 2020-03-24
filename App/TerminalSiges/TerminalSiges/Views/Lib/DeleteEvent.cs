using System;
using System.Collections.Generic;
using System.Text;
using TerminalSiges.Views.Pages.Lados;

namespace TerminalSiges.Views.Lib
{
    public class DeleteEvent : System.Windows.Input.ICommand
    {
        private Lado itemModelToDelete { get; set; }

        public event SelectClientDelegado executeEvent;
        public delegate void SelectClientDelegado(Lado input);

        public DeleteEvent(Lado itemModelToDelete)
        {
            this.itemModelToDelete = itemModelToDelete;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute()
        {
            executeEvent(itemModelToDelete);
        }

        public void Execute(object parameter)
        {
            executeEvent(itemModelToDelete);
        }
    }
}