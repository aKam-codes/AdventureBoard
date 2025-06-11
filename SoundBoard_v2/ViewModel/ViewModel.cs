using SoundBoard_v2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBoard_v2.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        // Events
        public event PropertyChangedEventHandler PropertyChanged;

        private List<SoundModel> soundModels = new List<SoundModel>();

        public ViewModel()
        {
            initFiles();
        }

        public void initFiles()
        {
            soundModels.Add(
                new SoundModel(
                    "Sword_Swish",
                    "C:/Users/am_ka/Desktop/Messy Work Bench/Practice/sounds/sword-35999.wav"
                                ));

        }

        public SoundModel getSoundModel(int index)
        {
            return soundModels.ElementAt(index);
        }
    }
}
