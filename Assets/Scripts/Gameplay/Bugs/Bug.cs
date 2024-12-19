using System.Collections.Generic;
using Gameplay.PCman;
using Gameplay.Rails;
using UnityEngine;

namespace Gameplay.Bugs
{
    public abstract class Bug : MonoBehaviour
    {
        [SerializeField] protected RailPoint currentPoint;
        [SerializeField] protected MoveController target;
        [SerializeField] protected RailPoint startPoint;

        protected bool Vulnerable;
        private bool _offChase;

        private SpriteRenderer _spriteRenderer;

        protected RailPoint EndPoint;
        protected int NextPointOnPath;
        protected List<RailPoint> WayRailPoints;

        protected Vector3 CurrentPosition;
        protected Vector3 NextPosition;
        protected Transform CachedTransform;
        protected float Speed;

        protected virtual void Start()
        {
            CachedTransform = transform;
            CurrentPosition = currentPoint?.transform.position ?? Vector3.zero;
            Speed = 2;

            Vulnerable = false;
            _offChase = false;

            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        protected virtual void Update()
        {
            if (WayRailPoints != null && (!Vulnerable || _offChase))
            {
                if (Arrived())
                {
                    currentPoint = WayRailPoints[NextPointOnPath];
                    if (NextPointOnPath < WayRailPoints.Count - 1)
                    {
                        NextPointOnPath++;
                    }
                }

                NextPosition = WayRailPoints[NextPointOnPath].transform.position;
                CurrentPosition = Vector3.MoveTowards(CurrentPosition, NextPosition, Speed * Time.deltaTime);
                CachedTransform.position = CurrentPosition;
            }
        }

        protected List<RailPoint> BreadthFirstSearch(RailPoint start, RailPoint end)
        {
            var queue = new Queue<RailPoint>();
            var visited = new HashSet<RailPoint>();
            var predecessors = new Dictionary<RailPoint, RailPoint>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current == end)
                {
                    return ReconstructPath(predecessors, start, end);
                }

                foreach (var neighbor in current.RailPoints)
                {
                    if (neighbor && !visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                        predecessors[neighbor] = current;
                    }
                }
            }

            return null;
        }

        private List<RailPoint> ReconstructPath(Dictionary<RailPoint, RailPoint> predecessors, RailPoint start, RailPoint end)
        {
            var path = new List<RailPoint>();
            var current = end;

            while (current != start)
            {
                path.Add(current);
                current = predecessors[current];
            }

            path.Add(start);
            path.Reverse();
            return path;
        }

        protected bool Arrived()
        {
            return Vector3.Distance(CurrentPosition, NextPosition) < 0.1f;
        }

        public void ActivateVulnerability()
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            Vulnerable = true;
            Invoke(nameof(DisableVulnerability), 10);
        }

        protected void DisableVulnerability()
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            Vulnerable = false;
        }

        public void DisableChase()
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, 0.1f);
            _offChase = true;
            TraceRoute();
            Invoke(nameof(RestartChase), 10);
        }

        protected void RestartChase()
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            Vulnerable = false;
            _offChase = false;
        }

        protected virtual void TraceRoute()
        {
            EndPoint = DefineEndPoint();
            NextPointOnPath = 0;
            WayRailPoints = BreadthFirstSearch(currentPoint, EndPoint);
        }

        protected abstract RailPoint DefineEndPoint();

        public bool IsVulnerable => Vulnerable;
    }
}
