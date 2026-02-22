using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    internal static class Colides
    {
        public static bool PlayerEnteringBush(MainCharacter Player)
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
        }
    }
}
