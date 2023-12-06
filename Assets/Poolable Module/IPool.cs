using Assets.EnemyModule.Grounded.RobotBomb;

namespace Assets.Enemy_Module.Grounded.Robot_Bomb.Configs
{
    public interface IPool<T>
    {
        T Get();
        void Release(T element);
        void ClearPool();
    }
}
