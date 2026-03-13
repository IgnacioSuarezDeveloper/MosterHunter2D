using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;




namespace MonoGame
{
    internal class MainCharacter : Entity
    {
        #region properties
        protected float speed = 3;
        protected Texture2D VerticalTexture;
        protected Texture2D HorizontalTexture;
        public Object[] inventory;
        public float Speed //solo lectura para usar la speed del jugador
        {
            get { return speed; }
        }//Speed;
        #endregion

        #region methods

        //constructor.
        public MainCharacter(ContentManager content, string imageName, int posX, int posY, Vector2 size, int dividendo) : base(content, imageName, posX, posY, size, dividendo)
        {
            LoadAnimationImages("PersonajeCaminaVertical", "PersonajeCaminaHorizontal", content);
            inventory = new Object[10];
        }//MainCharacter.

        //carga las imagenes de las animaciones.
        public void LoadAnimationImages(string verticalSprite, string horizontalSprite, ContentManager content) 
        {
            VerticalTexture = content.Load<Texture2D>(verticalSprite);
            HorizontalTexture = content.Load<Texture2D>(horizontalSprite);
        }//LoadAnimationImages.

        //movimiento del muñeco en x y en y segun la tecla presionada.
        public void Movement()
        {
            int futureposx = (int)this.posX;
            int futureposy = (int)this.posY;
            if (KeyBoardDetection.W)
            {
                futureposy = (int)this.posY - (int)this.speed;
                if (!Colides.PlayerFutureColidHouses(this, futureposx, futureposy))
                {
                    this.posY = futureposy;
                }
            }
            if (KeyBoardDetection.A)
            {
                futureposx = (int)this.posX - (int)this.speed;
                if (!Colides.PlayerFutureColidHouses(this, futureposx, futureposy))
                {
                    this.posX = futureposx;
                }

            }
            if (KeyBoardDetection.S)
            {
                futureposy = (int)this.posY + (int)this.speed;
                if (!Colides.PlayerFutureColidHouses(this, futureposx, futureposy))
                {
                    this.posY = futureposy;
                }
            }
            if (KeyBoardDetection.D)
            {
                futureposx = (int)this.posX + (int)this.speed;
                if (!Colides.PlayerFutureColidHouses(this, futureposx, futureposy))
                {
                    this.posX = futureposx;
                }
            }
        }//Movement.

        //dibuja la imagen recortada por el sprite que quiero.
        public void Draw(SpriteBatch _spriteBatch) 
        {
            _spriteBatch.Draw(Texture, new Rectangle((int)posX, (int)posY, (int)size.X, (int)size.Y), sourceRect, Color.White); // Pintar imagen
        }//Renderer();

        //animaciones del personaje al caminar. 
        public async Task Animation() 
        {
            while (true)
            {
                if (KeyBoardDetection.S)
                {
                    TEXTURE = VerticalTexture;

                    sourceRect.Y = 0;
                    if (sourceRect.X < size.X / 2)
                    {
                        sourceRect.X = 50;
                    }
                    else if (sourceRect.X >= size.Y / 2)
                    {
                        sourceRect.X = 0;
                    }
                }
                if (KeyBoardDetection.W)
                {
                    TEXTURE = VerticalTexture;

                    sourceRect.Y = 50;
                    if (sourceRect.X < size.X / 2)
                    {
                        sourceRect.X = 50;
                    }
                    else if (sourceRect.X >= size.Y / 2)
                    {
                        sourceRect.X = 0;
                    }
                }


                if (KeyBoardDetection.A)
                {
                    TEXTURE = HorizontalTexture;
                    sourceRect.Y = 50;
                    if (sourceRect.X < size.X / 2 - 10)
                    {
                        sourceRect.X = (int)size.X / 2 - 10;
                    }
                    else if (sourceRect.X >= size.Y / 2 - 10)
                    {
                        sourceRect.X = 0;
                    }
                }
                if (KeyBoardDetection.D)
                {
                    TEXTURE = HorizontalTexture;
                    sourceRect.Y = 0;
                    if (sourceRect.X < size.X / 2 - 10)
                    {
                        sourceRect.X = (int)size.X / 2 - 10;
                    }
                    else if (sourceRect.X >= size.X / 2 - 10)
                    {
                        sourceRect.X = 0;
                    }
                }
                await Task.Delay(Game1.FPS);
            }

        }//Animation();

        //añade objeto al inventario.
        public void ObjectAdd(Object objeto)
        {
            for(int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null)
                {
                    inventory[i] = objeto;
                    break;
                }
                else
                {
                    Debug.WriteLine("lo siento inventario lleno");
                }
            }
        }//ObjectAdd.

        //jugador cogiendo objetos.
        public void GrabingObjects(ContentManager Content) 
        {
            string colideObject = Colides.PlayerColideObjects(this);
            string colision = colideObject.Split(",")[0].ToString();
            string type = colideObject.Split(",")[1].ToString();
            int index = -1;
            if (colideObject.Split(",")[2] != "none")
            {
                index = int.Parse(colideObject.Split(",")[2]);
            }
            
            if (colision == "true" && type == Type.Rock.ToString() && KeyBoardDetection.E == true)
            {
                Debug.WriteLine("colisionando con roca");
                for(int i = 0; i < inventory.Length; i++)
                {
                    if (inventory[i] == null)
                    {
                        inventory[i] = new Object(Content, "r", 0, 0, new Vector2(100, 100), 1, Type.Rock);
                        Object.DeleteObject(Object.Objetos,Content,index);
                        break;
                    }
                }
            }
        }
        #endregion
    }
}
