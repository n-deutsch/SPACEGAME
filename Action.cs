using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACEGAME
{
    class Action
    {
        protected int index;
        protected string bias;

        public Action()
        {
            index = 0;
            bias = "none";
        }

        public void setIndex(int i)
        { index = i; }

        public int getIndex()
        { return index; }

        public void setBias(string b)
        { bias = b; }

        public string getBias()
        { return bias; }

        public virtual void doAction(TextureManager TM, HudManager HM)
        {
            return;
        }
    }

    class doNothing : Action
    {
        public doNothing()
        { }

        public override void doAction(TextureManager TM, HudManager HM)
        {
            return;
        }
    }

    class showHide : Action
    {
        public showHide()
        { }

        public override void doAction(TextureManager TM, HudManager HM)
        {
            if (HM.getGraphicAt(0).getTexture() == TM.UI[0])
            {
                HM.getGraphicAt(0).setTexture(TM.UI[1]);
                HM.setShowing(true);
            }
            else
            {
                HM.getGraphicAt(0).setTexture(TM.UI[0]);
                HM.setShowing(false);
            }
        }
    }

    class createSubMenu : Action
    { 
        public createSubMenu(string b)
        {
            bias = b;
        }

        public override void doAction(TextureManager TM, HudManager HM)
        {
            HM.createSubMenu(TM, bias);

            Action A = new removeSubMenu(index, bias);
            HM.getGraphicAt(index).setAction(A);
            return;
        }
    }

    class removeSubMenu : Action
    {
        public removeSubMenu(int i, string b)
        {
            index = i;
            bias = b;
        }

        public override void doAction(TextureManager TM, HudManager HM)
        {
            //remove old submenu
            int i = 0;
            int count = HM.hudGraphicsCount();

            //can't do this in a for loop since we remove elements from the list...
            while (i < count)
            {
                if (HM.getGraphicAt(i).getOrientation() == ORIENTATION.NONE)
                {
                    HM.getGraphics().RemoveAt(i);
                    count--;
                }
                else
                {
                    i++;
                }
            }

            //now we swap the clicked HudGraphic's action to "createSubMenu"
            Action A = new createSubMenu(bias);
            A.setIndex(index);
            HM.getGraphicAt(index).setAction(A);
        }
    }

    class construct : Action
    {
        private string type;

        public construct(string t)
        { type = t; }

        public override void doAction(TextureManager TM, HudManager HM)
        {
            return;
        }
    }

    
}
