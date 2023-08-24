using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LogicMananger : MonoBehaviour
{
    //组件定义
    public PipeSpawn pipeSpawn;
    public double decreaseAmount = 0.5;
    private int currentStageScore; // 当前阶段的积分
    
    //基础UI逻辑
    public Text scoreText;
    public Text gdText;
    public GameObject gameOverScreen;
    //附加参数
    private int preScore = 1;
    private int Score=0;
    private int Gd=0;
    //结束界面
    public Text overScore;
    public Text overGd;
    public Text tip;
    
    //优化参数
    private Dictionary<int, string> scoreToTipMap; // 分数范围对应的提示信息映射表

    private void Start()
    {
        pipeSpawn = GameObject.FindGameObjectWithTag("PipeSpawn").GetComponent<PipeSpawn>();
        
    }

    private void Update()
    {
        if (preScore%10==0)
        {
            // 逐渐减小pipeSpawn的值
            pipeSpawn.spawnRate -= decreaseAmount;
            if (pipeSpawn.spawnRate<=1.5)
            {
                pipeSpawn.spawnRate = 1.5;
            }
            preScore++;
        }
        
    }

    public void AddScore()
    {
        Score++;
        preScore = Score;
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

    public void EXitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        const string DragonText = "条龙";
        const string FishText = "条鱼";
        const string OxygenText = "点氧气";
        overGd.text = gdText.text;
        overScore.text = scoreText.text;
        float finalscore = Score+Score * (Gd*Time.deltaTime);
        int roundedScore = Mathf.RoundToInt(finalscore);
        int dividedScore = roundedScore > 20 ? roundedScore >> 2 : roundedScore >> 1;  // 使用位运算代替除法
        string tipText = "你放生了" + dividedScore;
        if (roundedScore > 50)
        {
            tipText += roundedScore > 300 ? DragonText : FishText;
        }
        else
        {
            tipText += OxygenText;
        }

        tip.text = tipText;
        
        gameOverScreen.SetActive(true);
    }
    
}
