using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Containers.Items.ItemTypes;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects.Entities.Creatures;
using TestGame.Objects.StatusEffects;

namespace TestGame.Objects.Entities
{
    public class ItemPush : ItemHolding
    {
        public ItemPush(int x, int y, int w, int h, Weapon item, float startRotation) : base((int)x, (int)y, w, h, item, startRotation) {
            offSetX = (float)(Math.Cos(startRotation + (Math.PI / 4)))* 10;
            offSetY = (float)(Math.Sin(startRotation + (Math.PI / 4)))* 10;
        }
        public ItemPush(Entity user, int w, int h, Weapon item, float startRotation) : base(user, w, h, item, startRotation) {
            offSetX = (float)(Math.Cos(startRotation + (Math.PI / 4))) * 10;
            offSetY = (float)(Math.Sin(startRotation + (Math.PI / 4))) * 10;
        }
        public override void Update(GameTime gt, Game1 g)
        {
            Push();
            base.Update(gt, g);
            checkIfDoneAttacking(gt, g);
            checkForHits(g);
        }
        private void Push()
        {
           // Vector2 hitPos = new Vector2((float)Math.Cos(rotation + (Math.PI / 8)), (float)Math.Sin(rotation + (Math.PI / 8)));
            offSetX -= (float)(Drawing.delta* Math.Cos(rotation + (Math.PI / 4))) * item.Speed;
            offSetY -= (float)(Drawing.delta* Math.Sin(rotation + (Math.PI / 4))) * item.Speed;
        }

    }
}
