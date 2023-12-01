using Assets.PlayableEntityModule;
using Assets.PlayableEntityModule.Mover;
using Assets.Player_Module.Scripts;
using Assets.Player_Module.Scripts.Movement;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour, IPlayerMovement
{
    public IPlayerMover PlayerMover { get; private set; }

    [Inject]
    public void Constructor(IPlayerMover mover)
    {
        PlayerMover = mover;
    }

    private void Start()
    {
        PlayerMover.StartMove();
    }

    private void Update()
    {
        PlayerMover.Moving(transform);
    }
}
