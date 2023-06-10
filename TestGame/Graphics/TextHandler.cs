using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGame.Graphics
{
    public static class TextHandler
    {
        public static float GetFitScale(string text, float width)
        {
            return width/TextHandler.textLength(text);
        }
        public static float textLength(string text)
        {
            return Textures.font.MeasureString(text).X;
        }
        public static float textHeight(string text)
        {
            return Textures.font.MeasureString(text).Y;
        }
        public static List<string> FitText(string text, float containerWidth, float fontScale=1f)
        {
            List<string> lines = new List<string>();
            //Debug.W
            if(TextHandler.textLength(text)* fontScale > containerWidth)
            {
                
                
                string[] entireString = text.Split(" ");
                string line = entireString[0];
                string finalString = line;
                for (int i=1;i<entireString.Length;i++)
                {
                    line += " "+ entireString[i];
                    if(TextHandler.textLength(line) * fontScale > containerWidth)
                    {
                        lines.Add(finalString);
                        lines.AddRange(FitText(
                            String.Join(" ",entireString.Skip(i).Take(entireString.Length-i).ToArray()), 
                            containerWidth, 
                            fontScale));
                        return lines;
                    }
                    finalString = line;
                }
                lines.Add(finalString);
            }
            else
            {
                lines.Add(text);
            }
            return lines;
        }
    }
}
