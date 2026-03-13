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
        //lista de objetos que habra por el mapa.
        private static List<Object> objetos = new List<Object>();

        // geter de objetos solo lectura.
        public static List<Object> Objetos 
        {
            get { return objetos; }
        }//Objectos.

        //inicializa el tipo del Objeto.
        public Object(ContentManager content, string imageName, int posX, int posY, Vector2 size, int dividendo , Type tipo) : base(content, imageName, posX, posY, size, dividendo)// constructor con tipo
        {
            this.type = tipo;
        }//Object.

        //crea 3 objetos por el mapa de tipo roca.
        public static void CreateObjects(List<Object>objetos, ContentManager Content)
        {
            for (int i = 0; i < 1; i++)
            {
                objetos.Add(new Object(Content, "r", i * 100, 100, new Vector2(100, 100), 1, Type.Rock));
            }
        }//CreateObjects.

        //borra el objeto del mapa.
        public static void DeleteObject(List<Object> objetos, ContentManager Content, int index)
        {
            objetos.RemoveAt(index);
        }

    }
}
