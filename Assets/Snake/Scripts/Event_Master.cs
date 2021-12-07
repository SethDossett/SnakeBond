using UnityEngine;

public class Event_Master : MonoBehaviour
{
    public delegate void EventManager();
    public event EventManager restartScene;
    public event EventManager startScene;
    public event EventManager gateUnlocked;
    public event EventManager firstEvent;
    public event EventManager scorePoint;
    public event EventManager gameOver;
    public event EventManager death;
    public event EventManager respawn;
    public event EventManager returnToTitle;
    public event EventManager levelComplete;

    public void CallRestartScene()
    {
        restartScene?.Invoke();
    }
    public void CallStartScene()
    {
        startScene?.Invoke();
    }
    public void CallGateUnlock()
    {
        gateUnlocked?.Invoke();
    }
    public void CallFirstEvent()
    {
        firstEvent?.Invoke();
    }
    public void CallScorePoint()
    {
        scorePoint?.Invoke();
    }
    public void CallGameOver()
    {
        gameOver?.Invoke();
    }
    public void CallDeath()
    {
        death?.Invoke();
    }
    public void CallRespawn()
    {
        respawn?.Invoke();
    }
    public void CallReturnToTitle()
    {
        returnToTitle?.Invoke();
    }
    public void CallLevelComplete()
    {
        levelComplete?.Invoke();
    }
}
