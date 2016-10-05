﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml;

using System.IO;

namespace EzEngine
{
    public class Engine : Game, IEngine
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch m_spriteBatch;
        private Texture2D m_hero;
        private SpriteFont m_font;
        private uint m_score = 0;
        private string m_levelName;
        private Boolean m_backPressed = false;

        public Engine()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            m_spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            m_font = Content.Load<SpriteFont>("Score"); // Use the name of your sprite font file here instead of 'Score'.
            m_hero = Content.Load<Texture2D>("hero");
            //Typeface tf = Typeface.CreateFromAsset (Context.Assets, "fonts/samplefont.ttf");
            Stream s = TitleContainer.OpenStream(@".\Content\level1.xml");

            XmlDocument doc = new XmlDocument();
            doc.Load(s);
            XmlNode levelNode = doc.SelectSingleNode("Level");
            XmlNode levelNameNode = levelNode.SelectSingleNode("m_name");
            m_levelName = levelNameNode.InnerText;


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (!m_backPressed)
            {
                m_backPressed = GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed;
            }

            m_score++;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (m_drawCallback != null)
            {
                m_drawCallback(gameTime.ElapsedGameTime.Milliseconds);
            }

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            m_spriteBatch.Begin();

            m_spriteBatch.Draw(m_hero, new Vector2(400, 240), Color.White);
            m_spriteBatch.DrawString(m_font, "Level " + m_levelName + " Score: " + m_score, new Vector2(100, 100), Color.Black);
            m_spriteBatch.DrawString(m_font, "Back: " + m_backPressed,
                new Vector2(100, 130), Color.Black);
            //m_spriteBatch.DrawLine(200, 200, 300, 250, Color.Yellow);
            //m_spriteBatch.DrawCircle(400, 100, 90, 3, Color.White * 0.2f);

            m_spriteBatch.End();

            base.Draw(gameTime);
        }

        public void drawLine()
        {
            throw new NotImplementedException();
        }

        private DrawDelegate m_drawCallback;
        public void registerForDraw(DrawDelegate a_drawCallback)
        {
            m_drawCallback = a_drawCallback;
        }
    }
}
