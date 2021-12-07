using System.Collections;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] CanvasGroup cg;
    Canvas canvas;
    float currentAlpha;
    private float lerpPercentage;
    private float currentTime;
    private float duration;
    [SerializeField] AnimationCurve curveIn;
    [SerializeField] AnimationCurve curveOut;

    public static Transition instance;
    void Awake()
    {
        instance = this;
    }
    Event_Master eventMaster;
    void OnEnable()
    {
        eventMaster = GameObject.Find("EventMaster").GetComponent<Event_Master>();
        eventMaster.startScene += FadeIn;
        eventMaster.restartScene += FadeOut;
        eventMaster.returnToTitle += FadeOut;
        eventMaster.levelComplete += FadeOut;
        eventMaster.death += FadeOut;
    }
    void OnDisable()
    {
        eventMaster.startScene -= FadeIn;
        eventMaster.restartScene -= FadeOut;
        eventMaster.returnToTitle -= FadeOut;
        eventMaster.levelComplete -= FadeOut;
        eventMaster.death -= FadeOut;
    }
    void Start()
    {
        canvas = GetComponent<Canvas>();
        
        
    }
    void Update()
    {
        cg.alpha = currentAlpha;
    }
    public void FadeIn()
    {
        StartCoroutine(FadingIn());
    }
    IEnumerator FadingIn()
    {
        currentTime = 0f;
        currentAlpha = 1f;
        duration = 1.5f;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            lerpPercentage = currentTime / duration;
            currentAlpha = Mathf.Lerp(currentAlpha, 0, curveIn.Evaluate(lerpPercentage));
            yield return null;
        }
        if(currentTime > duration)
        {
            canvas.enabled = false;
        }
        
        yield break;
    }
    public void FadeOut()
    {
        currentTime = 0f;
        currentAlpha = 0f;
        canvas.enabled = true;
        StartCoroutine(FadingOut());
    }

    IEnumerator FadingOut()
    {
        duration = 1f;
        
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            lerpPercentage = currentTime / duration;
            currentAlpha = Mathf.Lerp(currentAlpha, 1, curveOut.Evaluate(lerpPercentage));
            yield return null;
        }
        
        yield break;
    }
    
}
