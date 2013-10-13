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

namespace MainMenu
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public enum States { Options, Gameplay };
        MainMenu main = new MainMenu();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1400;
            graphics.PreferredBackBufferHeight = 900;
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            main.getResolution(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            main.load(Content);

                // text positions
                main.position[0] = new Vector2
                (graphics.PreferredBackBufferWidth / 24, graphics.PreferredBackBufferHeight / 4);

                main.position[1] = main.position[0] + new Vector2

                (0, graphics.PreferredBackBufferHeight / 4);
                main.position[2] = main.position[1] + new Vector2

                (0, graphics.PreferredBackBufferHeight / 4);

                // text bounding boxes
                main.box[0] = new Rectangle((int)main.position[0].X, (int)main.position[0].Y,
        (int)main.fontSmall.MeasureString(main.Option[0]).X, (int)main.fontSmall.MeasureString(main.Option[0]).Y);

                main.box[1] = new Rectangle((int)main.position[1].X, (int)main.position[1].Y,
        (int)main.fontSmall.MeasureString(main.Option[1]).X, (int)main.fontSmall.MeasureString(main.Option[1]).Y);

                main.box[2] = new Rectangle((int)main.position[2].X, (int)main.position[2].Y,
        (int)main.fontSmall.MeasureString(main.Option[2]).X, (int)main.fontSmall.MeasureString(main.Option[2]).Y);
            
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            main.update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.LinearWrap, DepthStencilState.Default, RasterizerState.CullNone);
            main.draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
