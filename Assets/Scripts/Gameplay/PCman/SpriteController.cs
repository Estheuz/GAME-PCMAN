using UnityEngine;

namespace Gameplay.PCman
{
    public class SpriteController : MonoBehaviour
    {
        private Quaternion _directionImage;
        private SpriteRenderer _spriteRenderer;
 
        void Start()
        {
            _directionImage = transform.rotation;
        
            _directionImage.x = 0;
            _directionImage.y = 0;
        
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    
        void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _spriteRenderer.flipX = true;
            
                _directionImage.z = 0;
                transform.rotation  = _directionImage;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
            
                _spriteRenderer.flipX = false;
            
                _directionImage.z = 0;
                transform.rotation  = _directionImage;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                _spriteRenderer.flipX = false;
            
                _directionImage.z = 1f;
                transform.rotation = _directionImage;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                _spriteRenderer.flipX = false;
            
                _directionImage.z = -1f;
                transform.rotation  = _directionImage;
            }
        }
        
        public void ResetRotation()
        {
            _directionImage.z = 0;
            transform.rotation = _directionImage;
        }
    }
}