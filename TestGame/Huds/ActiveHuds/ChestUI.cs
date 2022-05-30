using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Containers;
using TestGame.Graphics;
using TestGame.Managers;

namespace TestGame.Huds.ActiveHuds
{
    public class ChestUI : ActiveUI
    {
 
    private ItemDisplayer itemDisplayer, itemDisplayer2;
    private Sprite sprite;

    public ChestUI(Game1 g, SlotContainer slotContainer)
    {
        sprite = new Sprite(Textures.inevntoryUI);
        X = 90;
        Y = 140;
        Width = 166 * 4;
        Height = 104 * 4;
        itemDisplayer = new ItemDisplayer(g.pageGame.player.inventory, 8, 5, 210, 180, g);
        itemDisplayer2 = new ItemDisplayer(slotContainer, slotContainer.Xrows, slotContainer.Yrows, 90 + Width, 180, g);
        Add(itemDisplayer);
        Add(itemDisplayer2);
    }
    public override void Draw(Game1 g)
    {
        sprite.Draw(GetPos(g), Width, Height, depth);
        base.Draw(g);
    }
   
}
}
