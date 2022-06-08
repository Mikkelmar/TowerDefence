using System;
using System.Collections.Generic;
using System.Text;
using TestGame.Containers.Items;
using TestGame.Graphics;

namespace TestGame.Huds
{
    public static class ItemHoverInfo 
    {
        public static void DrawItemInfo(Item item, float x, float y, float depth)
        {
            int length=10;
            int height = 0;
            StringBuilder sb = new StringBuilder();
            length = Math.Max(length, item.Name.Length);
            sb.AppendLine(item.Name);
            height++;

            //length = Math.Max(length, item.itemType.ToString().Length);
            //sb.AppendLine(item.itemType.ToString());
            //height++;

           
            foreach(string d in item.GetDescription())
            {
                length = Math.Max(length, d.Length);
                sb.AppendLine(d);
                height++;
            }
                

            Drawing.DrawText(sb.ToString(), x, y, depth*0.1f);

            new Sprite(Textures.itemContainerTransparent).Draw(new Microsoft.Xna.Framework.Vector2(x-10, y-10), (length*16)+10, (height*30)+10, depth);

        }
    }
}
