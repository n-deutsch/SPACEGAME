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
    class tile
    {
        protected bool isObstruction;
        protected bool isPath;
        protected bool isFluid;
        protected String name;
        protected String flavorText;
        protected Texture2D texture;

        public tile()
        {
            isObstruction = false;
            isPath = false;
            isFluid = false;
            texture = null;
        }

        public tile(bool obstructed, bool pathway, bool fluid, Texture2D tex, String newName, String flavor)
        {
            isObstruction = obstructed;
            isPath = pathway;
            isFluid = fluid;
            texture = tex;
            name = newName;
            flavorText = flavor;
        }

        public void setObstruction(bool newObstruction)
        {
            isObstruction = newObstruction;
        }

        public bool getObstruction()
        {
            return isObstruction;
        }

        public void setPath(bool argument)
        {
            isPath = argument;
        }

        public bool getPath()
        {
            return isPath;
        }

        public void setTexture(Texture2D newTexture)
        {
            texture = newTexture;
        }

        public Texture2D getTexture()
        {
            return texture;
        }

        public void setName(String newName)
        {
            name = newName;
        }

        public String getName()
        {
            return name;
        }

        public void setFlavorText(String newFlavorText)
        {
            flavorText = newFlavorText;
        }

        public String getFlavorText()
        {
            return flavorText;
        }
    }
}
