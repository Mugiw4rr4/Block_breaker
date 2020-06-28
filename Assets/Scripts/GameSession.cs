using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    // config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] bool isAutoPlayEnabled;
    [SerializeField] TextMeshProUGUI highscoreText;

    // state variables
    [SerializeField] int currentScore = 0;
    [SerializeField] int currentLives = 3;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString(); 
        livesText.text = "vie restante : "+currentLives.ToString(); 
        highscoreText.text="";   
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = gameSpeed;
	}

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
    public int UpdateLives()
    {
    currentLives = currentLives-1;
    livesText.text = "Lives : "+currentLives.ToString();
    return currentLives;  
            
    }
    public bool HighscoreCheck(){
        bool check;
        int highscore=PlayerPrefs.GetInt("HIGHSCORE");
        if(currentScore>highscore){
            check=true;
            highscoreText.text="Congrats you have a new highscore !!";

        }
        else{check=false;}
        return check;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
    
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
