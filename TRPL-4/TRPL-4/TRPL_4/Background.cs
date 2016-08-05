using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TRPL_4
{
    class Background
    {
        ContentLoad Contentloader;
        Vector2 BackgroundPosition1;
        Vector2 BackgroundPosition2;
        Rectangle Back1;
        Rectangle Back2;

        int Velocity = 1;
        int ScreenHeight;
        int ScreenWidth;

        public void extContentLoad(ContentLoad extContentLoader, int extScreenHeight, int extScreenWidht)
        {
            ScreenHeight = extScreenHeight;
            ScreenWidth = extScreenWidht;
            Contentloader = extContentLoader;
            Back1 = new Rectangle(0, 0, extScreenWidht, ScreenHeight);
            Back2 = new Rectangle(0, -ScreenHeight, extScreenWidht, ScreenHeight);
        }
        public void UpdateBackground()
        {
            if (Back1.Y > ScreenHeight)
            {
                Back1.Y = (-ScreenHeight);
            }
            if (Back2.Y > ScreenHeight)
            {
                Back2.Y = (-ScreenHeight);
            }
            Back1.Y += Velocity;
            Back2.Y += Velocity;
        }

        // Отрисовка ниже точки бэкграунда
        public void Draw1(SpriteBatch spriteBatch)
        {
            while (BackgroundPosition1.Y < Back1.Height)
            {
                while (BackgroundPosition1.X < Back1.Width)
                {
                    //RenderPoint.X += Contentloader.StarsBackTexture.Width;
                    spriteBatch.Draw(Contentloader.StarsBackTexture, BackgroundPosition1, Color.White);
                    BackgroundPosition1.X += Contentloader.StarsBackTexture.Width;
                }
                BackgroundPosition1.X = Back1.X;
                BackgroundPosition1.Y += Contentloader.StarsBackTexture.Height;
            }
            BackgroundPosition1.Y = Back1.Y;
        }
        public void Draw2(SpriteBatch spriteBatch)
        {
            BackgroundPosition2.Y = Back2.Y;
            while (BackgroundPosition2.Y < Back2.Height)
            {
                while (BackgroundPosition2.X < Back2.Width)
                {
                    //RenderPoint.X += Contentloader.StarsBackTexture.Width;
                    spriteBatch.Draw(Contentloader.StarsBackTexture, BackgroundPosition2, Color.White);
                    BackgroundPosition2.X += Contentloader.StarsBackTexture.Width;
                }
                BackgroundPosition2.X = Back2.X;
                BackgroundPosition2.Y += Contentloader.StarsBackTexture.Height;
            }
            
        }
        public void DrawBack(SpriteBatch spriteBatch)
        {
            if (Back1.Y > Back2.Y)
            {
                Draw2(spriteBatch);
                Draw1(spriteBatch);
            }
            else
            {
                Draw1(spriteBatch);
                Draw2(spriteBatch);
            }

        }
    }
}
