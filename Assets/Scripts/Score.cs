using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Display score

public class Score : MonoBehaviour {

    public GameController GameControl;
    public Text scoreText;
    public static int ballValue=1;
    public int score=0;

    public Text highscoreText;
    static int highscore;

    private void Awake()
    {
        highscore = PlayerPrefs.GetInt("highscoree");
        highscoreText.text = "HighScore:\n" + highscore;
    }

    //Setup score
    void Start ()
    {
        //Initialize to 0
        //Print score onto the screen
        UpdateScore();
	}

    //Tăng điểm khi ăn bóng
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            score += 1;
            UpdateScore();
        }
        else if(other.gameObject.tag=="Heart")
        {
            GameControl.health++;
            score++;
            GameControl.UpdateText();
        }
        else if(other.gameObject.tag =="Boom")
        {
            GameControl.health--;
            score--;
            GameControl.UpdateText();
        }
        else if (other.gameObject.tag == "Shuriken")
        {
            GameControl.health-=2;
            score-=2;
            GameControl.UpdateText();
        }
        else if (other.gameObject.tag == "Energy")
        {
            GameControl.health-=3;
            score-=3;
            GameControl.UpdateText();
        }
        else if (other.gameObject.tag == "GenkiDama")
        {
            GameControl.health-=20;
            score-=20;
            GameControl.UpdateText();
        }
    }

    //Xuất score hiện tại lên màn hình
    void UpdateScore()
    {
        scoreText.text = "Score:\n" + score;
    }

    private void Update()
    {
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
            highscoreText.text = "Highscore:\n" + highscore;
        }
    }
}
