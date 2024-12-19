using Gameplay.Rails;
using Random = UnityEngine.Random;

namespace Gameplay.Bugs
{
    public class BugCrash : Bug
    {
        protected override void Start()
        {
            base.Start();
            InvokeRepeating(nameof(TraceRoute), 0, 2);
            Invoke(nameof(Spawn), 1);
        }

        protected override RailPoint DefineEndPoint()
        {
            return Vulnerable ? startPoint : target.CurrentPoint;
        }
        
        protected override void TraceRoute()
        {
            base.TraceRoute();
            EndPoint = DefineEndPoint();
            NextPointOnPath = 0;
            WayRailPoints = BreadthFirstSearch(currentPoint, EndPoint);
            
            if (WayRailPoints != null && Random.Range(0,3) == 1 && WayRailPoints.Count > 2)
            {
                WayRailPoints[2] = WayRailPoints[0];
            }
        }

        private void Spawn()
        {
            currentPoint = startPoint;
            CurrentPosition = startPoint.transform.position;
        }
    }
}
