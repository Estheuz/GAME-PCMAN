using Gameplay.Bugs;
using Gameplay.Power_ups;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay.PCman
{
    public class CollisionController : MonoBehaviour
    {
       public MoveController moveController;
       public BugsController bugsController;
       public SoundsManager soundsManager;
        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("point"))
            {
                Destroy(other.gameObject);
                soundsManager.PlayEatingBit();
                HUD.HUD.IncrementPoints();
            }
        
            if (other.gameObject.CompareTag("portal"))
            {
                Portal portal = other.gameObject.GetComponent<Portal>();
                
                moveController.Teleport(portal);
            }
            
            if (other.gameObject.CompareTag("bug"))
            {
                Bug bug = other.gameObject.GetComponent<Bug>();
                if (bug.IsVulnerable) 
                {
                    bugsController.DisableChaseBug(bug);
                }
                
                else
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
            
            if (other.gameObject.CompareTag("power up"))
            {
                soundsManager.PlayEatPowerUp();
                bugsController.ActiveVulnerableAllBugs();
                
                if (other.gameObject.name.Equals("multithread"))
                {
                    Destroy(other.gameObject);
                    PowerMultiThread power = gameObject.AddComponent<PowerMultiThread>();
                    power.CreateClone(gameObject); 
                }
                
                if (other.gameObject.name.Equals("clean code"))
                { 
                   Destroy(other.gameObject);
                   bugsController.DisableChaseAllBugs();
                }
                
            }
        }
    }
}

