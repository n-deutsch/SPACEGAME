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
    class HudElement
    {
        protected Vector2 origin;
        protected Vector2 position;
        protected VISIBILITY state;

        public HudElement()
        {
            position = new Vector2(0, 0);
            origin = position;
            state = VISIBILITY.SHOWING;
        }

        public VISIBILITY getState()
        { return state; }

        public void setState(VISIBILITY newState)
        { state = newState; }

        public Vector2 getPosition()
        { return position; }

        public void setPosition(Vector2 newPos)
        { position = newPos; }

        //decreases Y by 20 pixels
        public void hideTop()
        {
            if (position.Y > (origin.Y - 20))
            { position.Y = position.Y - 1; }
        }

        //increases Y by 20 pixels
        public void showTop()
        {
            if (position.Y < origin.Y)
            {position.Y = position.Y + 1;}
        }

        //decreases Y by 20 pixels
        public void hideBottom()
        {
            if (position.Y > origin.Y)
            { position.Y = position.Y - 1; }
        }

        //increases Y by 20 pixels
        public void showBottom()
        {
            if (position.Y < (origin.Y + 20))
            { position.Y = position.Y + 1; }
        }

        
    }

    class HudGraphic: HudElement
    {
        protected Texture2D texture;

        public HudGraphic()
        {
            position = new Vector2(0, 0);
            state = VISIBILITY.HIDDEN;
            texture = null;
        }

        public HudGraphic(Vector2 pos, VISIBILITY vis, Texture2D tex)
        {
            position = pos;
            origin = pos;
            state = vis;
            texture = tex;
        }

        public Texture2D getTexture()
        { return texture; }
    }

    class HudText : HudElement
    {
        protected SpriteFont font;
        protected string text;

        public HudText()
        {
            position = new Vector2(0, 0);
            state = VISIBILITY.HIDDEN;
            font = null;
        }

        public HudText(Vector2 pos, VISIBILITY vis, SpriteFont fnt, string txt)
        {
            position = pos;
            origin = pos;
            state = vis;
            font = fnt;
            text = txt;
        }

        public void setText(string newText)
        {
            text = newText;
        }

        public string getText()
        {
            return text;
        }

    }
}
