using UnityEngine;
using UnityEngine.UI;

public class HiScores : MonoBehaviour
{
    [SerializeField] Text previousScore;
    [SerializeField] Text newHiScore;
    [SerializeField] Text newBestTime;
    [SerializeField] Text newBestTimeName;
    public static HiScores instance;
    void Awake()
    {
        instance = this;
        
    }
    void Start()
    {
        
        previousScore.text = PlayerPrefs.GetInt("LastScore").ToString();
        newHiScore.text = PlayerPrefs.GetString("HiScoreName") + " " + PlayerPrefs.GetInt("HiScore").ToString();
        newBestTime.text = PlayerPrefs.GetString("BestTimeString");
        newBestTimeName.text = $"{PlayerPrefs.GetString("HiScoreName")}:";
    }
}
