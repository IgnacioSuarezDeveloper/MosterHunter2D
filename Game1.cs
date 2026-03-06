using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MonoGame
{
    public class Game1 : Game
    {
        #region propiedades
        private static int fps = 120;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private MainCharacter Player;
        private Task animation;
        private Texture2D fondo;
        private Texture2D pixel;
        private Camera camera;


        public static int FPS
        {
            get { return fps; }
        }
        #endregion

        #region metodos
        public Game1()                                  //constructor
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;


        }//Game1();
        protected override void Initialize() //inicializacion de objetos propiedades.
        {

            InitializingGame();
            Object.CreateObjects(Object.Objetos,Content);






        }//Initialize();
        private void InitializingGame()
        {
            Player = new MainCharacter(Content, "PersonajeCaminaVertical", GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - 50, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2, new Vector2(100, 100), 2); //Creando Objeto MainCharacter.
            camera = new Camera(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            animation = Task.Run(Player.Animation);
            string file = Map.FileTo1DArray("map.txt");
            Map.StringTo2DArray(file);
            Map.MapEntities(Content);
            //Map.EntitysTexture2DLoad();
            base.Initialize(); //utilizando Initialize de Game.
        }
        protected override void LoadContent()//Cargando el contenido.
        {

            Menu.Load(Content, "PlayButton"); //cargando la imagen del menu
            _spriteBatch = new SpriteBatch(GraphicsDevice); //cargando el spritebatch
            fondo = Content.Load<Texture2D>("h");
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });

        }//LoadContent();
        protected override void Update(GameTime gameTime) //bulce principal.
        {
            KeyBoardDetection.keys(_graphics); //objeto para detectar las teclas pulsadas.
            Menu.Update(); //update del menu.
            CameraFollowPlayer();
            Colides.PlayerColideObjects(Player);
            bool colideObject = Colides.PlayerColideObjects(Player);
            base.Update(gameTime);
        }//Update();
        private void CameraFollowPlayer()
        {
            if (!Menu.active)
            {

                Player.Movement();
                camera.Follow(new Vector2(Player.Posx, Player.Posy));


            }
        }
        protected override void Draw(GameTime gameTime)  //bucle donde dibujar Imagenes.
        {

             GraphicsDevice.Clear(Color.Green); // Fondo
            _spriteBatch.Begin(transformMatrix: camera.Transform); 
            
            DrawEntitiesOrdered();
            RedRectangleArroundPlayer();
            DrawMenu();
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }//Renderer();
        private void DrawEntitiesOrdered()
        {
            if (!Menu.active)
            {

                Map.DrawBackground(Player, _spriteBatch);

                Map.DrawArenaSprites(Player, _spriteBatch, (int)Map.Size.X, (int)Map.Size.X);

                Map.DrawWaterSprites(Player, _spriteBatch, (int)Map.Size.X, (int)Map.Size.Y);

                Map.DrawHouseSprites(Player, _spriteBatch, (int)Map.Size.X, (int)Map.Size.Y);

                foreach (Object o in Object.Objetos)
                {
                    o.Draw(_spriteBatch);
                }

                if (Colides.PlayerEnteringBush(Player))
                {
                    Player.Draw(_spriteBatch);
                    Map.DrawBushSprites(Player, _spriteBatch, (int)Map.Size.X, (int)Map.Size.Y);
                }
                else
                {
                    Map.DrawBushSprites(Player, _spriteBatch, (int)Map.Size.X, (int)Map.Size.Y);
                    Player.Draw(_spriteBatch);
                }



            }
        }
        private void RedRectangleArroundPlayer()
        {
            //rectangulo rojo alrededor de player START.
            Rectangle rect = new Rectangle
                (
                    (int)Player.Posx,
                   (int)Player.Posy,
                   (int)Player.SIZE.X,
                   (int)Player.SIZE.Y

                );
            int grosor = 3;
            { // Línea superior
                _spriteBatch.Draw(pixel, new Rectangle(rect.X, rect.Y, rect.Width, grosor), Color.Red);

                // Línea inferior
                _spriteBatch.Draw(pixel, new Rectangle(rect.X, rect.Y + rect.Height, rect.Width, grosor), Color.Red);

                // Línea izquierda
                _spriteBatch.Draw(pixel, new Rectangle(rect.X, rect.Y, grosor, rect.Height), Color.Red);

                // Línea derecha
                _spriteBatch.Draw(pixel, new Rectangle(rect.X + rect.Width, rect.Y, grosor, rect.Height), Color.Red);
            }
            //rectangulo rojo alrededor de player END.
            //rectangulo rojo alrededor de player START.

            //rectangulo rojo alrededor de player END.
        }
        private void DrawMenu()//dibujar menu
        {
            if (Menu.active) { Menu.Draw(_spriteBatch); } //dibujando el meno.
        }
        #endregion
    }
}
