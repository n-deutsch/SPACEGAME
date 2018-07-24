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
        public List<Texture2D> tileTextures = new List<Texture2D>();
        public List<SpriteFont> fonts = new List<SpriteFont>();
        public List<Texture2D> UI = new List<Texture2D>();

        public TextureManager()
        {
            tileTextures.Clear();
            fonts.Clear();
            UI.Clear();
        }
    }
}
