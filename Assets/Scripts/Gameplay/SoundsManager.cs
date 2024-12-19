using UnityEngine;

namespace Gameplay
{
    public class SoundsManager : MonoBehaviour
    {
        [SerializeField] private AudioClip loopSound;
        [SerializeField] private AudioClip eatBit;
        [SerializeField] private AudioClip eatPowerUp;
        
        
        private AudioSource _audioSourceLoop;
        private AudioSource _audioSourcePoint;

        void Start()
        {
            _audioSourceLoop = gameObject.AddComponent<AudioSource>();
            _audioSourcePoint = gameObject.AddComponent<AudioSource>();
            
            _audioSourceLoop.volume = 0.5f;
            
            _audioSourcePoint.spatialBlend = 0.0f;
            _audioSourcePoint.volume = 0.2f;
            
            _audioSourceLoop.clip = loopSound;
            _audioSourceLoop.loop = true; 
            _audioSourceLoop.playOnAwake = true; 
            
            _audioSourceLoop.Play();
        }
        

        public void PlayEatingBit()
        {
            if (!_audioSourcePoint.isPlaying)
            {
                _audioSourcePoint.PlayOneShot(eatBit);
            }
        }
        
        public void PlayEatPowerUp()
        { 
            _audioSourcePoint.PlayOneShot(eatPowerUp);
        }
        
    }
}
