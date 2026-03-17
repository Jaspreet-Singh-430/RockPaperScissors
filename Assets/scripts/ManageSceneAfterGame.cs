using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class ManageSceneAfterGame : MonoBehaviour
{
    public Button MenuButton;
    public Button RestartButton;
    private CPUChoice cpuChoice;
    public static bool isPlayingAgain=false;
    public static bool hasWon=false;
    public TextMeshProUGUI winningMessage;
    public Sprite[] image;
    public Image imagetoShow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Color c = imagetoShow.color;
        c.a = 1f;
        imagetoShow.color= c;
        DontDestroyOnLoad(gameObject);
        cpuChoice = FindObjectOfType<CPUChoice>();
        if (hasWon == true)
        {
            imagetoShow.sprite = image[0];
            winningMessage.text = "Congratulations";
        }
        else {
            imagetoShow.sprite = image[1];
            winningMessage.text = "You Lost !";
        }
    }
    public void GoToRoundMenu()
    {
        isPlayingAgain = false;
        //CPUChoice.instance.ResetButton();
        SceneManager.LoadScene(1);
    }
    public void RestartGame()
    {
        isPlayingAgain=true;
        //CPUChoice.instance.ResetButton();
        SceneManager.LoadScene(2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
