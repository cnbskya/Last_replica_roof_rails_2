using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimationController : MonoBehaviour
{
    void Update()
    {
        if (GameManager.instance.isGameOn == true)
        {
            gameObject.SetActive(true);
        }
        else
            gameObject.SetActive(false);
    }
}
