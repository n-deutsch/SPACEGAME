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
    class HudManager
    {
        private List<HudText> texts;
        private List<HudGraphic> graphics;

        public HudManager(TextureManager TM)
        {
            texts = new List<HudText>();
            graphics = new List<HudGraphic>();
            startup(TM);
        }

        //private function designed to create default HUDelements
        private void startup(TextureManager TM)
        {
            //GRAPHICS
            //create show/hide button
            HudGraphic showHide = new HudGraphic(new Vector2(1240, 0), VISIBILITY.SHOWING, TM.UI[0]);
            //create bottom bar
            HudGraphic bottomBar = new HudGraphic(new Vector2(0,700), VISIBILITY.SHOWING, TM.UI[2]);
            //create top bar
            HudGraphic topBar = new HudGraphic(new Vector2(0, 0), VISIBILITY.SHOWING, TM.UI[2]);

            graphics.Add(showHide);
            graphics.Add(bottomBar);
            graphics.Add(topBar);


            //TEXT
            //current date
            HudText day = new HudText(new Vector2(150,702), VISIBILITY.SHOWING, TM.fonts[0], "date");
            //camera position
            HudText camera = new HudText(new Vector2(0,702), VISIBILITY.SHOWING, TM.fonts[0], "camx, camy");

            texts.Add(day);
            texts.Add(camera);

            hide();
        }

        public List<HudText> getText()
        { return texts; }

        public List<HudGraphic> getGraphics()
        { return graphics; }

        public void show()
        {
            int i = 0;
            //show all graphics
            //loop starts at index 1 since show/hide butten is never hidden
            for (i = 1; i < graphics.Count; i++)
            {
                if (graphics[i].getState() != VISIBILITY.SHOWN)
                { graphics[i].show(); }
            }

            //show all text
            for (i = 0; i < texts.Count; i++)
            {
                if (graphics[i].getState() != VISIBILITY.SHOWN)
                { graphics[i].show(); }
            }
        }


        public void hide()
        {
            int i = 0;
            //hide all graphics
            //loop starts at index 1 since show/hide butten is never hidden
            for (i = 1; i < graphics.Count; i++)
            {
                if (graphics[i].getState() != VISIBILITY.HIDDEN)
                { graphics[i].hide(); }
            }

            //hide all text
            for (i = 0; i < texts.Count; i++)
            {
                if (graphics[i].getState() != VISIBILITY.HIDDEN)
                { graphics[i].hide(); }
            }
        }

        public int hudTextCount()
        { return texts.Count; }

        public int hudGraphicsCount()
        { return graphics.Count; }

        public HudGraphic getGraphicAt(int index)
        {
            return graphics[index];
        }

        public HudText getTextAt(int index)
        {
            return texts[index];
        }
        
    }
}
