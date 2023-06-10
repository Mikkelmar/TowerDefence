using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TestGame.Managers
{
    public class SoundManager
    {
        public static float MusicVolume = 0.04f;
        public static float GameVolume = 1f;
        private List<SoundEffectInstance> loopedSounds = new List<SoundEffectInstance>();
        public enum types { Music, Normal, Tower, Monster, Menu };
        private IDictionary<types, float> volumeValues = new Dictionary<types, float>() {
            { types.Monster, 0.1f },
            { types.Tower, 0.3f },
            { types.Music, 1f },
            { types.Normal, 1f },
            { types.Menu, 0.2f },
        };
        public static float getMusicVolume()
        {
            return MusicVolume / 0.4f;
        }
        public static float getGameVolume()
        {
            return GameVolume / 1f;
        }
        public void setMusicVolume(float volume)
        {
            MusicVolume = Math.Max(Math.Min(volume, 0.4f), 0f);
            MediaPlayer.Volume = MusicVolume;
        }
        public void changeMusicVolume(float increment)
        {
            MusicVolume = Math.Max(Math.Min(MusicVolume+ increment, 0.4f), 0f);
            MediaPlayer.Volume = MusicVolume;
        }
        public void changeGameVolume(float increment)
        {
            GameVolume = Math.Max(Math.Min(GameVolume + increment, 1f), 0f);
        }
        public SoundManager()
        {
            MediaPlayer.Volume = MusicVolume* GameVolume;
        }
        public void play(Sound sound)
        {
            //settings bug
            sound.effect.Play(sound.volume*volumeValues[sound.type]* GameVolume, 0f, 0f);
        }
        public void playLooped(SoundEffectInstance effect)
        {
            if (!loopedSounds.Contains(effect))
            {
                effect.IsLooped = true;
                effect.Play();
                loopedSounds.Add(effect);
            }
            
        }
        public void stopLooped(SoundEffectInstance effect)
        {
            effect.Stop();
            loopedSounds.Remove(effect);
        }
        public void pauseSounds()
        {
            foreach(SoundEffectInstance effect in loopedSounds)
            {
                effect.Pause();
            }
        }
        public void unpauseSounds()
        {
            foreach (SoundEffectInstance effect in loopedSounds)
            {
                effect.Resume();
            }
        }
    }
}
