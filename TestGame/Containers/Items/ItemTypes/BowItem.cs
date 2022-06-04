using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Graphics;
using TestGame.Managers;
using TestGame.Objects;
using TestGame.Objects.Entities;
using TestGame.Objects.Entities.Creatures;
using TestGame.Objects.StatusEffects;

namespace TestGame.Containers.Items.ItemTypes
{
    public abstract class BowItem : Weapon
    {
        protected int FireSpeed = 630;
        protected TimeSpan chargeingTime;
        private bool Chareging = false;
        protected Sprite baseSprite;
        public BowItem(Sprite sprite, string name, int Damage, int ammount = 1)
                   : base(sprite, name, Damage, ammount)
        {
            baseSprite = sprite;
        }
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
        public override bool IsUsing()
        {
            return Chareging;
        }
        public override void Update(Entity user, GameTime gt, Game1 g)
        {
            UpdateTexture();
            g.pageGame.player.AddStatusEffect(new Slow((0.2f/getChargeLevel()), new TimeSpan(0,0,0,0,100)));
            chargeingTime += gt.ElapsedGameTime;
            MouseState newState = Mouse.GetState();
            if (newState.LeftButton == ButtonState.Released)
            {
                Attack(newState.X + g.pageGame.cam.position.X, newState.Y + g.pageGame.cam.position.Y, g);
                Chareging = false;
                g.pageGame.objectManager.Remove(itemHolding, g);
                itemHolding = null;
                Sprite = baseSprite;
            }
            

        }
        protected virtual void UpdateTexture()
        {
            switch ((int)Math.Floor(getChargeLevel()*2)) {
                case 0:
                    Sprite = new Sprite(Textures.spriteSheet_2, getSpriteRect(0, 10));
                    break;
                case 1:
                    Sprite = new Sprite(Textures.spriteSheet_2, getSpriteRect(1, 10));
                    break;
                case 2:
                    Sprite = new Sprite(Textures.spriteSheet_2, getSpriteRect(2, 10));
                    break;
                case 3:
                    Sprite = new Sprite(Textures.spriteSheet_2, getSpriteRect(3, 10));
                    break;
            }
        }
        protected float getChargeLevel()
        {
            return Math.Min(Math.Max((float)(chargeingTime.TotalMilliseconds / 500), 0.5f), 2f);
        }
        public virtual void Shoot(Vector2 fromPos, Arrow arrowItem, Vector2 direction, Creature caster, Game1 g, bool dropArrow=true)
        {
            ArrowProjectile arrow = new ArrowProjectile(
                fromPos.X,
                fromPos.Y,
                arrowItem.Sprite,
                (int)(Math.Max((Damage + arrowItem.Damage)* getChargeLevel(), 1)),
                FireSpeed* getChargeLevel(),
                direction,
                caster,
                arrowItem,
                (150*getChargeLevel()),
                DropProjectile: dropArrow
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
                chargeingTime = new TimeSpan();
                Chareging = true;
                ItemAiming itemAiming = new ItemAiming(user, 64, 64, this,
                    (float)((float)(Math.Atan2(y - user.GetPosCenter().Y, x - user.GetPosCenter().X)) - (Math.PI / 3)));
                g.pageGame.objectManager.Add(itemAiming, g);
                itemHolding = itemAiming;

            }
        }
    }
}
