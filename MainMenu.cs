using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MainMenu
{
    public class MainMenu
    {
        public string[] Option = new string[3] { "Play", "Options", "Exit" };
        public Rectangle[] box = new Rectangle[3];
        public Vector2[] position = new Vector2[3];
        public SpriteFont fontSmall, fontBig;
        public Texture2D backGround;
        public Rectangle Screen;
        public Vector2 origin;
        public int windowWidth, windowHeight;
        Color color = Color.Orange;
        public bool PisHighlighted, OisHighlighted, EisHighlighted;

        // mouse position & control
        public int mX, mY;
        public MouseState CurrentState, PastState;

        public MainMenu()
        {
            backGround = null;
            fontBig = null;
            fontSmall = null;
        }

        public void load(ContentManager Content)
        {
            fontSmall = Content.Load<SpriteFont>("MenuFont");
            fontBig = Content.Load<SpriteFont>("MenuFontBig");
            backGround = Content.Load<Texture2D>("bedrock");
        }

        public void draw(SpriteBatch spriteBatch)
        {
            // menu background
            spriteBatch.Draw(backGround, new Vector2(0,0), Screen, Color.White, 0f, origin, 1f, SpriteEffects.None, 1f );
            // text play // if mouse is inside it's box
            if (box[0].Contains(mX, mY))
            {
                spriteBatch.DrawString(fontBig, Option[0], position[0], color);
            }
            else
            {
                spriteBatch.DrawString(fontSmall, Option[0], position[0], Color.White);
            }
            // text options // if mouse is inside it's box
            if (box[1].Contains(mX, mY))
            {
                spriteBatch.DrawString(fontBig, Option[1], position[1], color);
            }
            else
            spriteBatch.DrawString(fontSmall, Option[1], position[1], Color.White);

            // text exit // if mouse is inside it's box
            if (box[2].Contains(mX, mY))
            {
                spriteBatch.DrawString(fontBig, Option[2], position[2], color);
            }
            else
            spriteBatch.DrawString(fontSmall, Option[2], position[2], Color.White);
        }

        public void update(GameTime gameTime)
        {
           MouseState mouse = Mouse.GetState();
            mX = mouse.X;
            mY = mouse.Y;

            // look through all the boxes to see if the mouse has it's cords in them
            // if so, if the mouse left clicks, change color to yellow
            // instead of turning to yellow, son will be used to change enum to different state
            for (int i = 0; i < box.Length; i++)
            {
                if (mouse.LeftButton == ButtonState.Pressed &&
                    PastState.LeftButton == ButtonState.Released)
                {
                    if (box[i].Contains(mX, mY))
                    {
                        color = Color.Yellow;
                    }
                }
                else color = Color.Orange;
            }
        }
        public void getResolution(int newWindowWidth, int newWindowHeight)
        {
            windowWidth = newWindowWidth;
            windowHeight = newWindowHeight;
            Screen = new Rectangle(0, 0, windowWidth, windowHeight);
        }
    }
}
