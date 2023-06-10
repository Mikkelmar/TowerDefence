using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame.Managers
{
    public class Sound
    {
        public SoundEffect effect;
        public float volume;
        public SoundManager.types type;
        public Sound(SoundEffect sound, float volume = 1f, SoundManager.types type = SoundManager.types.Normal)
        {
            effect = sound;
            this.volume = volume;
            this.type = type;
        }
        public void play(Game1 g)
        {
            
            g.soundManager.play(this);
        }
    }
}
