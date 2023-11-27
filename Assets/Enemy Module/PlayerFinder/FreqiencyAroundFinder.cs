using Assets.Enemy_Module.Interfaces;
using UnityEngine;

namespace Assets.Enemy_Module.PlayerFinder
{
    public class FreqiencyAroundFinder : IFinder
    {
        private readonly float _findCooldown;

        private IFinder _playerFinder;
        private float _timer;
        private bool _isPlayerFinded = false;

        public bool IsFinding => _playerFinder.IsFinding;
        public Transform FinderTransform => _playerFinder.FinderTransform;
        public float Range => _playerFinder.Range;

        public FreqiencyAroundFinder(IFinder playerFinder, float findCooldown)
        {
            _playerFinder = playerFinder;
            _findCooldown = findCooldown;
            _timer = _findCooldown;
        }

        private bool IsCooldowning()
        {
            return _timer <= _findCooldown;
        }

        private void CalculateCooldown()
        {
            _timer += Time.deltaTime;
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
            position = FinderTransform.transform.position;

            if (IsFinding == false)
            {
                return false;
            }

            if(_isPlayerFinded == false)
            {
                if (IsCooldowning())
                {
                    CalculateCooldown();
                    return false;
                }
            }

            _timer = 0;

            bool result = _playerFinder.TryFindPosition(out position);
            _isPlayerFinded = result;
            return result;
        }
    }
}
