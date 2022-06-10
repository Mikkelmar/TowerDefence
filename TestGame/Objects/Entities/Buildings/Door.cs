using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Graphics;

namespace TestGame.Objects.Entities.Buildings
{
    public class Door : Building
    {
        private int sceeneId;
        private Vector2 playerPos;
        public Door(int x, int y, int sceeneId, Vector2 playerPos) : base(x,y,16*2,16*3,0, new Sprite(Textures.spriteSheet_1, new Rectangle(16 * 6, 16 * 10, 32, 16*3)))
        {
            this.sceeneId = sceeneId;
            this.playerPos = playerPos;
        }
        public override void Update(GameTime gt, Game1 g)
        {
        }
        public override Predicate<Item> CanDestroy()
        {
            return p => false;
        }

        protected override void Open(Game1 g)
        {
            g.pageGame.sceneManager.gotoScene(g, sceeneId);
            g.pageGame.player.position = playerPos;
        }
    }
}
