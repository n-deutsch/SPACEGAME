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
    //class all buildings derive from
    class Structure
    {
        protected Vector2 position;
        protected Vector2 size;
        protected Texture2D texture;

        public Structure()
        { }

        public void setPosition(Vector2 p)
        { position = p; }

        public Vector2 getPosition()
        { return position; }

        public void setSize(Vector2 s)
        { size = s; }

        public Vector2 getSize()
        { return size; }

        public void setTexture(Texture2D t)
        { texture = t; }

        public Texture2D getTexture()
        { return texture; }
    }

    class Tent : Structure
    {
        public Tent(Vector2 p, Vector2 s, Texture2D t)
        {
            position = p;
            size = s;
            texture = t;
        }
    }
}
