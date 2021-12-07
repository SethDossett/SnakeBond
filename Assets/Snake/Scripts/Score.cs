using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{   
    [Header("Texts")]
    [SerializeField] Text currentScoreBoard;
    [SerializeField] Text scoreTarget;
    [SerializeField] Text gameOverText;
    [SerializeField] Text debugText;

    [Header("Values")]
    int scoreValue;
    int levelScoreTarget;
    [SerializeField] int triggerAmount_1;
    private bool triggerAmountReached = false;
    private bool gateTargetReached = false;
    public int currentScore;
    

    [Header("Componets")]
    [SerializeField] InputField inputName;
    [SerializeField] GameObject lvlCompleteScreen;
    [SerializeField] GameObject gameOverScreen;

    private Event_Master eventMaster;
    public static Score instance;
    void OnEnable()
    {
        eventMaster = GameObject.Find("EventMaster").GetComponent<Event_Master>();
        eventMaster.scorePoint += AddToScore;
        eventMaster.gameOver += GameOver;
        eventMaster.levelComplete += LevelComplete;
    }
    void OnDisable()
    {
        eventMaster.scorePoint -= AddToScore;
        eventMaster.gameOver -= GameOver;
        eventMaster.levelComplete -= LevelComplete;
    }
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreValue = 0;
        levelScoreTarget = 3;
    }
    void Update()
    {
        currentScoreBoard.text = scoreValue.ToString();
        scoreTarget.text = ($"/ {levelScoreTarget} ");
        CollectionCheck();
    }
    void AddToScore()
    {
        scoreValue = scoreValue + 1;
        currentScore = scoreValue;
    }
    void CollectionCheck()
    {
        if(currentScore == triggerAmount_1 && !triggerAmountReached)
        {
            eventMaster.CallFirstEvent();
            levelScoreTarget = 10;
            triggerAmountReached = true;
        }
        if(currentScore == levelScoreTarget && !gateTargetReached) 
        {
            eventMaster.CallGateUnlock();
            gateTargetReached = true;
        }
    }
    void LevelComplete()
    {
        if(lvlCompleteScreen.activeSelf == false)
            lvlCompleteScreen.SetActive(true);

        gameOverText.text = currentScoreBoard.text;
    }
    void GameOver()
    {
        GameOverScreen();
        PlayerPrefs.SetInt("LastScore", currentScore);
    }
    void GameOverScreen()
    {
        if (gameOverScreen.activeSelf == false)
            gameOverScreen.SetActive(true);
    }
    public void SaveButton()
    {
        if(inputName.gameObject.activeSelf == false)
        {
            eventMaster.CallRestartScene();
        }
        else
        {
            if (inputName.text == "")
            {
                if (debugText.enabled == false)
                    debugText.enabled = true;
            }
            else
            {
                //PlayerPrefs.SetInt("HiScore", currentScore);
                PlayerPrefs.SetString("HiScoreName", inputName.text);
                eventMaster.CallReturnToTitle();
            }
        }
    }
}
