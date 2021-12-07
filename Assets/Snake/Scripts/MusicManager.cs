using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource music;

    [SerializeField] AudioMixer audioMixer;
    [SerializeField] string exposedParam;
    [SerializeField] float fadeDuration;
    [SerializeField] float targetVolume;

    Event_Master eventMaster;
    void OnEnable()
    {
        eventMaster = GameObject.Find("EventMaster").GetComponent<Event_Master>();
        eventMaster.returnToTitle += MusicOff;
        eventMaster.levelComplete += MusicOff;
        eventMaster.gameOver += MusicOff;
    }
    void OnDisable()
    {
        eventMaster.returnToTitle -= MusicOff;
        eventMaster.levelComplete -= MusicOff;
        eventMaster.gameOver -= MusicOff;
    }
    void Start()
    {
        MusicOn();
    }

    void Update()
    {
        
    }
    public void MusicOn()
    {
        targetVolume = 1;
        fadeDuration = 2f;
        StartCoroutine(FadeMixerGroup.StartFade(audioMixer, exposedParam, fadeDuration, targetVolume));
        music.Play();
    }
    public void MusicOff()
    {
        targetVolume = 0;
        fadeDuration = 2f;
        //music.Stop();
        StartCoroutine(FadeMixerGroup.StartFade(audioMixer, exposedParam, fadeDuration, targetVolume));
    }

}
