using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public GameObject startMenuUI;
    public GameObject gameInUI;
    public GameObject GameOverUI;
    public bool uıIsActif;
    private Scene _scene;


    private void Start()
    {
        instance = this;
        _scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && uıIsActif)
        {
            GameManager.instance.isGameOn = true;
            ResumeGame();
            uıIsActif = false;
        }
    }
    public void RestartGameButton()
    {
        Application.LoadLevel("SampleScene");
    }
    void ResumeGame()
    {
        GameManager.instance.isGameOn = true;
        FindObjectOfType<PlayerAnimator>().animator.SetBool("isGameOn", true);
        startMenuUI.SetActive(false);
        gameInUI.SetActive(true);
    }

    public void GameOver()
	{
        GameOverUI.SetActive(true);
        gameInUI.SetActive(false);
	}
}