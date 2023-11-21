using UnityEngine;
using Zenject;

public class PlayerAttack : MonoBehaviour
{
    public ShotPosition ShotPosition { get; set; }
    public IRangeAttackDealer RangeAttackDealer { get; set; }

    [Inject]
    public void Construct(ShotPosition shotPosition, IRangeAttackDealer rangeAttackDealer)
    {
        ShotPosition = shotPosition;
        RangeAttackDealer = rangeAttackDealer;
    }

}
