using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    internal static class Menu
    {
        #region propiedades
        static public bool active = true;
        static private Vector2 playButton = new Vector2(100, 100);
        static private Texture2D texture;
        static private Vector2 size = new Vector2(100, 100);
        #endregion

        #region metodos

        //carga la imagen.
        static public void Load(ContentManager content, string imageName) 
        {
            texture = content.Load<Texture2D>(imageName);
        }//load();

        //dibuja la imagen;
        static public void Draw(SpriteBatch _spriteBatch)
        {
            if (active)
            {
                _spriteBatch.Draw(texture, new Rectangle((int)playButton.X, (int)playButton.Y, (int)size.X, (int)size.Y), Microsoft.Xna.Framework.Color.White); // Pintar imagen
            }
        }//Renderer();
        static public void Update()
        {

        }//state();
        #endregion
    }
}
