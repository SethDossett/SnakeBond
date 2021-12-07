using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject returnToTitle;
   
    void Update()
    {
        if(animator.GetBool("isMoving") == true)
        {
            if (returnToTitle.activeSelf != false)
                returnToTitle.SetActive(false);
        }
        else
        {
            if(returnToTitle.activeSelf != true)
                returnToTitle.SetActive(true);
        }
    }
}
