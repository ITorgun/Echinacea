using UnityEngine;
using Zenject;

public class PlayerAttack : MonoBehaviour
{
    public ShotPosition ShotPosition { get; set; }
    public AmmoSwitcher AmmoSwitcher { get; set; }
    public IRangeAttackDealer RangeAttackDealer { get; set; }

    [Inject]
    public void Construct(ShotPosition shotPosition, AmmoSwitcher ammoSwitcher, IRangeAttackDealer rangeAttackDealer)
    {
        ShotPosition = shotPosition;
        AmmoSwitcher = ammoSwitcher;
        RangeAttackDealer = rangeAttackDealer;
    }

}
