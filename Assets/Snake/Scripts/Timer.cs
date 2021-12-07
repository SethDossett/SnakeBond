using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text gameOverTimeText;
    [SerializeField] Text timerText;
    [SerializeField] InputField inputName;
    [SerializeField] UnityEvent newHiScore;
    private float currentTime = 0;
    private bool timerPaused = false;


    Event_Master eventMaster;
    void OnEnable()
    {
        eventMaster = GameObject.Find("EventMaster").GetComponent<Event_Master>();
        eventMaster.firstEvent += SpeedIncrease;
        eventMaster.gameOver += RestartTimer;
        eventMaster.levelComplete += PauseTimer;
    }
    void OnDisable()
    {
        eventMaster.firstEvent -= SpeedIncrease;
        eventMaster.gameOver -= RestartTimer;
        eventMaster.levelComplete -= PauseTimer;
    }
    void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (!timerPaused)
        {
            currentTime += Time.unscaledDeltaTime;
            DisplayTimer(currentTime);
        }
    }
    void StartTimer()
    {
        if (timerPaused)
            timerPaused = false;
    }
    void PauseTimer()
    {
        if (!timerPaused)
            timerPaused = true;
        
        if (currentTime < PlayerPrefs.GetFloat("BestTime") || PlayerPrefs.GetFloat("BestTime") == 0)
        {
            newHiScore?.Invoke();
            PlayerPrefs.SetFloat("BestTime", currentTime);
            PlayerPrefs.SetString("BestTimeString", timerText.text);
            
        }
        
        gameOverTimeText.text = timerText.text;

    }
    void RestartTimer()
    {
        
    }
    void DisplayTimer(float TimeToDisplay)
    {
        float minutes = Mathf.FloorToInt(TimeToDisplay / 60);
        float seconds = Mathf.FloorToInt(TimeToDisplay % 60);
        float milliSeconds = (TimeToDisplay % 1) * 9;
        timerText.text = string.Format("{0:0}:{1:00}:{2:0}", minutes, seconds, milliSeconds);
    }
    void SpeedIncrease()
    {
        Time.timeScale = 1.5f;
    }
}
