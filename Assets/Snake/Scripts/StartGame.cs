using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [Header("Screen Fade")]
    [SerializeField] CanvasGroup cg;
    float currentAlpha = 0f;
    private float currentTime = 0f;
    private float duration = 1f;
    [SerializeField] AnimationCurve curve;
    void Start()
    {
        
    }
    void Update()
    {
        cg.alpha = currentAlpha;
    }
    public void GameStart()
    {
        StartCoroutine(Go());
    }
    IEnumerator Go()
    {
        if (cg.interactable == true)
            cg.interactable = false;
        if (cg.blocksRaycasts == false)
            cg.blocksRaycasts = true;
        
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float lerpPercentage = currentTime / duration;
            currentAlpha = Mathf.Lerp(currentAlpha, 1f, curve.Evaluate(lerpPercentage));
            yield return null;
        }
        
        if(currentTime > duration)
        {
            SceneManager.LoadScene(1);
        }
        yield break;
    }
}
