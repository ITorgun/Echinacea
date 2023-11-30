using Assets.Enemy_Module.Interfaces;
using Assets.Playable_Entity_Module;
using Assets.Playable_Entity_Module.Mover;
using UnityEngine;
using Zenject;

public class RobotBombMovement : MonoBehaviour, IMovement
{
    public IMover Mover { get; private set; }

    [Inject]
    public void Constructor(IMover mover)
    {
        Mover = mover;
    }

    private void Start()
    {
        Mover.StartMove();
    }

    private void Update()
    {
        Mover.Moving(transform);
    }
}
