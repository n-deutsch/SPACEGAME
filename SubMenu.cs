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
    class SubMenu
    {
        public SubMenu()
        { }

        public virtual List<HudGraphic> createSubMenu(string bias, List<HudGraphic> graphics)
        {
            //do nothin'
            return graphics;
        }
    }

    class Shelter : SubMenu
    {
        List<HudGraphic> shelters;

        public Shelter(TextureManager TM)
        {
            shelters = new List<HudGraphic>();

            //makeshift tent
            HudGraphic tent = new HudGraphic("tent", new Vector2(0, 20), new Vector2(40, 40), VISIBILITY.SHOWN, ORIENTATION.NONE, TM.submenu[0], new construct("tent"));
            //yurt
            HudGraphic yurt = new HudGraphic("yurt", new Vector2(40, 20), new Vector2(40, 40), VISIBILITY.SHOWN, ORIENTATION.NONE, TM.submenu[1], new construct("yurt"));
            //logcabin
            HudGraphic logcabin = new HudGraphic("logcabin", new Vector2(80, 20), new Vector2(40, 40), VISIBILITY.SHOWN, ORIENTATION.NONE, TM.submenu[2], new construct("logcabin"));
            //domicile
            HudGraphic domicile = new HudGraphic("domicile", new Vector2(120, 20), new Vector2(40, 40), VISIBILITY.SHOWN, ORIENTATION.NONE, TM.submenu[3], new construct("domicile"));
            //manor 
            HudGraphic manor = new HudGraphic("manor", new Vector2(160, 20), new Vector2(40, 40), VISIBILITY.SHOWN, ORIENTATION.NONE, TM.submenu[4], new construct("manor"));
            //fortress
            HudGraphic fortress = new HudGraphic("fortress", new Vector2(200, 20), new Vector2(40, 40), VISIBILITY.SHOWN, ORIENTATION.NONE, TM.submenu[5], new construct("fortress"));

            shelters.Add(tent);
            shelters.Add(yurt);
            shelters.Add(logcabin);
            shelters.Add(domicile);
            shelters.Add(manor);
            shelters.Add(fortress);
        }

        public override List<HudGraphic> createSubMenu(string bias, List<HudGraphic> graphics)
        {
            int i = 0;

            //first, remove our OLD submenu
            for (i = 0; i < graphics.Count; i++)
            {
                if (graphics[i].getOrientation() == ORIENTATION.NONE)
                { graphics.RemoveAt(i); }
            }

            for (i = 0; i < shelters.Count; i++)
            {
                graphics.Add(shelters[i]);
            }

            return graphics;
        }
    }
}
