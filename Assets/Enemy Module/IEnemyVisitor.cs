using Assets.EnemyModule.Grounded.RobotBomb;

namespace Assets.Enemy_Module
{
    public interface IEnemyVisitor
    {
        void Visit(IDamageable enemy);
        void Visit(RobotBombEnemy robotBombEnemy);
    }
}
