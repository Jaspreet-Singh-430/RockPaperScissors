using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChoice : MonoBehaviour
{
    public int playerScore = 0;
    public Sprite[] spritesToChoose;
    public TextMeshProUGUI playerscoreText;
    public Button rock;
    public TextMeshProUGUI tip;
    public Button paper;
    public Button scissors;
    public Button startButton;
    public TextMeshProUGUI choicetext;
    public int choice = -1;
    public CPUChoice cpuChoice;
    public static PlayerChoice instance;
    public static bool isStarted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    void Start()
    {
        int round = RoundSelect.selectedRound;
        cpuChoice.ResetButton();
        RoundSelect.selectedRound = round;
        cpuChoice.playerAnim = cpuChoice.playerGotPoint.GetComponent<Animator>();
        cpuChoice.cpuAnim = cpuChoice.cpuGotPoint.GetComponent<Animator>();
        Debug.Log("hI ANIMATORS");

    }
    public void StartButton()
    {
        startButton.gameObject.SetActive(false);
        if (startButton.GetComponentInChildren<TextMeshProUGUI>().text != "Continue")
        {
            isStarted = true;
            tip.gameObject.SetActive(false);
            startButton.GetComponentInChildren<TextMeshProUGUI>().text = "Continue";
        }
        else {
            cpuChoice.imageChosenByCPU.gameObject.SetActive(false);
            cpuChoice.CPUchoose = -1;
            choice = -1;
            rock.gameObject.SetActive(true);
            paper.gameObject.SetActive(true);
            scissors.gameObject.SetActive(true);
        }

    }
    public void RockButton()
    {
        if (isStarted)
        {
            choice = 0;
            choicetext.text = "You chose Rock";
            rock.gameObject.SetActive(true);
            paper.gameObject.SetActive(false);
            scissors.gameObject.SetActive(false);
            Invoke("OpponentsMove", 1f);
        }
    }
    public void PaperButton()
    {
        if (isStarted)
        {
            choice = 1;
            choicetext.text = "You chose Paper";
            rock.gameObject.SetActive(false);
            paper.gameObject.SetActive(true);
            scissors.gameObject.SetActive(false);
            Invoke("OpponentsMove", 1f);
        }
    }
    public void ScissorsButton()
    {
        if (isStarted)
        {
            choice = 2;
            choicetext.text = "You chose Scissors";
            rock.gameObject.SetActive(false);
            paper.gameObject.SetActive(false);
            scissors.gameObject.SetActive(true);
            Invoke("OpponentsMove", 1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpponentsMove()
    {
        cpuChoice.PlayButton();
    }
}
