using UnityEngine;
using System.Collections;

public class PipeOutHandler : MonoBehaviour {

	public GUIText scoreText;
	public GUIText highscoreText;

	static int score;
	static int highscore;
	static bool isActive;

	void Start () {
		score = 0;
		highscore = PlayerPrefs.GetInt ("highscore", 0);
		updateTexts();
		isActive = false;
	}

	void OnDestroy(){
		PlayerPrefs.SetInt ("highscore", highscore);
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (isActive && !BirdMovement.isDead()) {
			score++;
			if (score > highscore) {
				highscore = score;
			}
			updateTexts ();
			isActive = false;
		}
	}

	void updateTexts(){
		scoreText.text = "Score: " + score;
		highscoreText.text = "Highscore: " + highscore;
	}

	public static void activate(){
		isActive = true;
	}
}
