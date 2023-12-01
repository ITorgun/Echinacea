using UnityEngine;
using Assets.Playable_Entity_Module.Finder;
using Assets.PlayerModule;

namespace Assets.Enemy_Module.PlayerFinder
{
    public class DirectionPlayerFinder : IFinder
    {
        private readonly float _frequency;

        public Vector2 Direction { get; private set; }
        public float Range { get; private set; }
        public bool IsFinding { get; private set; }

        public DirectionPlayerFinder(Vector2 direction, float distance, float frequency)
        {
            Range = distance;
            Direction = direction;
        }

        public void StartFind() => IsFinding = true;
        public void StopFind() => IsFinding = false;

        public bool TryFindPosition(Vector2 currentPosition, out Vector2 finderPosition)
        {
            finderPosition = currentPosition;

            RaycastHit[] hits = Physics.RaycastAll(
                new Ray(currentPosition, Direction), Range);

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.TryGetComponent(out Player player))
                {
                    finderPosition = player.transform.position;
                    return true;
                }
            }

            return false;
        }
    }
}
