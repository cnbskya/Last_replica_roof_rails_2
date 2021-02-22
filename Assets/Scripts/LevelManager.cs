using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levelFinishBonus;
   
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < levelFinishBonus.Length; i++)
		{
            Debug.Log(levelFinishBonus[i]);
		}
    }
}
