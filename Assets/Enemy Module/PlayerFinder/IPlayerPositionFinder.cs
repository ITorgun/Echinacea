using Assets.Enemy_Module.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Enemy_Module.PlayerFinder
{
    public interface IPlayerPositionFinder : IFinder
    {
        public Vector2 LastPlayerPosition { get; }
    }
}
