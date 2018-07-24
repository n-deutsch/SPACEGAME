using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SPACEGAME
{
    class map
    {
        private int camX;
        private int camY;
        private int worldSize;

        tile[,] worldMap;

        public map(String bias, List<Texture2D> textures)
        {
            worldSize = 1000;

            //camera oriented at center of map
            camX = (worldSize / 2);
            camY = (worldSize / 2);

            worldMap = new tile[worldSize, worldSize];

            for (int i = 0; i < worldSize; i++)
            {
                for (int j = 0; j < worldSize; j++)
                {
                    worldMap[j, i] = null;
                }
            }

            generateWorld("default", textures);
        }

        public void setCamX(int newCamX)
        {
            camX = newCamX;
        }

        public int getCamX()
        {
            return camX;
        }

        public void setCamY(int newCamY)
        {
            camY = newCamY;
        }

        public int getCamY()
        {
            return camY;
        }

        public void setWorldMap(tile[,] newMap)
        {
            worldMap = newMap;
        }

        public tile[,] getWorldMap()
        {
            return worldMap;
        }

        public tile getTileAt(int x, int y)
        {
            if (x < 0 || x >= worldSize)
            { return null; }
            if (y < 0 || y >= worldSize)
            { return null; }

            return worldMap[x, y];
        }

        //fills all 10,000 tiles with random floor textures
        public void generateWorld(string bias, List<Texture2D> textures)
        {
            int i = 0;
            int j = 0;
            List<Biome> Biomes = generateBiomes(bias, textures);
            Random R = new Random(Guid.NewGuid().GetHashCode());
            Biome B = null;

            //check for null space
            for (i = 0; i < worldSize; i++)
            {
                for (j = 0; j < worldSize; j++)
                {
                    if (worldMap[i, j] == null)
                    {
                        B = closestBiome(Biomes, i, j);
                        tile t = new tile(false,false,false,B.getTexture(),B.getType(),"flavor text");
                        worldMap[i, j] = t;
                    }
                }
            }

            return;
        } //end of generateWorld()

        public List<Biome> generateBiomes(string bias, List<Texture2D> textures)
        {
            Biome B = null;
            List<Biome> L = new List<Biome>();
            Random R = new Random(Guid.NewGuid().GetHashCode());

            int i = 0;
            int j = 0;
            int minimumDistance = 50;

            int lushCount = 0;
            int desertCount = 0;
            int jungleCount = 0;
            int mountainCount = 0;
            int snowCount = 0;
            int twilightCount = 0;
            int hellCount = 0;

            int lushSpawn = 0;
            int desertSpawn = 0;
            int jungleSpawn = 0;
            int mountainSpawn = 0;
            int snowSpawn = 0;
            int twilightSpawn = 0;
            int hellSpawn = 0;

            bool reroll = false;

            int originX = 0;
            int originY = 0;
            int width = 1;
            int height = 1;

            int biomeCount = 14;
            //default: no bias
            lushCount = 2;
            desertCount = 2;
            jungleCount = 2;
            mountainCount = 2;
            snowCount = 2;
            twilightCount = 2;
            hellCount = 2;

            for(i = 0; i < biomeCount; i++)
            {
                //generate a new spawnPoint until they are spaced far enough apart
                do
                {
                    reroll = false;

                    //special case for the first biome
                    if (i == 0)
                    {
                        originX = worldSize / 2;
                        originY = worldSize / 2;
                        break;
                    }

                    //biome index 1-n, randomly generate
                    originX = R.Next() % worldSize;
                    originY = R.Next() % worldSize;

                    for (j = 0; j < L.Count; j++)
                    {
                        //check if we're too close to another biome
                        if (originX >= (L[j].getOriginX() - minimumDistance) && originX <= (L[j].getOriginX() + minimumDistance))
                        {
                            reroll = true;
                        }

                       //check if we're too close to another biome
                        if (originY >= (L[j].getOriginY() - minimumDistance) && originY <= (L[j].getOriginY() + minimumDistance))
                        {
                            reroll = true;
                        }
                   }
                } while (reroll == true);

                if (lushSpawn < lushCount)
                {
                    B = new Biome("Lush",originX,originY,width,height, textures[0]); lushSpawn++;
                }
                else if (jungleSpawn < jungleCount)
                {
                    B = new Biome("Jungle", originX, originY, width, height, textures[1]); jungleSpawn++;
                }
                else if (desertSpawn < desertCount)
                {
                    B = new Biome("Desert", originX, originY, width, height, textures[2]); desertSpawn++;
                }
                else if (snowSpawn < snowCount)
                {
                    B = new Biome("Snow", originX, originY, width, height, textures[3]); snowSpawn++;
                }
                else if (mountainSpawn < mountainCount)
                {
                    B = new Biome("Mountain", originX, originY, width, height, textures[4]); mountainSpawn++;
                }
                else if (twilightSpawn < twilightCount)
                {
                    B = new Biome("Twilight", originX, originY, width, height, textures[5]); twilightSpawn++;
                }
                else if(hellSpawn < hellCount)
                {
                    B = new Biome("Hellscape", originX, originY, width, height, textures[6]); hellSpawn++;
                }

                //finally: add biome
                L.Add(B);
            }

            return L;  
        }

        public Biome closestBiome(List<Biome> L, int x, int y)
        {
            Biome close = L[0];
            int i = 0;
            int originX = 0;
            int originY = 0;

            int xdistance = 0;
            int ydistance = 0;

            double hypotenuse = 0;
            double distance = -1;

            for (i = 0; i < L.Count; i++)
            {
                originX = L[i].getOriginX();
                originY = L[i].getOriginY();

                //calculate distance between biome's start and (x,y)
                xdistance = x - originX;
                ydistance = y - originY;

                //right-triangle geometry
                ydistance = ydistance * ydistance;
                xdistance = xdistance * xdistance;
                hypotenuse = xdistance + ydistance;

                hypotenuse = Math.Sqrt(hypotenuse);

                //want the smallest possible hypotenuse
                if (distance < 0 || distance > hypotenuse)
                {
                    //NEW closest distance
                    close = L[i];
                    distance = hypotenuse;
                }
            }

            return close;
        }


        public void adjustCamera(int x, int y, Globals G)
        {
            int newX = camX + x;
            int newY = camY + y;

            if (newX < 0 || newX > (worldSize - (G.graphicsWidth / G.tileSize)))
            { return; }

            if (newY < 0 || newY > (worldSize - (G.graphicsHeight / G.tileSize)))
            { return; }

            camX = newX;
            camY = newY;
        }
    }
}
