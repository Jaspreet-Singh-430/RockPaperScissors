using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public Button soundplay;
    public Button soundMute;
    private AudioSource aS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aS=GetComponent<AudioSource>();
        soundplay.onClick.AddListener(Play);
        soundMute.onClick.AddListener(Mute);
    }
    public void Play()
    {
        aS.mute = true;
        soundplay.gameObject.SetActive(false);
        soundMute.gameObject.SetActive(true);
    }
    public void Mute() {
        aS.mute=false;
        soundplay.gameObject.SetActive(true);
        soundMute.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
