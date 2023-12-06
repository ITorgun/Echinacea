using Assets.Player_Module.Scripts;

namespace Assets.PlayableEntityModule.Mover
{
    public interface IPlayerMovable
    {
        IPlayerMover Mover { get; }
    }
}
