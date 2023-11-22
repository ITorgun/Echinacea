using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Player_Module.Scripts.Health
{
    public interface IPlayerHealthTaker : IHealthTaker
    {
        public event Action<float> HealthChanged;
    }
}
