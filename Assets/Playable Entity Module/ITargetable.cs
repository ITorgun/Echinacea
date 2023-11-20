using UnityEngine;

namespace Assets.Playable_Entity_Module
{
    public interface ITargetable
    {
        Transform TargetTransform { get; set; }
        bool IsTargetSet { get; set; }
    }
}
