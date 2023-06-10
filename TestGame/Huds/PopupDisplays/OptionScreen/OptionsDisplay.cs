using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;

namespace TestGame.Huds.PopupDisplays.OptionScreen
{
    public class OptionsDisplay : Hud
    {
        private PopupDisplay pd;
        public OptionsDisplay(PopupDisplay pd)
        {
            this.pd = pd;
            X = pd.X;
            Y = pd.Y;

        }
        public override void Destroy(Game1 g)
        {
            base.Destroy(g);
            g.saveManager.updateSave(g);
        }

        public override void Init(Game1 g)
        {
            base.Init(g);

            pd.hm.Add(new ContinueButton(pd, pd.Width-40,20)
            {
                depth = pd.depth * 0.5f
            }, g);
            pd.hm.Add(new FullScreenDisplayButton(pd,200, 120)
            {
                depth = pd.depth * 0.5f
            }, g);
            pd.hm.Add(new ExitButton(pd, 200, 180)
            {
                depth = pd.depth * 0.5f
            }, g);
            
            pd.hm.Add(new VolumeButton(pd, 850, 150, SoundManager.types.Music, 1)
            {
                depth = pd.depth * 0.5f
            }, g);
            pd.hm.Add(new VolumeButton(pd, 700, 150, SoundManager.types.Music, -1)
            {
                depth = pd.depth * 0.5f
            }, g);
            pd.hm.Add(new VolumeButton(pd, 850, 250, SoundManager.types.Normal, 1)
            {
                depth = pd.depth * 0.5f
            }, g);
            pd.hm.Add(new VolumeButton(pd, 700, 250, SoundManager.types.Normal, -1)
            {
                depth = pd.depth * 0.5f
            }, g);


        }

        public override void Draw(Game1 g)
        {
            //MUSIC
            Drawing.DrawText("Music Volume", (int)pd.X + 555, (int)pd.Y + 110, scale: 1f, layerDepth: pd.depth * 0.1f);
            Drawing.FillRect(new Rectangle((int)pd.X + 585, (int)pd.Y + 150, (int)(100 * SoundManager.getMusicVolume()), 32), Color.White, pd.depth * 0.1f,g);
            Drawing.FillRect(new Rectangle((int)pd.X + 585, (int)pd.Y + 150, 100, 32), Color.Gray, pd.depth * 0.2f, g);

            //GAME
            Drawing.DrawText("Game Volume", (int)pd.X + 555, (int)pd.Y + 210, scale: 1f, layerDepth: pd.depth * 0.1f);
            Drawing.FillRect(new Rectangle((int)pd.X + 585, (int)pd.Y + 250, (int)(100 * SoundManager.getGameVolume()), 32), Color.White, pd.depth * 0.1f, g);
            Drawing.FillRect(new Rectangle((int)pd.X + 585, (int)pd.Y + 250, 100, 32), Color.Gray, pd.depth * 0.2f, g);
            
            Drawing.DrawText("Options", X+200, Y+20, scale: 3f, layerDepth: pd.depth*0.1f);
        }
    }
}
