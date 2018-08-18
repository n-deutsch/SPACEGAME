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
        private bool showing;
        private string subMenuBias;

        public HudManager(TextureManager TM)
        {
            texts = new List<HudText>();
            graphics = new List<HudGraphic>();
            showing = true;
            subMenuBias = "";
            startup(TM);
        }

        //private function designed to create default HUDelements
        private void startup(TextureManager TM)
        {
            //GRAPHICS

            //create show/hide button
            HudGraphic showHide = new HudGraphic("showHide", new Vector2(1200, 0), new Vector2(80, 20), VISIBILITY.SHOWN, ORIENTATION.TOP, TM.UI[1], new showHide());

            //create top bar
            //HudGraphic topBar = new HudGraphic(new Vector2(0, 0), new Vector2(1280,20), VISIBILITY.SHOWN, ORIENTATION.TOP, TM.UI[2]);

            //housing submenu icon
            HudGraphic shelter = new HudGraphic("shelter", new Vector2(0, 0), new Vector2(40, 20), VISIBILITY.SHOWN, ORIENTATION.TOP, TM.UI[3], new createSubMenu("shelter"));



            //create bottom bar
            HudGraphic bottomBar = new HudGraphic("bottomBar", new Vector2(0, 700), new Vector2(1280, 20), VISIBILITY.SHOWN, ORIENTATION.BOTTOM, TM.UI[2], new doNothing());

            graphics.Add(showHide);
            graphics.Add(bottomBar);
            //graphics.Add(topBar);
            graphics.Add(shelter);


            //TEXT
            //current date
            HudText day = new HudText(new Vector2(150,702), new Vector2(100,20), VISIBILITY.SHOWN, ORIENTATION.BOTTOM, TM.fonts[0], "date", new doNothing());
            //camera position
            HudText camera = new HudText(new Vector2(0,702), new Vector2(100,20), VISIBILITY.SHOWN, ORIENTATION.BOTTOM, TM.fonts[0], "camx, camy", new doNothing());

            texts.Add(day);
            texts.Add(camera);
        }

        public void setShowing(bool sho)
        { showing = sho; }

        public bool getShowing()
        { return showing; }

        public List<HudText> getText()
        { return texts; }

        public List<HudGraphic> getGraphics()
        { return graphics; }

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
                if (texts[i].getState() != VISIBILITY.SHOWN)
                { texts[i].show(); }
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
                if (texts[i].getState() != VISIBILITY.HIDDEN)
                { texts[i].hide(); }
            }
        }

        public void update()
        {
            if (showing == true)
            { show(); }
            else
            { hide(); }
        }

        public void changeText(int camx, int camy, int day)
        {
            string position = "(" + camx + "," + camy + ")";
            texts[0].setText(position);

            string date = "Day " + day;
            texts[1].setText(date);
        }

        public void createSubMenu(TextureManager TM, string bias)
        {
            SubMenu SMM = null;

            if (bias.Equals("shelter"))
            {
                SMM = new Shelter(TM);
                graphics = SMM.createSubMenu(bias, graphics);
            }

            subMenuBias = bias;
            return;
        }
        
    }
}
