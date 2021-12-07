using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Handler : MonoBehaviour
{
    Event_Master eventMaster;
    Scene currentScene;

    void OnEnable()
    {
        eventMaster = GameObject.Find("EventMaster").GetComponent<Event_Master>();
        eventMaster.returnToTitle += ReturnToTitleScene;
        eventMaster.restartScene += RestartScene;
    }
    void OnDisable()
    {
        eventMaster.returnToTitle -= ReturnToTitleScene;
        eventMaster.restartScene -= RestartScene;
    }

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }
    void ReturnToTitleScene()
    {
        StartCoroutine(DoReturn());
    }
    IEnumerator DoReturn()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);

    }
    public void RestartScene()
    {
        StartCoroutine(DoRestart());
    }
    IEnumerator DoRestart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
