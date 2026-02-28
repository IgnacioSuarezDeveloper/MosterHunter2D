using Microsoft.Xna.Framework.Graphics;

using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;




namespace MonoGame
{
    internal class MainCharacter : Entity
    {
        #region properties
            protected float speed = 4;
            protected Texture2D VerticalTexture;
            protected Texture2D HorizontalTexture;

            public float Speed 
        {
            get { return speed; }
        }//Speed;
        #endregion

        #region methods
            public MainCharacter(ContentManager content, string imageName, int posX, int posY, Vector2 size, int dividendo) : base(content, imageName,posX,posY, size, dividendo) 
        {
            LoadAnimationImages("PersonajeCaminaVertical", "PersonajeCaminaHorizontal", content);
        }
            public void LoadAnimationImages(string verticalSprite,string horizontalSprite, ContentManager content)
        {
            VerticalTexture = content.Load<Texture2D>(verticalSprite);
            HorizontalTexture = content.Load<Texture2D>(horizontalSprite);
        }
            public  void Movement()//movimiento del muñeco en x y en y segun la tecla presionada.
       {
            if (KeyBoardDetection.W)
            {
               // this.posY -= this.speed;
            }
            if (KeyBoardDetection.A)
            { 
                //this.posX -= this.speed;
            }
            if (KeyBoardDetection.S)
            {
                //this.posY += this.speed;
            }
            if(KeyBoardDetection.D)
            {
                //this.posX += this.speed;
            }
        }//SetPosition()
            public void Draw(SpriteBatch _spriteBatch) //dibuja la imagen recortada por el sprite que quiero.
        {
            _spriteBatch.Draw(Texture, new Rectangle((int)posX, (int)posY, (int)size.X, (int)size.Y),sourceRect,Color.White); // Pintar imagen
        }//Renderer();
            public async Task Animation() //character sprite animation. 
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
                    if (sourceRect.X < size.X / 2 -10)
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
        #endregion
    }
}
