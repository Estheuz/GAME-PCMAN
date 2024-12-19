using Gameplay.Rails;
using UnityEngine;

namespace Gameplay.Bugs
{
    public class BugOver : Bug
    {
        protected override void Start()
        {
            base.Start();
            InvokeRepeating(nameof(TraceRoute), 0, 2);
            Invoke(nameof(Spawn), 1);
        }

        protected override void Update()
        {
            if (WayRailPoints!=null)
            {
                if (Arrived())
                {
                    currentPoint = WayRailPoints![NextPointOnPath];
                    TraceRoute();

                    if (WayRailPoints != null && NextPointOnPath < WayRailPoints.Count-1)
                    {
                        NextPointOnPath++;
                    }
                }

                if (WayRailPoints != null)
                {
                    NextPosition = WayRailPoints[NextPointOnPath].transform.position;
                }
        
                CurrentPosition = Vector3.MoveTowards(CurrentPosition, NextPosition, Speed * Time.deltaTime);
                CachedTransform.position = CurrentPosition;
            }
    
            else
            {
                TraceRoute();
            }
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
        }

        private void Spawn()
        {
            currentPoint = startPoint;
            CurrentPosition = startPoint.transform.position;
            TraceRoute();
        }
    }
}

