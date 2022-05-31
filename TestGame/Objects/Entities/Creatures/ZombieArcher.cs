using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Containers.Items.ItemList;
using TestGame.Graphics;

namespace TestGame.Objects.Entities.Creatures
{
    public class ZombieArcher : Hostile
    {
        private Bow bow;
        public ZombieArcher(int x, int y, int w=100, int h= 100) : base(x, y, w, h, 3, Textures.zombieAcrher)
        {
            this.Speed = 140;
            this.Health = 20;
            this.Name = "ZombieArcher";
            bow = new Bow();
            this.loot = new MultiBow();
        }
        public override void Update(GameTime gt, Game1 g)
        {
            if (CanAttack())
            {
                if(CanSee(g.pageGame.player, 600)){
                    Attack(g);
                }
            }
            else
            {
                RechargeAttack(gt);
            }
            HandleMovment(g);
        }
        protected override void Attack(Game1 g)
        {
            base.Attack(g);
            Vector2 direction = bow.GetArrowDirection(GetPosCenter(), g.pageGame.player.position);
            bow.Shoot(GetPosCenter(), new IronArrow(), direction, this, g);
        }
        private void HandleMovment(Game1 g)
        {
            Player player = g.pageGame.GetPlayer();
            if (player.DistanceTo(this.position) <= 600)
            {
                float _speed = Speed * Drawing.delta;

                if (player.DistanceTo(this.position) <= 300)
                {
                    _speed *= -1;
                }
                else if (player.DistanceTo(this.position) <= 400)
                {
                    return;
                }
                MoveTowards(player, g, _speed);
            }
        }
    }
}
