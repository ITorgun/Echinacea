using Assets.Enemy_Module.Interfaces;
using Assets.PlayerModule;
using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Assets.Enemy_Module.PlayerFinder
{
    public class ForwardPlayerFinder 
    {
        public Transform FinderTransform {get; private set;}
        public float Range { get; private set; }

        public bool IsFinding => throw new NotImplementedException();

        public void StartFind()
        {
            throw new NotImplementedException();
        }

        public void StopFind()
        {
            throw new NotImplementedException();
        }

        public bool TryFindPlayer(out Vector3 playerPosition)
        {
            RaycastHit[] hits = Physics.RaycastAll(
                new Ray(FinderTransform.position, FinderTransform.forward), Range);

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.TryGetComponent(out Player player))
                {
                    playerPosition = player.transform.position;
                    return true;
                }
            }

            playerPosition = Vector3.zero;
            return false;
        }
    }
}
