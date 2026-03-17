using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RoundSelect : MonoBehaviour
{
    public static int selectedRound=0;
    public Button OneRoundButton;
    public Button ThreeRoundButton;
    public Button FiveRoundButton;
    public Button TenRoundButton;
    public Button BackButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void LoadGameScene()
    {
        SceneManager.LoadScene(2);
    }
    public void SelectOneRound()
    {
        selectedRound = 1;
        LoadGameScene();
    }
    public void SelectThreeRound()
    {
        selectedRound = 3;
        LoadGameScene();
    }
   public void SelectFiveRound()
    {
        selectedRound = 5;
        LoadGameScene();
    }
    public void SelectTenRound()
    {
        selectedRound = 10;
        LoadGameScene();
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
