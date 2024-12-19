using Gameplay.Rails;

namespace Gameplay.Bugs
{
    public class BugLag : Bug
    {
        protected override void Start()
        {
            base.Start();
            InvokeRepeating(nameof(TraceRoute), 0, 5);
            Invoke(nameof(Spawn), 15);
        }

        protected override RailPoint DefineEndPoint()
        {
            return Vulnerable ? startPoint : target.CurrentPoint;
        }

        private void Spawn()
        {
            currentPoint = startPoint;
            CurrentPosition = startPoint.transform.position;
        }
    }
}

