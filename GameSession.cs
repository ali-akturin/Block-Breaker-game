using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {
    [Range(0.1f,10f)][SerializeField] float gameSpeed =1f;
    [SerializeField] int pointsPerBlockDestroyed = 100;
    [SerializeField] int currentScore=0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;
    // Update is called once per frame

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            
        }
    }


    void Update () {
        Time.timeScale = gameSpeed;
        scoreText.text = currentScore.ToString();
    }
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }
    public void Gamereset()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
