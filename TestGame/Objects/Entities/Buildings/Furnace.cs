using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestGame.Containers;
using TestGame.Containers.Items;
using TestGame.Containers.Items.ItemTypes;
using TestGame.Graphics;
using TestGame.Huds.ActiveHuds;

namespace TestGame.Objects.Entities.Buildings
{
    public class Furnace : Building
    {

        public SpecializedSlotContainer FuelContailer, MeltingContainer;
        public SlotContainer FinishedContainer;
        private TimeSpan fireLeft = new TimeSpan();
        private TimeSpan totalFireTime = new TimeSpan();
        private TimeSpan timeLeft = new TimeSpan(0);
        private readonly TimeSpan smeltingTime = new TimeSpan(0, 0, 6);
        public Furnace(int x, int y) : base(x, y, 32, 32, 5, new Sprite(Textures.spriteSheet_1, new Rectangle(16 * 31, 16 * 13, 32, 32)))
        {
            this.solid = true;
            FuelContailer = new SpecializedSlotContainer(1, Item.ItemType.Fuel, 1, 1);
            MeltingContainer = new SpecializedSlotContainer(1, Item.ItemType.Meltable, 1, 1);
            FinishedContainer = new SlotContainer(1, 1, 1);
           // hitbox = new Rectangle(0, 30, 95, 65);
        }
        public override void Update(GameTime gt, Game1 g)
        {
            if (fireLeft.Ticks <= 0)
            {
                Item melting = MeltingContainer.GetItemAtSlot(0);
                if (melting != null)
                {
                    Item fuel = FuelContailer.GetItemAtSlot(0);
                    if (fuel != null)
                    {
                        FuelContailer.RemoveAmmount(fuel, 1);
                        TimeSpan getFuel = ((Fuel)fuel).GetFuelTime(); //get fuel ammount from fire
                        fireLeft = getFuel;
                        totalFireTime = getFuel;
                    }
                }
            }
            else
            {
                fireLeft = fireLeft.Subtract(gt.ElapsedGameTime);
                Item melting = MeltingContainer.GetItemAtSlot(0);

                if (melting != null)
                {
                    timeLeft = timeLeft.Add(gt.ElapsedGameTime);
                    if (timeLeft.Ticks >= smeltingTime.Ticks)
                    {
                        Item i = ((MeltAble)melting).GetMeltsTo();
                        if (FinishedContainer.CanAdd(i))
                        {
                            MeltingContainer.RemoveAmmount(melting, 1);
                            FinishedContainer.Add(i);
                        }
                        timeLeft = new TimeSpan(0);
                    }
                }
                
                
            }
        }
        public float GetFirePercentLeft()
        {
            return (float)fireLeft.Ticks/totalFireTime.Ticks;
        }
        public float GetMeltingPercentLeft()
        {
            return (float)timeLeft.Ticks / smeltingTime.Ticks;
        }

        protected override void Open(Game1 g)
        {
            g.pageGame.hudManager.Open(new FurnaceUI(g, this), g);
        }
    }
}
