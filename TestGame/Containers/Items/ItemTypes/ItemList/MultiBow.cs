using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items.ItemTypes;
using TestGame.Graphics;
using TestGame.Objects;

namespace TestGame.Containers.Items.ItemList
{
    public class MultiBow : BowItem
    {
        public MultiBow(int ammount = 1)
            : base(
                new Sprite(Textures.spriteSheet_2, getSpriteRect(1, 2)),
                "Triple Bow",
                ammount)
        {}
        protected override void Attack(float x, float y, Game1 g)
        {
            //TODO: fiks logiken orker ikke nå, var bare fun test
            Vector2 direction = GetArrowDirection(g.pageGame.player.position, new Vector2(x, y));
            Arrow arrowItem = (Arrow)g.pageGame.player.inventory.RemoveAmmountPredicate((i) => i.itemType == Item.ItemType.Arrow, 1);
            Shoot(g.pageGame.player.position, arrowItem, direction, g.pageGame.player, g);

            direction = GetArrowDirection(g.pageGame.player.position, new Vector2(x+64, y));
            arrowItem = (Arrow)g.pageGame.player.inventory.RemoveAmmountPredicate((i) => i.itemType == Item.ItemType.Arrow, 1);
            Shoot(g.pageGame.player.position, arrowItem, direction, g.pageGame.player, g);

            direction = GetArrowDirection(g.pageGame.player.position, new Vector2(x-64, y));
            arrowItem = (Arrow)g.pageGame.player.inventory.RemoveAmmountPredicate((i) => i.itemType == Item.ItemType.Arrow, 1);
            Shoot(g.pageGame.player.position, arrowItem, direction, g.pageGame.player, g);

        }
        public override bool CanUse(Entity e, Game1 g)
        {
            if (!g.pageGame.player.inventory.Contain((i) => i.itemType == Item.ItemType.Arrow && i.Ammount > 2)) { return false; }
            return base.CanUse(e, g);
        }
    }
}
