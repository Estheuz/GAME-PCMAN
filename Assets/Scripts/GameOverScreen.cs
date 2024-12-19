using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private AudioClip gameOverMusic;
    public Text blinkingText;
    public bool changeSceneAllowed;
    
    private Vector3 _cameraPosition;
    
    private void Start()
    {
       changeSceneAllowed = false;
        
       AudioSource.PlayClipAtPoint(gameOverMusic, _cameraPosition);
       InvokeRepeating("BlinkText", 0.5f,0.5f);
       Invoke("AllowChangeScene",3);
    }

    
    void Update()
    {
        if (Input.anyKey && changeSceneAllowed)
        {
            SceneManager.LoadScene("Scenes/StartScreen");
        }
    }
    
    private void BlinkText()
    {
        if (Mathf.Approximately(blinkingText.color.a, 255f))
        {
            var color = blinkingText.color;
            color.a = 0;
            blinkingText.color = color;
        }
        else
        {
            var color = blinkingText.color;
            color.a = 255f;
            blinkingText.color = color;
        }
    }

    private void AllowChangeScene()
    {
        changeSceneAllowed = true;
    }

}
