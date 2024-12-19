using System.Collections.Generic;
using Gameplay.Rails;
using UnityEngine;

namespace Gameplay.Bugs
{
    public class BugGlitch : Bug
    {
        [SerializeField] protected List<RailPoint> edgeRailPoints;
        protected override void Start()
        {
            base.Start();
            InvokeRepeating(nameof(TeleportToEdge), 12, 6);
            Invoke(nameof(Spawn), 9);
            InvokeRepeating(nameof(TraceRoute), 3, 1);
        }

        protected override RailPoint DefineEndPoint()
        {
            return Vulnerable ? startPoint : target.CurrentPoint;
        }

        private void TeleportToEdge()
        {
            currentPoint = edgeRailPoints[Random.Range(0, edgeRailPoints.Count)];
            CurrentPosition = currentPoint.transform.position;
            CachedTransform.position = CurrentPosition;
        }

        private void Spawn()
        {
            currentPoint = startPoint;
            CurrentPosition = startPoint.transform.position;
        }
    }
}

