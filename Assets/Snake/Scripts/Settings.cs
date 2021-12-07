using System.Collections;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject sureCheck;
    [SerializeField] GameObject clearText;
    
    public void OpenSettings()
    {
        if(menu.activeSelf == false)
            menu.SetActive(true);
    }
    public void CloseSettings()
    {
        if (menu.activeSelf == true)
            menu.SetActive(false);
    }
    public void AreYouSure()
    {
        if (sureCheck.activeSelf == false)
            sureCheck.SetActive(true);
    }
    public void ClearHiScores()
    {
        PlayerPrefs.DeleteAll();
        if (sureCheck.activeSelf == true)
            sureCheck.SetActive(false);

        StartCoroutine(Feedback());
    }
    IEnumerator Feedback()
    {
        if (clearText.activeSelf == false)
            clearText.SetActive(true);
        yield return new WaitForSeconds(5f);
        if (clearText.activeSelf == true)
            clearText.SetActive(false);
    }
    public void DontClear()
    {
        if (sureCheck.activeSelf == true)
            sureCheck.SetActive(false);
    }
}
