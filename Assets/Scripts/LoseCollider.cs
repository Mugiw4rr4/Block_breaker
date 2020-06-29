using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {
	
	Ball ball; 
	GameSession gs;
	int currentLives;

	void Start () {
        gs = FindObjectOfType<GameSession>();
	ball = FindObjectOfType<Ball>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
	
	currentLives = gs.UpdateLives();	
	
		if(currentLives == 0)
	   {
		SceneManager.LoadScene("Partie terminée .. vous avez perdu x)");
	   }
	   
	else
	{
		ball.resetBallPosition();
		
    	}
    }

}
