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
    class ActionManager
    {
        //default constructor
        public ActionManager()
        { }

        //interpret mouse click
        public Action interpretClick(Globals G, HudManager HM)
        {
            Action A = null;
            Point P = new Point(G.mouseX, G.mouseY);
            Point size = new Point(1, 1);
            Rectangle mousePos = new Rectangle(P,size);
            int i = 0;

            //first and foremost, did we click on a hud element???
            for (i = 0; i < HM.hudGraphicsCount(); i++)
            {
                if (HM.getGraphicAt(i).getClickBox().Intersects(mousePos))
                {
                    A = HM.getGraphicAt(i).getAction();
                    int butts = 69;
                }
            }
            


            return A;
        }
    }
}
