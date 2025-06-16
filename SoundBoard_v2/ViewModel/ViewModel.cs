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

        // Sound Model Collection
        private List<SoundModel> soundModels = new List<SoundModel>();

        public ViewModel()
        {
            initFiles();
        }

        public void initFiles()
        {
            var path = "C:/Users/am_ka/Desktop/Messy Work Bench/Practice/sounds/";

            soundModels.AddRange(new List<SoundModel>
            {
                new SoundModel("Sword_Swish", $"{path}sword-35999.wav"),
                new SoundModel("Bass_Pulse", $"{path}bass-pulse.wav"),
                new SoundModel("Arrow_Woosh", $"{path}arrow-woosh.wav"),
                new SoundModel("Roar", $"{path}roar.wav")
            });

        }

        public SoundModel getSoundModel(int index)
        {
            return soundModels.ElementAt(index);
        }

        public void cleanUpFiles()
        {
            foreach(SoundModel sm in soundModels)
            {
                sm.cleanUp();
            }
        }
    }
}
