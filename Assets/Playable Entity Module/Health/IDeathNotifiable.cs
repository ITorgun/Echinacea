using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Playable_Entity_Module.Health
{
    public interface IDeathNotifiable<T>
    {
        public event Action<T> Died;
    }
}
