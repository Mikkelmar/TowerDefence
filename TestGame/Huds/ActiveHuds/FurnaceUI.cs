using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Containers;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Entities.Buildings;

namespace TestGame.Huds.ActiveHuds
{
    public class FurnaceUI : ActiveUI
    {
 
    private Sprite sprite, fire, progress;
    private Furnace furnace;

    public FurnaceUI(Game1 g, Furnace furnace)
    {
        this.furnace = furnace;
        this.sprite = new Sprite(Textures.melting);
        this.fire = new Sprite(Textures.fireIcon);
        this.progress = new Sprite(Textures.doneArrow);
        this.X = 90;
        this.Y = 140;
        Width = 239 * 4;
        Height = 104 * 4;
        Add(new ItemDisplayer(g.pageGame.player.inventory, 8, 5, 210, 180, g));
        Add(new ItemDisplayer(furnace.FuelContailer, furnace.FuelContailer.Xrows, furnace.FuelContailer.Yrows,  Width - 180, 400, g));
        Add(new ItemDisplayer(furnace.FinishedContainer, furnace.FinishedContainer.Xrows, furnace.FinishedContainer.Yrows, Width - 10, 210, g));
        Add(new ItemDisplayer(furnace.MeltingContainer, furnace.MeltingContainer.Xrows, furnace.MeltingContainer.Yrows, Width - 180, 210, g));

        }
        public override void Draw(Game1 g)
    {
            sprite.Draw(GetPos(g), Width, Height, depth);

            //TODO lmao fix this fire animation
            int fireCrop = (int)(32 * furnace.GetFirePercentLeft());

            Rectangle firePos = new Rectangle(Width - 595, 680-(int)(128 * furnace.GetFirePercentLeft()), 128, (int)(128*furnace.GetFirePercentLeft()));
            
            fire.Draw(firePos, (float)(depth * 0.1), 
                new Rectangle(0, 32 - fireCrop, 32, fireCrop)
               );

            //int progressCrop = (int)(128 * furnace.GetMeltingPercentLeft());
            //progress.Draw(new Rectangle(Width - 400, 210, progressCrop, 128), new Rectangle(0, 0, progressCrop, 32), (float)(depth * 0.1));
            base.Draw(g);
    }
   
}
}
