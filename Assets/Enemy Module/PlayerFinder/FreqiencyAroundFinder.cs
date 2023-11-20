using Assets.Enemy_Module.Interfaces;
using UnityEngine;

namespace Assets.Enemy_Module.PlayerFinder
{
    public class FreqiencyAroundFinder : IFinder
    {
        private readonly float _findCooldown;

        private IFinder _playerFinder;
        private float _timer;

        public bool IsFinding => _playerFinder.IsFinding;
        public Transform FinderTransform { get; private set; }
        public float Range { get; private set; }

        public FreqiencyAroundFinder(IFinder playerFinder, float findCooldown)
        {
            _playerFinder = playerFinder;
            _findCooldown = findCooldown;
        }

        private bool IsCooldowning()
        {
            return _timer >= _findCooldown;
        }

        private void CalculateCooldown(float deltaTime)
        {
            _timer += deltaTime;
        }

        public void StartFind()
        {
            _playerFinder.StartFind();
        }

        public void StopFind()
        {
            _playerFinder.StopFind();
        }

        public bool TryFindPosition(out Vector2 position)
        {
            position = Vector2.zero;

            if (IsFinding == false)
            {
                return false;
            }

            if (IsCooldowning() == false)
            {
                CalculateCooldown(Time.deltaTime);
                return false;
            }

            _timer = 0;

            return _playerFinder.TryFindPosition(out position);
        }
    }
}
