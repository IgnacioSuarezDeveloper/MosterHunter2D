using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace MonoGame
{
    public enum Type
    {
        None,
        Grass,
        House,
        Watter,
        Bush,
        Arena,
    }
    internal class Entity
    {
        #region propiedades
        protected Texture2D Texture;
        protected Vector2 size;
        protected float posX;
        protected float posY;
        protected Rectangle sourceRect;
        protected Type type;

        public Type Type
        {
            get { return type; }
        }
        public Texture2D TEXTURE
        {
            get {  return Texture; }
            set { Texture = value; }
        }
        public Vector2 SIZE
        {
            get { return size; }
            set { size = value; }
        }
        public float Posx
        {
            get { return posX; }
            set { posX = value; }
        }
        public float Posy
        {
            get { return posY; }
            set { posY = value; }
        }
        #endregion

        #region metodos

        public Entity(ContentManager content, string imageName, int posX, int posY, Vector2 size, int dividendo) 
        {
            this.Texture = content.Load<Texture2D>(imageName);
            this.posX = posX;
            this.posY = posY;
            this.size = size;
            sourceRect = new Rectangle(0, 0, (int)size.X / dividendo, (int)size.Y / dividendo);
            string typeOfImage = imageName.Split('.')[0];
            switch (typeOfImage)
            {
                case "h":
                    type = Type.Grass;
                    break;
                case "c":
                    type = Type.House;
                    break;
                case "a":
                    type = Type.Arena;
                    break;
                case "w":
                    type = Type.Watter;
                    break;
                case "b":
                    type = Type.Bush;
                    break;
            }
        }
        public void Draw(SpriteBatch _spriteBatch) //dibuja la imagen recortada por el sprite que quiero.
        {
            _spriteBatch.Draw(Texture, new Rectangle((int)this.posX, (int)this.posY, (int)size.X, (int)size.Y), Color.White); // Pintar imagen
        }//Renderer();
        #endregion

    }
}
