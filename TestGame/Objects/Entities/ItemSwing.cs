using Microsoft.Xna.Framework;
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
    public class ItemSwing : ItemHolding
    {
        public ItemSwing (int x, int y, int w, int h, Weapon item, float startRotation) : base((int)x, (int)y, w, h, item, startRotation) {
        }
        public ItemSwing(Entity user, int w, int h, Weapon item, float startRotation) : base(user, w, h, item, startRotation) {
        }

        public override void Update(GameTime gt, Game1 g)
        {
            base.Update(gt, g);
            //var transformed = Vector2.Transform(dir, Matrix.CreateRotationX());
            checkIfDoneAttacking(gt, g);
            checkForHits(g);
            rotateItem(g);
        }

    }
}
