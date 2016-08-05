using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TRPL_4
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D MainMenuTexture;
        
        ContentLoad ContentLoader = new ContentLoad();
        Background Backgr = new Background();

        int ScreenHeight;
        int ScreenWidth;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //graphics.PreferredBackBufferWidth = 1300;
            //graphics.PreferredBackBufferHeight = 650;
            graphics.PreferredBackBufferWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            graphics.PreferredBackBufferHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            IsMouseVisible = true;
            graphics.IsFullScreen = false;
        }
        
        protected override void Initialize()
        {

            base.Initialize();
        }


        protected override void LoadContent()
        {
            ScreenWidth = GraphicsDevice.Viewport.Width;
            ScreenHeight = GraphicsDevice.Viewport.Height;

            spriteBatch = new SpriteBatch(GraphicsDevice);
            ContentLoader.StarsBackTexture = Content.Load<Texture2D>(@"Textures\StarsBack");
            MainMenuTexture = Content.Load<Texture2D>(@"Menu\MainMenu1");

            Backgr.extContentLoad(ContentLoader, ScreenHeight, ScreenWidth);
        }
        

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            
        }


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            Backgr.UpdateBackground();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            Backgr.DrawBack(spriteBatch);
            spriteBatch.Draw(MainMenuTexture, new Vector2((ScreenWidth/2) - (MainMenuTexture.Width / 2), (ScreenHeight / 2) - (MainMenuTexture.Height / 2)), Color.White);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
