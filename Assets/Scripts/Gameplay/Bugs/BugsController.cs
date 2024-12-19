using UnityEngine;

namespace Gameplay.Bugs
{
    public class BugsController : MonoBehaviour
    {
        [SerializeField] private BugCrash bugCrash;
        [SerializeField] private BugGlitch bugGlitch;
        [SerializeField] private BugOver bugOver;
        [SerializeField] private BugLag bugLag;
        

        public void ActiveVulnerableAllBugs()
        {
            bugCrash.ActivateVulnerability();
            bugGlitch.ActivateVulnerability();
            bugOver.ActivateVulnerability();
            bugLag.ActivateVulnerability();
        }

        public void DisableChaseBug(Bug bug)
        {
            bug.DisableChase();  
        }
        
        public void DisableChaseAllBugs()
        {
            bugCrash.DisableChase();
            bugGlitch.DisableChase();
            bugOver.DisableChase();
            bugLag.DisableChase();
        }
    }
}
