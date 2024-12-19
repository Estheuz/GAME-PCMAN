using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Rails
{
    public class RailPoint : MonoBehaviour
    {
        [SerializeField] private RailPoint up;
        [SerializeField] private RailPoint left;
        [SerializeField] private RailPoint right;
        [SerializeField] private RailPoint down;
        private List<RailPoint> RailPointsNears => new() { up, left, right, down };

        public RailPoint Up
        {
            get => up;
            set => up = value;
        }

        public RailPoint Left
        {
            get => left;
            set => left = value;
        }

        public RailPoint Right
        {
            get => right;
            set => right = value;
        }

        public RailPoint Down
        {
            get => down;
            set => down = value;
        }
    
        public List<RailPoint> RailPoints
        {
            get => RailPointsNears;
        }
    }
}