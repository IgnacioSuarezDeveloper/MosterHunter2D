using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    internal static class Colides 
    {
        #region methods
            public static bool PlayerEnteringBush(MainCharacter Player) //jugador entrando en el arbusto.
        {
            bool inside = false;
            foreach(Vector2 bushIndex in Map.BUSHES)
            {
                if ((Player.Posy + Player.SIZE.Y ) < (Map.ENtitysTexture2D[(int)bushIndex.Y,(int)bushIndex.X].Posy + Map.OfsetYstart + Map.ENtitysTexture2D[(int)bushIndex.Y, (int)bushIndex.X].SIZE.Y) &&
                    (Player.Posy + Player.SIZE.Y) > (Map.ENtitysTexture2D[(int)bushIndex.Y, (int)bushIndex.X].Posy + Map.OfsetYstart ) &&
                    Player.Posx + (Player.SIZE.X / 3 )> (Map.ENtitysTexture2D[(int)bushIndex.Y, (int)bushIndex.X].Posx + Map.OfsetXstart) &&
                    (Player.Posx + Player.SIZE.X / 1.5) < (Map.ENtitysTexture2D[(int)bushIndex.Y, (int)bushIndex.X].Posx + Map.OfsetXstart + Map.ENtitysTexture2D[(int)bushIndex.Y, (int)bushIndex.X].SIZE.X)
                    )
                {
                    inside = true;
                }
                else
                {
                    return false;
                }
            }
            return inside;
        }//PlayerEnteringBush();
            public static bool PlayerColidHouses(MainCharacter Player) //comprueba la distancia de colision con las casas y la devuelve.
        {
            string colidingDistance = "";
           
            foreach ( Vector2 housesIndex in Map.HOUSES ) //comprobando la distancia con las casas.
            {
                
               
                int housex = (int)Map.ENtitysTexture2D[(int)housesIndex.Y, (int)housesIndex.X].Posx + Map.OfsetXstart;
                int housey = (int)Map.ENtitysTexture2D[(int)housesIndex.Y, (int)housesIndex.X].Posy + Map.OfsetYstart;

                int housexSize = (int)Map.ENtitysTexture2D[(int)housesIndex.Y, (int)housesIndex.X].SIZE.X;
                int houseySize = (int)Map.ENtitysTexture2D[(int)housesIndex.Y, (int)housesIndex.X].SIZE.Y;

                housex += housexSize / 2;
                housey += houseySize / 2;   


                int playerx = (int)Player.Posx;
                int playery = (int)Player.Posy;

                int playerWidth = (int)Player.SIZE.X;
                int playerHeight = (int)Player.SIZE.Y;

                //int auxfpx =  futurePlayerPosx + playerWidth / 2;
                //int auxfpy = futurePlayerPosy + playerHeight / 2;  

                playerx += playerWidth / 2;
                playery += playerHeight / 2;
                
                int deltaX = Math.Abs(playerx - housex);
                int deltaY = Math.Abs(playery - housey);

                //int futureDeltaY = Math.Abs(auxfpy - housey);
                //int futureDeltaX = Math.Abs(auxfpx - housex);

                int distance = (int)Math.Sqrt(deltaY * deltaY + deltaX * deltaX);
                //int futureDistance = (int)Math.Sqrt(futureDeltaX * futureDeltaX + futureDeltaY * futureDeltaY);
                int minimunDistance = housexSize / 2 - 90;
                if (distance <= minimunDistance )
                {
                    Debug.WriteLine(distance);
                    return true;
                    break;
                }

                
            }
                 return false; 
        }//PlayerColidingHouses();
            public static bool PlayerFutureColidHouses(MainCharacter Player, int futurePosx, int futurePosy)//comprueba la distancia futura de colision
         {
            foreach (Vector2 housesIndex in Map.HOUSES) //comprobando la distancia con las casas.
            {


                int housex = (int)Map.ENtitysTexture2D[(int)housesIndex.Y, (int)housesIndex.X].Posx + Map.OfsetXstart ;
                int housey = (int)Map.ENtitysTexture2D[(int)housesIndex.Y, (int)housesIndex.X].Posy + Map.OfsetYstart ;

                int housexSize = (int)Map.ENtitysTexture2D[(int)housesIndex.Y, (int)housesIndex.X].SIZE.X;
                int houseySize = (int)Map.ENtitysTexture2D[(int)housesIndex.Y, (int)housesIndex.X].SIZE.Y;

                housex += housexSize / 2;
                housey += houseySize / 2;


                

                int playerWidth = (int)Player.SIZE.X;
                int playerHeight = (int)Player.SIZE.Y;

                //int auxfpx =  futurePlayerPosx + playerWidth / 2;
                //int auxfpy = futurePlayerPosy + playerHeight / 2;  

                futurePosx += playerWidth / 2;
                futurePosy += playerHeight / 2;

                int deltaX = Math.Abs(futurePosx - housex);
                int deltaY = Math.Abs(futurePosy - housey);
                
                int distance = (int)Math.Sqrt(deltaY * deltaY + deltaX * deltaX);
                int minimunDistance = housexSize / 2 - 90;
                if (distance <= minimunDistance)
                {
                    return true;
                    break;
                }
            }
            return false;
        }//PlayerFutureColidHouses();

        #endregion methods
    }
}
