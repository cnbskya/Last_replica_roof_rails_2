using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOn;
    public bool isSlide;
    void Start()
    {
        instance = this;
    }
}
