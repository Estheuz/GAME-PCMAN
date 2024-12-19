using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private AudioClip startMusic;
    [SerializeField] private Text blinkingText;
    
    private Vector3 _cameraPosition;
    private bool actived;
    
    private void Start()
    {
        if (Camera.main != null) _cameraPosition = Camera.main.transform.position;
        InvokeRepeating("BlinkText", 0.5f,0.5f);
    }
    
    void Update()
    {
        if (Input.anyKey && !actived)
        {
           actived = true;
           AudioSource.PlayClipAtPoint(startMusic, _cameraPosition, 0.2f);
           StartCoroutine(LoadScene(5f));
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
    
    private IEnumerator LoadScene(float delay)
    { 
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Scenes/StageClassic");
    }
}
