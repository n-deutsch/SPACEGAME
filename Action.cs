using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACEGAME
{
    class Action
    {
        public Action()
        { }

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

    
}
