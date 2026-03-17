using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CPUChoice : MonoBehaviour
{
    //public ManageSceneAfterGame ms;
    public int CPUScore=0;
    public Image resultBanner;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI CPUscoreText;
    public Sprite[] spritetoChoose;
    public int CPUchoose=-1;
    public Image imageChosenByCPU;
    public PlayerChoice playerchoice;
    public TextMeshProUGUI winText;
    public Button reset;
    public static CPUChoice instance;
    public TextMeshProUGUI playerGotPoint;
    public TextMeshProUGUI cpuGotPoint;
    public Animator playerAnim;
    public Animator cpuAnim;
    void Awake()
    {
        if (instance == null)
        {
            Debug.Log("I am in");
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("I am not in");
            Destroy(gameObject);
        }
    }
    //public RoundSelect roundselect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
        //Debug.Log("Start called");
        //ResetButton();
        //DontDestroyOnLoad(gameObject);
    }
    void GoToResultScene()
    {
            SceneManager.LoadScene(3);

    }
    private void UpdatePlayerScore()
    {
            playerchoice.playerscoreText.text="Score: "+playerchoice.playerScore;
    }
    private void UpdateCPUScore()
    {
            CPUscoreText.text = "Score: " + CPUScore;
        
    }
    public void PlayButton()
    {
        imageChosenByCPU.gameObject.SetActive(true);
        CPUchoose = Random.Range(0,spritetoChoose.Length);
        imageChosenByCPU.sprite=spritetoChoose[CPUchoose];
        if (CPUchoose == playerchoice.choice)
        {
            //winText.text = "Game is Tied";
            playerchoice.startButton.gameObject.SetActive(true);
            
        }
        if (CPUchoose == 0 && playerchoice.choice == 2 || CPUchoose == 1 && playerchoice.choice == 0 || CPUchoose == 2 && playerchoice.choice == 1) {
            //cpuGotPoint.gameObject.SetActive(true);
            cpuAnim.SetTrigger("CPUPointUp");
            CPUScore += 1;
            cpuAnim.SetTrigger("GoToNormal");
            Invoke("UpdateCPUScore", 1f);
            playerchoice.startButton.gameObject.SetActive(true);
            if (RoundSelect.selectedRound == CPUScore)
            {
                resultBanner.gameObject.SetActive(true);
                resultText.text = "GAME OVER";
                winText.text = "You lost !";
                ManageSceneAfterGame.hasWon=false;
                Invoke("GoToResultScene",2f);
            }
        }
        if (CPUchoose == 1 && playerchoice.choice == 2 || CPUchoose == 2 && playerchoice.choice == 0 || CPUchoose == 0 && playerchoice.choice == 1) {
            //playerGotPoint.gameObject.SetActive(true);
            playerAnim.SetTrigger("PlayerPointUp");
     playerchoice.playerScore=playerchoice.playerScore+ 1;
            Invoke("UpdatePlayerScore", 1f);
            playerAnim.SetTrigger("GoToNormal");
            playerchoice.startButton.gameObject.SetActive(true);
            if (RoundSelect.selectedRound == playerchoice.playerScore)
            {
                resultBanner.gameObject.SetActive(true);
                resultText.text = "VICTORY";
                winText.text = "You Win !";
                ManageSceneAfterGame.hasWon =true;
                Invoke("GoToResultScene", 2f);
            }

        }
        //reset.gameObject.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
            
    }
    public void ResetButton()
    {
        if(!ManageSceneAfterGame.isPlayingAgain)
        RoundSelect.selectedRound = 0;
        Debug.Log("The selected round: " + RoundSelect.selectedRound);
        PlayerChoice.isStarted = false;
        playerchoice.startButton.GetComponentInChildren<TextMeshProUGUI>().text = "Start";
        imageChosenByCPU.gameObject.SetActive(false);
        CPUchoose = -1;
        playerchoice.choice = -1;
        playerchoice.startButton.gameObject.SetActive(true);
        playerchoice.tip.gameObject.SetActive(true);
        playerchoice.rock.gameObject.SetActive(true);
        playerchoice.paper.gameObject.SetActive(true);
        playerchoice.scissors.gameObject.SetActive(true);
        winText.text = "";
        playerchoice.choicetext.text = "";
        //reset.gameObject.SetActive(false);
    }
}
