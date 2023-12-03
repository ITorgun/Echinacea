using UnityEngine;
using Zenject;

public class PlayerAttack : MonoBehaviour
{
    public ShootPosition ShotPosition { get; set; }
    public IRangeAttackDealer RangeAttackDealer { get; set; }

    [Inject]
    public void Construct(ShootPosition shotPosition, IRangeAttackDealer rangeAttackDealer)
    {
        ShotPosition = shotPosition;
        RangeAttackDealer = rangeAttackDealer;
    }

}
