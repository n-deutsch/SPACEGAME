using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACEGAME
{
    class Globals
    {
        public int tileSize;
        public int graphicsWidth;
        public int graphicsHeight;
        public int timeStamp;
        public int movementCooldown;
        public int mouseX;
        public int mouseY;
        public String mouseText;
        public String mouseSubText;

        public Globals()
        {
            //default to ONE so we avoid divide by zero exceptions
            tileSize = 1;
            graphicsHeight = 1;
            graphicsWidth = 1;
            timeStamp = 1;
            movementCooldown = 1;
            mouseX = 0;
            mouseY = 0;
            mouseText = "";
            mouseSubText = "";
        }
    }
}
