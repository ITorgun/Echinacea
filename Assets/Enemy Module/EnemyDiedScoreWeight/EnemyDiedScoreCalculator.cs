using Assets.EnemyModule.Grounded.RobotBomb;
using UnityEngine;

namespace Assets.Enemy_Module.EnemyDiedScoreWeight
{
    public class EnemyDiedScoreCalculator : IEnemyVisitor
    {
        private readonly int Limit;
        private readonly RobotBombScoreCalculator RobotBombCalculator;

        public int Sum { get; private set; }
        public bool IsSumLimited => Sum >= Limit;

        public EnemyDiedScoreCalculator(int scoreLimit)
        {
            Limit = scoreLimit;
            RobotBombCalculator = new RobotBombScoreCalculator();
        }

        class RobotBombScoreCalculator
        {
            private const int _weightModifier = 2;

            public int CalculateScore(RobotBombEnemy enemy)
            { 
                return (int)((enemy.RobotMovement.Mover.Speed + enemy.Bomb.Damage) / _weightModifier);
            }
        }

        public void Reset()
        {
            Sum = 0;
        }

        public void Visit(IDamageable enemy)
        {
            Visit((dynamic)enemy);
        }

        public void Visit(RobotBombEnemy enemy)
        {
            Sum += RobotBombCalculator.CalculateScore(enemy);
        }
    }
}
