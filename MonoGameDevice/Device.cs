using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml;

using System.IO;

using EzEngine;

namespace MonoGameDevice
{
   public class Device :
      Microsoft.Xna.Framework.Game,
      EzEngine.IDevice
   {
      public event EzEngine.UpdateEventHandler updateEvent;
      public event EzEngine.InitEventHander initEvent;
      public event EzEngine.LoadContentEventHandler loadContentEvent;
      public event EzEngine.DrawEventHandler drawEvent;

      // Cache of images. Keep this.
      private Dictionary<string, Texture2D> m_images = new Dictionary<string, Texture2D>();

      private GraphicsDeviceManager graphics;
      private SpriteBatch m_spriteBatch;
      //private Texture2D m_hero;
      private SpriteFont m_font;
      private uint m_score = 0;
      private string m_levelName;
      private Boolean m_backPressed = false;

      public Device()
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

         // TODO: The main app needs to pass a list of available sprite names that
         // can be loaded.
         // Here we need to load these and store in a look-up store
         // against the string name.
         // Same goes for xml and sound files, etc.
         // So need an interface to access xml files via the IDevice interface

         // Call back to EzEngine  
         if (loadContentEvent != null)
         {
            loadContentEvent(this, new EventArgs());
         }


         // Create a new SpriteBatch, which can be used to draw textures.
         m_spriteBatch = new SpriteBatch(GraphicsDevice);

         // TODO: use this.Content to load your game content here
         m_font = Content.Load<SpriteFont>("Score"); // Use the name of your sprite font file here instead of 'Score'.

         // Now done in BooGame.cs
         //loadImage("hero");

         //m_hero = Content.Load<Texture2D>("hero");
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
         // Call back to EzEngine  
         if (updateEvent != null)
         {
            updateEvent(this, new UpdateEventArgs(gameTime.ElapsedGameTime.Milliseconds));
         }



         // TODO: Remove this eventually
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
         // End of remove this eventually





         // TODO: Add your update logic here

         base.Update(gameTime);
      }

      /// <summary>
      /// This is called when the game should draw itself.
      /// </summary>
      /// <param name="gameTime">Provides a snapshot of timing values.</param>
      protected override void Draw(GameTime gameTime)
      {
         GraphicsDevice.Clear(Color.CornflowerBlue);

         m_spriteBatch.Begin();



         // Call back to EzEngine  
         // TODO hopefully ok to do all drawing between the spritebatch.begin and end?
         if (drawEvent != null)
         {
            drawEvent(this, new EventArgs());
         }

         // Now done in BooGame.cs
         //drawImage("hero", new EzEngine.Rectangle(new EzEngine.Coord(0,0),
         //   new EzEngine.Coord(400,240)));

         //// TODO: Remove this eventually
         //m_spriteBatch.Draw(m_hero, new Vector2(400, 240), Color.White);
         m_spriteBatch.DrawString(m_font, "Level: " + m_levelName + 
            " Score: " + m_score, new Vector2(100, 100), Color.Black);
         m_spriteBatch.DrawString(m_font, "Back: " + m_backPressed,
               new Vector2(100, 130), Color.Black);
         //m_spriteBatch.DrawLine(200, 200, 300, 250, Color.Yellow);
         //m_spriteBatch.DrawCircle(400, 100, 90, 3, Color.White * 0.2f);
         // End of remove this eventually




         m_spriteBatch.End();
         
         base.Draw(gameTime);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="a_imageName"></param>
      public void loadImage(string a_imageName)
      {      
         if (!m_images.ContainsKey(a_imageName))
         {
            Texture2D image = Content.Load<Texture2D>(a_imageName);
            if(image == null)
            {
               throw new Exception("Could not load image: " + a_imageName);
            }

            m_images.Add(a_imageName, image);
         }
      }

      /*need another abstract Device that cxan set a view and draw to that 
         view can be 320x240 on whatever res screen and then 
         coords are specified in view coords not screen coords
         or that can be done here?*/

      public void drawImage(string a_imageName, EzEngine.Rectangle a_screenRect)
      {
         if(m_images.ContainsKey(a_imageName))
         {
            if(m_images[a_imageName] != null)
            {
               m_spriteBatch.Draw(
                  m_images[a_imageName],
                  new Microsoft.Xna.Framework.Rectangle(
                     (int)a_screenRect.left,
                     (int)a_screenRect.top,
                     (int)a_screenRect.width,
                     (int)a_screenRect.height),
                  Color.White);
            }
            else
            {
               throw new Exception("Image is invalid: " + a_imageName);
            }
         }
         else
         {
            throw new Exception("Image does not exist: " + a_imageName);
         }

      }

      /// <summary>
      /// Start the device
      /// </summary>
      public void start()
      {
         // Call Xna.Framework.Run
         this.Run();
      }

      public void preLoadImage(string a_imageName)
      {
         loadImage(a_imageName);
         //throw new NotImplementedException();
      }
   }
}
