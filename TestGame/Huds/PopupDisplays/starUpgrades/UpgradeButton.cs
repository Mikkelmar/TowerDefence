using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;

namespace TestGame.Huds.PopupDisplays.starUpgrades
{
    public class UpgradeButton : DisplayButton
    {

        private static Sound buySound = new Sound(Sounds.sell, 0.1f, SoundManager.types.Menu),
            deniedSound = new Sound(Sounds.denied, 0.1f, SoundManager.types.Menu);
        private string powerKey, name, description, requireKey;
        private int hoverBoxSize = 100, cost;
        private StarUpgradeDisplay sud;
        private Sprite icon;
        public UpgradeButton(PopupDisplay pd, StarUpgradeDisplay sud, float x, float y, string powerKey, string name, string description, int cost, Sprite icon, string requireKey= null) : base(pd, x, y)
        {
            this.powerKey = powerKey;
            this.name = name;
            this.description = description;
            this.cost = cost;
            depth = pd.depth * 0.5f;
            this.sud = sud;
            this.icon = icon;
            Width = 64;
            Height = 64;
            this.requireKey = requireKey;
        }
        public int getStarsUsed(Game1 g)
        {
            if (g.levelMap.playerData.starUpgrades[powerKey])
            {
                return cost;
            }
            return 0;
        }
        public override void activate(Game1 g)
        {
            if ((requireKey == null || g.levelMap.playerData.starUpgrades[requireKey]) && !g.levelMap.playerData.starUpgrades[powerKey])
            {
                if(sud.starsLeft >= cost)
                {
                    buySound.play(g);
                    g.levelMap.playerData.starUpgrades[powerKey] = true;
                    sud.starsLeft -= cost;
                }
                else
                {
                    deniedSound.play(g);
                }
            }
            else
            {
                deniedSound.play(g);
            }

        }
        protected override void TriggerHoverd(float x, float y, Game1 g)
        {
            if ((requireKey == null || g.levelMap.playerData.starUpgrades[requireKey]) && !g.levelMap.playerData.starUpgrades[powerKey])
            {
                base.TriggerHoverd(x, y, g);
            }
            
        }
        public override void Draw(Game1 g)
        {
            float alpaValue = 1f;
            if(requireKey != null && !g.levelMap.playerData.starUpgrades[requireKey]){
                alpaValue = .2f;
            }
            Sprite boarder = new Sprite(Textures.gui, new Rectangle(49 + 32, 97, 30, 30));
            if (g.levelMap.playerData.starUpgrades[powerKey])
            {
                boarder = new Sprite(Textures.gui, new Rectangle(49 + 32, 97+30, 30, 30));
            }
            boarder.Draw(new Vector2(X, Y), Width, Height, depth, alpha: alpaValue);
            icon.Draw(new Vector2(X, Y), Width, Height, depth*0.3f, alpha: alpaValue);
            new Sprite(Textures.gold_star).Draw(new Vector2(X +5, Y+2+ Height), Width/3, Height/3, depth*0.2f, alpha: alpaValue);
            Drawing.DrawText(cost.ToString(), X+Width/2, Y + Height, layerDepth: depth*0.1f, color: Color.White*alpaValue);

            if (BeingHoverd)
            {
                int boxSize = 160;
                Vector2 pos = g.pageGame.mouseManager.GetMousePos(g);
                new Sprite(Textures.bigHoverbox).Draw(pos.X + hoverBoxSize / 4, pos.Y - 32, boxSize, boxSize, layerDepth: depth * 0.05f);
                
                Drawing.DrawText(name.ToUpper(), pos.X + hoverBoxSize / 3 + 10, pos.Y - 12, scale: Math.Min(TextHandler.GetFitScale(name.ToUpper(), boxSize-30),0.9f), layerDepth: depth * 0.01f);
                //Drawing.DrawText(power.desc, pos.X + size / 2, pos.Y + 18, scale: 0.8f, layerDepth: depth);
                int i = 0;
                foreach (string s in TextHandler.FitText(description, boxSize - 22, 0.7f))
                {
                    Drawing.DrawText(s, pos.X + hoverBoxSize / 3+10, pos.Y + 15 + i * (TextHandler.textHeight(s) * 0.7f), scale: 0.7f, layerDepth: depth * 0.01f);
                    i++;
                }
            }
        }
    }
}
