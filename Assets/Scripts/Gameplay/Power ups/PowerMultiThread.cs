using Gameplay.PCman;
using UnityEngine;

namespace Gameplay.Power_ups
{
    public class PowerMultiThread : MonoBehaviour
    {
        private GameObject _clone;
    
        public void CreateClone(GameObject original)
        {
            _clone = Instantiate(original);
        
            MoveController cloneMoveController = _clone.GetComponent<MoveController>();
            MoveController originalMoveController = original.GetComponent<MoveController>();
        
            cloneMoveController.UpdateCurrentPoint(originalMoveController.CurrentPoint);
        
            cloneMoveController.InvertDirection();
            _clone.GetComponent<SpriteController>().ResetRotation();
        
            Invoke("DestroyClone", 10);
        }

        private void DestroyClone()
        {
            Destroy(_clone);
        }
    }
}
