using AdventureBoard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AdventureBoard
{
    public class PlaySound_Command : ICommand
    {
        // Command class member variables
        public event EventHandler CanExecuteChanged;
        private ViewModel.ViewModel vm;

        // Constructor
        public PlaySound_Command(ViewModel.ViewModel vM)
        {
            this.vm = vM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Signal to Eventhandler
        /// </summary>
        public void FireCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        
        public void Execute(object parameter)
        {
            Console.WriteLine("WOMBO");
            if (vm.getFileExists())
                vm.playSound();
        }
    }
}
