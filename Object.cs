using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    internal class Object : Entity
    {
        private static List<Object> objetos = new List<Object>();
        public static List<Object> Objetos
        {
            get { return objetos; }
        }
        public Object(ContentManager content, string imageName, int posX, int posY, Vector2 size, int dividendo , Type tipo) : base(content, imageName, posX, posY, size, dividendo)
        {
            this.type = tipo;
        }


        public static void CreateObjects(List<Object>objetos, ContentManager Content)
        {
            for (int i = 0; i < 1; i++)
            {
                objetos.Add(new Object(Content, "r", i * 100, 100, new Vector2(100, 100), 1, Type.Rock));
            }
        }

    }
}
