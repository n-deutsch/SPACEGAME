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
    class Organism
    {
        protected Vector2 position;
        protected int health;
        protected float speed;

        public Organism()
        { }

        public Organism(Vector2 pos, int hp, float sp)
        {
            position = pos;
            health = hp;
            speed = sp;
        }

        public void setPosition(Vector2 p)
        { position = p; }

        public Vector2 getPosition()
        { return position; }

        public void setHealth(int hp)
        { health = hp; }

        public int getHealth()
        { return health; }

        public void setSpeed(float sp)
        { speed = sp; }

        public float getSpeed()
        { return speed; }
    }
}
