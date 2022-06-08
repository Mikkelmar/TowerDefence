using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using TestGame.Containers;
using TestGame.Containers.Items;
using TestGame.Containers.Items.ItemTypes;
using TestGame.Graphics;
using TestGame.Huds.ActiveHuds;
using TestGame.Managers;
using TestGame.Objects.Entities.Creatures;

namespace TestGame.Objects
{
    public class Player : Creature, RightClickable, Clickable
    {
        public SlotContainer inventory; //{ get { return inventory; } }
        public List<SpecializedSlotContainer> Wearing;
        //input
        KeyboardState kb;
        public bool canMove = true;
        private bool down = false;
        public int ActiveSlot = 0;
        public Player(int x, int y) : base(x, y, 32, 32, ObjectsID.player, Textures.player)
        {
            Speed = 200f;
            Health = 10;
            DisplayHealth = false;
            collision = true;
            this.hitbox = new Rectangle(9, 18, 14, 14);
        }

        public override void Destroy(Game1 g)
        {
            g.pageGame.mouseManager.Remove(this);
            g.pageGame.mouseManager.RemoveRight(this);
        }


        public override void Init(Game1 g)
        {
            this.inventory = new SlotContainer(24);
            g.pageGame.mouseManager.Add(this, true);
            g.pageGame.mouseManager.AddRight(this, true);

            Wearing = new List<SpecializedSlotContainer>();
            Wearing.Add(new SpecializedSlotContainer(1, Item.ItemType.Helmet, 1, 1));
            Wearing.Add(new SpecializedSlotContainer(1, Item.ItemType.Chest, 1, 1));
            Wearing.Add(new SpecializedSlotContainer(1, Item.ItemType.Legs, 1, 1));
            Wearing.Add(new SpecializedSlotContainer(1, Item.ItemType.Feet, 1, 1));

            base.Init(g);
        }

        public override void Update(GameTime gt, Game1 g)
        {
            base.Update(gt, g);
            UpdateWearing(g);

            //input
            kb = Keyboard.GetState();
            MovmentInput(g);
            InteractInput(g);
            UpdateIneventory(gt, g);

            if (canMove)
            {
                //move
                this.Move(new Vector2(X + xSpeed, Y + ySpeed), g);
            }

        }
        private void UpdateIneventory(GameTime gt, Game1 g)
        {
            Item holdingItem = inventory.GetItemAtSlot(ActiveSlot);
            if (holdingItem is Useable && ((Useable)holdingItem).IsUsing())
            {
                ((Useable)holdingItem).Update(this, gt, g);
            }
        }
        public override void Draw(Game1 g)
        {
            //Drawing.FillRect(GetHitbox(), Color.Red, depth*1.1f, g); //Debug hitboxes
            base.Draw(g);
            //inventory.Draw(g);
        }
        private void InteractInput(Game1 g)
        {
            if (kb.IsKeyDown(Keys.E))
            {
                if (down == false)
                {
                    down = true;
                    HudManager hm = g.pageGame.hudManager;
                    if (hm.activeUI == null)
                    {
                        hm.Open(new InventoryUI(g), g);
                    }
                    else
                    {
                        hm.Close(g);
                    }
                    //g.pageGame.hudManager
                }
            }
            else
            {
                down = false;
            }
            if (kb.IsKeyDown(Keys.R))
            {
                g.pageGame.sceneManager.gotoScene(g, 1);
            }
            setActiveSlot(new List<Keys> { Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8 });
        }
        private void setActiveSlot(List<Keys> keys)
        {
            for (int index = 0; index < keys.Count; index++)
            {
                if (kb.IsKeyDown(keys[index]))
                {
                    ActiveSlot = index;
                    return;
                }
            }

        }
        private void MovmentInput(Game1 g)
        {
            float _speed = Speed * Drawing.delta;
            // pressed
            if (kb.IsKeyDown(Keys.W)) { ySpeed = -_speed; }
            if (kb.IsKeyDown(Keys.S)) { ySpeed = _speed; }
            if (kb.IsKeyDown(Keys.A)) { xSpeed = -_speed; }
            if (kb.IsKeyDown(Keys.D)) { xSpeed = _speed; }

            // released
            if (kb.IsKeyUp(Keys.W) && kb.IsKeyUp(Keys.S)) { ySpeed = 0; }
            if (kb.IsKeyUp(Keys.A) && kb.IsKeyUp(Keys.D)) { xSpeed = 0; }

            if (xSpeed != 0 && ySpeed != 0)
            {
                ySpeed = (float)(ySpeed * 0.69);
                xSpeed = (float)(xSpeed * 0.69);
            }
        }

        public override void Die(Game1 g)
        {
            Debug.WriteLine("YOU DIED!");
            //throw new System.NotImplementedException();
        }
        private void UpdateWearing(Game1 g)
        {
            int totalArmout = 0;
            foreach (Item item in GetWearing())
            {
                if (item is Armour)
                {
                    totalArmout += ((Armour)item).Defencepoint;
                    ((Armour)item).Wearing(this, g);
                }
            }
            Armour = totalArmout;
        }
        public List<Item> GetWearing()
        {
            List<Item> wearing = new List<Item>();
            foreach (SpecializedSlotContainer slc in Wearing)
            {
                Item i = slc.GetItemAtSlot(0);
                if (i != null)
                {
                    wearing.Add(i);
                }
            }
            return wearing;
        }
        public void RightClicked(float x, float y, Game1 g)
        {
            Click(x, y, g, false);
        }
        public void Clicked(float x, float y, Game1 g)
        {
            Click(x, y, g, true);
        }
        private void Click(float x, float y, Game1 g, bool isLeftClick)
        {
            if (inventory.GetItemAtSlot(ActiveSlot) is Containers.Items.ItemTypes.Useable
                && ((Containers.Items.ItemTypes.Useable)inventory.GetItemAtSlot(ActiveSlot)).UseableOnClick(isLeftClick))
            {
                ((Containers.Items.ItemTypes.Useable)inventory.GetItemAtSlot(ActiveSlot)).Activate(this, x, y, g, isLeftClick);
            }
        }
    }
       
}
