using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Gameplay.HUD
{
    public class HUD : MonoBehaviour
    {
        private static int _points;
        [SerializeField] private Text scoreText;
        void Start()
        {
            _points = 0;
        }
    
        void Update()
        {
            scoreText.text = _points.ToString();
        }

        public static void IncrementPoints()
        {
            _points++;
            if (_points >= 181)
            {
                GameOver();
            }
        }

        private static void GameOver()
        {
            SceneManager.LoadScene("CongratulationsScreen");
        }
    }
}
