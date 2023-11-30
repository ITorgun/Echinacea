using UnityEngine;
using Assets.PlayerModule;
using Assets.Enemy_Module.Interfaces;

namespace Assets.Enemy_Module
{
    public class AroundItselfPlayerFinder : IFinder
    {
        //public Transform FinderTransform { get; private set; }
        public float Range { get; private set; }
        public bool IsFinding { get; private set; }

        //public AroundItselfPlayerFinder(Transform finderTranform, float radius)
        //{
        //    FinderTransform = finderTranform;
        //    Range = radius;
        //}

        public AroundItselfPlayerFinder(float radius)
        {
            Range = radius;
        }

        public void StartFind() => IsFinding = true;
        public void StopFind() => IsFinding = false;

        public bool TryFindPosition(Vector2 currentPosition, out Vector2 position)
        {
            position = currentPosition;

            if (IsFinding == false)
            {
                return false;
            }

            //Collider2D[] colliders = Physics2D.OverlapCircleAll(FinderTransform.position, Range);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(currentPosition, Range);

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out Player player))
                {
                    position = player.transform.position;
                    return true;
                }
            }

            return false;
        }
    }
}
