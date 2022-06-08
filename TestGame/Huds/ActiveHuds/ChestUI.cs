using Microsoft.Xna.Framework;
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
        X = 130;
        Y = 120;
        Width = 166 * 4;
        Height = 104 * 4;
        itemDisplayer = new ItemDisplayer(g.pageGame.player.inventory, 8, 5, X+120, Y+40, g);
        itemDisplayer2 = new ItemDisplayer(slotContainer, slotContainer.Xrows, slotContainer.Yrows, X + Width, Y+40, g);
        Add(itemDisplayer);
        Add(itemDisplayer2);
        Add(new ArmourDisplayer(g.pageGame.player.Wearing, new Vector2(X + 9 * 4, Y + 15 * 4), g));
       }
    public override void Draw(Game1 g)
    {
        sprite.Draw(GetPos(g), Width, Height, depth);
        base.Draw(g);
    }
   
}
}
