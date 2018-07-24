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

    class Biome
    {
        protected String type;
        protected int originX;
        protected int originY;
        protected int width;
        protected int height;
        protected Texture2D texture;

        public Biome()
        {
            type = "undecided";
            originX = 0;
            originY = 0;
            width = 1;
            height = 1;
        }

        public Biome(String newType, int orgX, int OrgY, int W, int H, Texture2D tex)
        {
            type = newType;
            originX = orgX;
            originY = OrgY;
            width = W;
            height = H;
            texture = tex;
        }

        public void setType(String newType)
        { type = newType; }

        public String getType()
        { return type; }

        public void setOriginX(int newX)
        { originX = newX; }

        public int getOriginX()
        { return originX; }

        public void setOriginY(int newY)
        { originY = newY; }

        public int getOriginY()
        { return originY; }

        public void setWidth(int newWidth)
        {width = newWidth;}

        public int getWidth()
        { return width; }

        public void setHeight(int newHeight)
        { height = newHeight; }

        public int getHeight()
        { return height; }

        public void setTexture(Texture2D newTexture)
        { texture = newTexture; }

        public Texture2D getTexture()
        { return texture; }
    }
}
