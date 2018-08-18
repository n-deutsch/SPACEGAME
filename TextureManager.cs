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
    class TextureManager
    {
        public List<Texture2D> tileTextures;
        public List<SpriteFont> fonts;
        public List<Texture2D> UI;
        public List<Texture2D> submenu;
        public List<Texture2D> shelters;
        public Texture2D crosshair;

        public TextureManager()
        {
            tileTextures = new List<Texture2D>();
            fonts = new List<SpriteFont>();
            UI = new List<Texture2D>();
            submenu = new List<Texture2D>();
            shelters = new List<Texture2D>();

            crosshair = null;
        }
    }
}
