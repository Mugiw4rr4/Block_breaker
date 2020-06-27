using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    // config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 100;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;	
    [SerializeField] bool isAutoPlayEnabled;
    [SerializeField] bool isPaused = false;	

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
	livesText.text = "Lives : "+currentLives.ToString();  
    }

    // Update is called once per frame
    void Update () {
	if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
    {
 
       Time.timeScale = 0;
       isPaused = true;
    }
    else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
    {
       Time.timeScale = 1;
       isPaused = false;    
    } 
	
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
	
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
