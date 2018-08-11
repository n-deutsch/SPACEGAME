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
        protected Vector2 size;
        protected Rectangle clickBox;
        protected VISIBILITY state;
        protected ORIENTATION orientation;
        protected Action action;

        public HudElement()
        {
            position = new Vector2(0, 0);
            origin = position;
            size = position;
            state = VISIBILITY.SHOWN;
            orientation = ORIENTATION.TOP;
            action = null;
        }

        public VISIBILITY getState()
        { return state; }

        public void setState(VISIBILITY newState)
        { state = newState; }

        public Vector2 getPosition()
        { return position; }

        public void setPosition(Vector2 newPos)
        { position = newPos; }

        public void setClickBox(Rectangle cb)
        {clickBox = cb;}

        public Rectangle getClickBox()
        {return clickBox;}

        public void setAction(Action a)
        { action = a; }

        public Action getAction()
        { return action; }

        public void updateClickBox()
        {
            Point Pos = new Point((int)position.X, (int)position.Y);
            Point Size = new Point((int)size.X, (int)size.Y);
            clickBox = new Rectangle(Pos, Size);
        }

        //move on screen
        public void show()
        {
            state = VISIBILITY.SHOWING;

                if (orientation == ORIENTATION.TOP)
                {
                    if (position.Y == origin.Y)
                    { state = VISIBILITY.SHOWN; return; }
                    //move 1 pixel down
                    position.Y += 1;
                }
                else if (orientation == ORIENTATION.RIGHT)
                {
                    if (position.X == origin.X)
                    { state = VISIBILITY.SHOWN; return; }
                    //move 1 pixel left
                    position.X -= 1;
                }
                else if (orientation == ORIENTATION.BOTTOM)
                {
                    if (position.Y == origin.Y)
                    { state = VISIBILITY.SHOWN; return; }
                    //move 1 pixel up
                    position.Y -= 1;
                }
                else if (orientation == ORIENTATION.LEFT)
                {
                    if (position.X == origin.X)
                    { state = VISIBILITY.SHOWN; return; }
                    //move 1 pixel right
                    position.X += 1;
                }

            updateClickBox();
        }

        //move off screen
        public void hide()
        {
            //this is a bit more tricky since objects have a different size....

            state = VISIBILITY.HIDING;

                if (orientation == ORIENTATION.TOP)
                {
                    if (position.Y == (origin.Y - size.Y))
                    {
                        state = VISIBILITY.HIDDEN;
                        return;
                    }
                    //move 1 pixel up
                    position.Y -= 1;
                }
                else if (orientation == ORIENTATION.RIGHT)
                {
                    if (position.X == (origin.X + size.X))
                    {
                        state = VISIBILITY.HIDDEN;
                        return;
                    }
                    //move 1 pixel right
                    position.X += 1;
                }
                else if (orientation == ORIENTATION.BOTTOM)
                {
                    if (position.Y == (origin.Y + size.Y))
                    {
                        state = VISIBILITY.HIDDEN;
                        return;
                    }
                    //move 1 pixel down
                    position.Y += 1;
                }
                else if (orientation == ORIENTATION.LEFT)
                {
                    if (position.X == (origin.X - size.X))
                    {
                        state = VISIBILITY.HIDDEN;
                        return;
                    }
                    //move 1 pixel left
                    position.X -= 1;
                }

            updateClickBox();
        return;
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

        public HudGraphic(Vector2 pos, Vector2 siz, VISIBILITY vis, ORIENTATION ort, Texture2D tex, Action a)
        {
            position = pos;
            origin = pos;
            size = siz;
            state = vis;
            orientation = ort;
            texture = tex;
            action = a;

            //set up clickbox
            Point Pos = new Point((int)pos.X, (int)pos.Y);
            Point Size = new Point((int) size.X, (int) size.Y);
            clickBox = new Rectangle(Pos, Size);
        }

        public Texture2D getTexture()
        { return texture; }

        public void setTexture(Texture2D newTex)
        { texture = newTex; }
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

        public HudText(Vector2 pos, Vector2 siz, VISIBILITY vis, ORIENTATION ort, SpriteFont fnt, string txt, Action a)
        {
            position = pos;
            origin = pos;
            size = siz;
            state = vis;
            orientation = ort;
            font = fnt;
            text = txt;
            action = a;
        }

        public void setText(string newText)
        {
            text = newText;
        }

        public string getText()
        {
            return text;
        }

        public void setFont(SpriteFont fnt)
        { font = fnt; }

        public SpriteFont getFont()
        { return font; }
    }
}
