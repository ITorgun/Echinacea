using Assets.Playable_Entity_Module;
using Assets.Player_Module.Scripts;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    public IPlayerMover Mover { get; private set; }

    [Inject]
    public void Constructor(IPlayerMover mover)
    {
        Mover = mover;
    }

    private void Start()
    {
        Mover.StartMove();
    }

    private void Update()
    {
        Mover.Moving();
    }
}
