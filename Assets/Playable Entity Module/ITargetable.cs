using UnityEngine;

namespace Assets.PlayableEntityModule
{
    public interface ITargetable
    {
        Transform TargetTransform { get; set; }
        bool IsTargetSet { get; set; }
    }
}
