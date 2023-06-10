using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Huds.PopupDisplays;
using TestGame.Managers;
using TestGame.Objects.Monsters;

namespace TestGame.Huds.MonsterUI
{
    public class NewMonsterHud : Hud, Clickable
    {
        private Monster monsterToDisplay;
        public NewMonsterHud(Monster monsterToDisplay, int x, int y, int size)
        {
            Y = y;
            X = x;
            Width = size;
            Height = size;
            this.monsterToDisplay = monsterToDisplay;
        }
        
        public void Clicked(float x, float y, Game1 g)
        {
            Vector2 cords = GetPos(g);
            if (new Rectangle((int)cords.X, (int)cords.Y, Width, Height).Contains(new Vector2(x, y)))
            {
                g.pageGame.mouseManager.stopClick = true;
                PopupDisplay pd = new PopupDisplay();
                pd.hm.Add(new MonsterDisplay(pd, monsterToDisplay), g);
                new Sound(Sounds.pause, 0.8f).play(g);
                MediaPlayer.Pause();
                g.pageGame.hudManager.Add(pd, g);
                g.pageGame.sceneManager.GetScene().discoverMonsterHandler.clikecOn(this);

                g.pageGame.getHudManager().Remove(this, g);
            }
        }
        public override void Init(Game1 g)
        {
            new Sound(Sounds.use, 1f).play(g);
            g.pageGame.mouseManager.Add(this);
            base.Init(g);
        }
        public override void Destroy(Game1 g)
        {
            g.pageGame.mouseManager.Remove(this);
            base.Destroy(g);
        }
        public override void Draw(Game1 g)
        {
            monsterToDisplay.getSprite().Draw(GetPos(g), width: Width, height: Height, layerDepth: depth);
            Drawing.DrawText("NEW!", GetPos(g).X+30, GetPos(g).Y + Height-30, layerDepth: depth * 0.8f, color: Color.Yellow);
        }
    }
}
