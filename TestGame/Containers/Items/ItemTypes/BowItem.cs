using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Graphics;
using TestGame.Objects;
using TestGame.Objects.Entities;
using TestGame.Objects.Entities.Creatures;

namespace TestGame.Containers.Items.ItemTypes
{
    public abstract class BowItem : Weapon
    {
        protected int FireSpeed = 630;
        public BowItem(Sprite sprite, string name, int Damage, int ammount = 1)
                   : base(sprite, name, Damage, ammount)
        {}
        public Vector2 GetArrowDirection(Vector2 fromPos, Vector2 toPos)
        {
            Vector2 dir = new Vector2(toPos.X - fromPos.X, toPos.Y - fromPos.Y);
            return dir = new Vector2(dir.X * 1 / dir.Length(), dir.Y * 1 / dir.Length());
        }
        protected override void Attack(float x, float y, Game1 g)
        {
            Vector2 direction = GetArrowDirection(g.pageGame.player.GetPosCenter(), new Vector2(x,y));
            Arrow arrowItem = (Arrow)g.pageGame.player.inventory.RemoveAmmountPredicate((i) => i.itemType == Item.ItemType.Arrow, 1);
            Shoot(g.pageGame.player.GetPosCenter(), arrowItem, direction, g.pageGame.player, g);
        }

        public virtual void Shoot(Vector2 fromPos, Arrow arrowItem, Vector2 direction, Creature caster, Game1 g)
        {
            ArrowProjectile arrow = new ArrowProjectile(
                fromPos.X,
                fromPos.Y,
                arrowItem.Sprite,
                Damage,
                FireSpeed,
                direction,
                caster,
                arrowItem
                );
            g.pageGame.objectManager.Add(arrow, g);
        }
        public virtual void Shoot(ArrowProjectile arrow, Game1 g)
        {
            g.pageGame.objectManager.Add(arrow, g);
        }
        public override bool CanUse(Entity user, Game1 g)
        {
            if (!g.pageGame.player.inventory.Contain((i) => i.itemType == Item.ItemType.Arrow && i.Ammount > 0)) { return false; }
            return base.CanUse(user, g);
        }
        public override void Activate(Entity user, float x, float y, Game1 g, bool leftClick)
        {
            if (CanUse(user, g))
            {
                Attack(x, y, g);
            }
        }
    }
}
