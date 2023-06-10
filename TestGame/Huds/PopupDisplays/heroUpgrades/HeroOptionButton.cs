using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects;
using TestGame.Objects.Particles;
using TestGame.Objects.Soldiers;
using TestGame.Objects.Towers;

namespace TestGame.Huds.PopupDisplays.heroUpgrades
{
    public class HeroOptionButton : DisplayButton
    {
        private Hero hero;
        public int heroID;
        private static Sound deniedSound = new Sound(Sounds.denied, 0.1f, SoundManager.types.Menu);
        public HeroOptionButton(PopupDisplay pd, int x, int y, Hero hero, int id) : base(pd, x, y)
        {
            this.hero = hero;
            heroID = id;
            Width = 200;
            Height = 300;
        }

        public override void activate(Game1 g)
        {
            if (!g.pageGame.player.heros[heroID].isUnlocked)
            {
                deniedSound.play(g);
                return;
            }
            this.pd.close(g);
            g.levelMap.hudManager.closeActiveObject(g);
            PopupDisplay pd = new PopupDisplay()
            {
                Width = 48 * 21,
                Height = 32 * 21
            };
            g.levelMap.hudManager.Add(pd, g);

            pd.hm.Add(new HeroUpgradeDisplay(pd, hero)
            {
                depth = pd.depth * 0.5f
            }, g);
        }
        public override void Draw(Game1 g)
        {
            if (!g.pageGame.player.heros[heroID].isUnlocked)
            {
                new Sprite(Textures.towerInfo).Draw(X, Y, Width, Height, layerDepth: this.pd.depth * 0.5f);
                Drawing.DrawText("???", X + 60, Y + Height - 100, scale: 2f, layerDepth: pd.depth * 0.1f, color: Color.Gold);
                return;
            }
            if (Player.activeHero == heroID)
            {
                new Sprite(Textures.towerInfo_selected).Draw(X, Y, Width, Height, layerDepth: this.pd.depth * 0.5f);
            }
            else
            {
                new Sprite(Textures.towerInfo).Draw(X, Y, Width, Height, layerDepth: this.pd.depth * 0.5f);
            }
            int iconSize = Width-40;
            hero.getSprite().Draw(X+Width/2-iconSize/2, Y+20, iconSize, iconSize, layerDepth: this.pd.depth * 0.1f);
            Drawing.DrawText(hero.name, X + 20, Y + Height-100, scale: TextHandler.GetFitScale(hero.name, Width-40), layerDepth: pd.depth * 0.1f, color: Color.Gold);
        }
    }
}
