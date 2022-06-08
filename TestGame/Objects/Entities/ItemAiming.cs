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
    public class ItemAiming : ItemHolding
    {
        public ItemAiming(int x, int y, int w, int h, Weapon item, float startRotation) : base((int)x, (int)y, w, h, item, startRotation) {
        }
        public ItemAiming(Entity user, int w, int h, Weapon item, float startRotation) : base(user, w, h, item, startRotation) {
        }
        public override void Update(GameTime gt, Game1 g)
        {
            base.Update(gt, g);
            rotateItem(g);
        }
        protected override void rotateItem(Game1 g)
        {
            MouseState mouseState = Mouse.GetState();
            //rotation = (float)((float)(-Math.Atan2(mouseState.X - user.GetPosCenter().X, mouseState.Y - user.GetPosCenter().Y)));
            rotation = (float)((float)(Math.Atan2((mouseState.Y + g.gameCamera.Position.Y) - user.GetPosCenter().Y, (mouseState.X + g.gameCamera.Position.X) - user.GetPosCenter().X)) - (Math.PI)- (Math.PI/4));
            //rotation = (float)(rotation - (Math.PI / 4) + Math.PI);
        }

    }
}
