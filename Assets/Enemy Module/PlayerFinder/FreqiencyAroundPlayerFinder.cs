using UnityEngine;
using Assets.Playable_Entity_Module.Finder;

namespace Assets.Enemy_Module.PlayerFinder
{
    public class FreqiencyAroundPlayerFinder : IFinder
    {
        private readonly float _findCooldown;

            private IFinder _playerFinder;
            private float _timer;
            private bool _isPlayerFinded = false;

        public bool IsFinding => _playerFinder.IsFinding;
        public float Range => _playerFinder.Range;

        public FreqiencyAroundPlayerFinder(IFinder playerFinder, float findCooldown)
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

        public bool TryFindPosition(Vector2 currentPosition, out Vector2 position)
        {
            position = currentPosition;

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

            bool result = _playerFinder.TryFindPosition(currentPosition, out position);
            _isPlayerFinded = result;
            return result;
        }
    }
}
