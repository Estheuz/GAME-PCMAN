using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Points
{
    public class Point : MonoBehaviour
    {
        [SerializeField] private Sprite zero;
        [SerializeField] private Sprite one;
        private SpriteRenderer _spriteRenderer;

        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            Sprite[] sprites = { zero, one};
            _spriteRenderer.sprite = sprites[Random.Range(0,2)];
        }

        private void OnDestroy()
        {
           // HUD.HUD.IncrementPoints();
        }
    }
}
