using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LogicMananger : MonoBehaviour
{
    public Text scoreText;
    public Text gdText;
    public GameObject gameOverScreen;
    private int Score=0;
    private int Gd=0;

    public void AddScore()
    {
        Score++;
        scoreText.text = "得分:" + Score;
    }

    public void AddGd()
    {
        Gd++;
        gdText.text = "功德:" + Gd;
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
