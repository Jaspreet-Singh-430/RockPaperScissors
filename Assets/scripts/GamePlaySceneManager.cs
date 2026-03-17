using UnityEngine;
using UnityEngine.SceneManagement;
public class GamePlaySceneManager : MonoBehaviour
{
    AudioSource aud;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aud= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButtonSound()
    {
        aud.Play();
        Invoke("LoadGameScene", 0.5f);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
