using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace CrossPlatformDesktop
{
    class Line
    {
        Texture2D m_texture; //base for the line texture
        private Vector2 m_start;
        private Vector2 m_end;

        public Line(
            GraphicsDevice a_graphicsDevice,
            Vector2 a_start,
            Vector2 a_end,
            Color a_colour)
        {
            m_start = a_start;
            m_end = a_end;

            m_texture = new Texture2D(a_graphicsDevice, 1, 1);
            m_texture.SetData<Color>(
                new Color[] { a_colour });// fill the texture with white
        }

        public void draw(SpriteBatch a_spriteBatch, GameTime a_gameTime)
        {
            Vector2 edge = m_end - m_start;
            // calculate angle to rotate line
            float angle =
                (float)Math.Atan2(edge.Y, edge.X);


            a_spriteBatch.Draw(m_texture,
                new Rectangle(// rectangle defines shape of line and position of start of line
                    (int)m_start.X,
                    (int)m_start.Y,
                    (int)edge.Length(), //sb will strech the texture to fill this rectangle
                    1), //width of line, change this to make thicker line
                null,
                Color.Red, //colour of line
                angle,     //angle of line (calulated above)
                new Vector2(0, 0), // point in line about which to rotate
                SpriteEffects.None,
                0);
        }
    }
   
}
