using Assets.Enemy_Module.Interfaces;
using Assets.Playable_Entity_Module;
using Assets.Playable_Entity_Module.Mover;
using UnityEngine;
using Zenject;

public class RobotBombMovement : MonoBehaviour, IMovement
{
    public IMover Mover { get; private set; }
    public IPositionable Positionable { get; private set; }
    public IFinder Finder { get; private set; }

    [Inject]
    public void Constructor(IMover mover, IPositionable positionable, IFinder finder)
    {
        Mover = mover;
        Positionable = positionable;
        Finder = finder;
    }

    private void Start()
    {
        Finder.StartFind();
        Mover.StartMove();
    }

    private void Update()
    {
        if (Finder.TryFindPosition(out Vector2 playerPosition))
        {
            Positionable.Position = playerPosition;
            Positionable.IsPositionSet = true;
        }

        Mover.Moving(transform);
    }
}
