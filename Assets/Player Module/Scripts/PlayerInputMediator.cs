using Assets.InputModule;
using Assets.Player_Module.Scripts;

public class PlayerInputMediator /*: IDisposable*/
{
    private IPlayerMover _movement;
    private IRangeAttackEvents _rangeAttack;
    private PlayerShootPosition _shotPosition;
    private PlayerModel _model;

    public PlayerInputMediator(IPlayerMover movement, IRangeAttackEvents rangeAttack, 
        PlayerShootPosition shotPosition, PlayerModel animatorConroller)
    {
        _movement = movement;
        _rangeAttack = rangeAttack;
        _shotPosition = shotPosition;
        _model = animatorConroller;

        //_movement.InputDirectionUpdated += OnInputDirectionUpdated;
        //_movement.MovementDirectionUpdated += OnMovementDirectionUpdated;
        //_rangeAttack.RangeAttackPressed += OnShooted;
    }

    //public void Dispose()
    //{
    //    _movement.InputDirectionUpdated -= OnInputDirectionUpdated;
    //}

    //private void OnInputDirectionUpdated(Vector2 direction)
    //{
    //    _shotPosition.UpdateState(direction);
    //}

    //private void OnMovementDirectionUpdated(Vector2 direction)
    //{
    //    _model.PlayMovementAnimation(direction);
    //}

    private void OnShooted()
    {
        _model.PlayShootAnimation(_shotPosition.CurrentVector);
        //_shotPosition.
    }

}
