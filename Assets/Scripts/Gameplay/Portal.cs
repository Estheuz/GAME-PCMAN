using Gameplay.Rails;
using UnityEngine;

namespace Gameplay
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private RailPoint teleportReferencePoint;
        [SerializeField] private RailPoint nextPoint;

        public  RailPoint Teleport
        {
            get => teleportReferencePoint;
            set => teleportReferencePoint = value;
        }

        public RailPoint NextPoint
        {
            get => nextPoint;
            set => nextPoint = value;
        }
    }
}
