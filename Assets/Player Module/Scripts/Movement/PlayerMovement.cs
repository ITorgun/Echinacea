using Assets.Player_Module.Scripts;
using Assets.Player_Module.Scripts.Movement;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour, IPlayerMovement
{
    private PlayerModel _model;
    private PlayerShootPosition _shootPosition;

    public IPlayerMover Mover { get; private set; }

    [Inject]
    public void Constructor(IPlayerMover mover, PlayerModel model, PlayerShootPosition shootPosition)
    {
        Mover = mover;
        _model = model;
        _shootPosition = shootPosition;

        Mover.InputDirectionUpdated += OnInputDirectionUpdated;
        Mover.MovementDirectionUpdated += OnMovementDirectionUpdated;
    }

    private void OnDisable()
    {
        Mover.InputDirectionUpdated -= OnInputDirectionUpdated;
        Mover.MovementDirectionUpdated -= OnMovementDirectionUpdated;
    }

    private void Start()
    {
        Mover.StartMove();
    }

    private void Update()
    {
        Mover.Moving(transform);
    }

    private void OnInputDirectionUpdated(Vector2 direction)
    {
        _shootPosition.UpdateState(direction);
    }

    private void OnMovementDirectionUpdated(Vector2 direction)
    {
        _model.PlayMovementAnimation(direction);
    }
}
