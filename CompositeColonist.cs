using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACEGAME
{
    class CompositeOrganism
    {
        private List<Organism> List;

        public CompositeOrganism()
        {
            List = new List<Organism>();
        }

        public void setList(List<Organism> L)
        { List = L; }

        public List<Organism> getList()
        { return List; }
    }
}
