using SoundBoard_v2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SoundBoard_v2
{
    public class PlaySound_Command : ICommand
    {
        // Command class member variables
        public event EventHandler CanExecuteChanged;
        private Model.SoundModel sm;

        // Constructor
        public PlaySound_Command(SoundModel sM)
        {
            this.sm = sM;
        }

        public bool CanExecute(object parameter)
        {
            return sm.getFileExists();
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
            sm.playSound();
        }
    }
}
