using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnContact : MonoBehaviour {
    public GameController GameControl;
    public Text scoreText;
    public static int ballValue = 1;
    public int score = 0;
    public Text highscoreText;
    public int highscore;
    void Awake()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        highscoreText.text = "High Score:\n" + highscore;
    }

    //Setup score
    void Start()
    {
        //Initialize to 0
        //Print score onto the screen
        UpdateScore();
    }

    //Điều điểm khi va chạm
    void OnCollisionEnter2D(Collision2D other)
    {
        //tăng điểm khi ăn bóng
        if (other.gameObject.tag == "Ball")
        {
            //Nếu va chạm với banh -> xóa banh
            Destroy(other.gameObject);
            AudioControl.PlaySound(soundsGame.ball);
            score += 1;
            UpdateScore();
        }
        //tăng điểm và mạng khi ăn heart
        else if (other.gameObject.tag == "Heart")
        {
            //Nếu va chạm với banh -> xóa banh
            Destroy(other.gameObject);
            AudioControl.PlaySound(soundsGame.heart);
            if(GameControl.health>0)
             GameControl.health++;
            score++;
            GameControl.UpdateHealthText();
        }
        //giảm điểm và mạng khi ăn boom
        else if (other.gameObject.tag == "Boom")
        {
            //Nếu va chạm với boom -> xóa boom
            Destroy(other.gameObject);
            AudioControl.PlaySound(soundsGame.boom);
            if (GameControl.health>0)
             GameControl.health--;
            score--;
            if (score < 0) score = 0;
            if (GameControl.health < 0) GameControl.health = 0;
            GameControl.UpdateHealthText();
            UpdateScore();
        }
        //giảm điểm và mạng khi ăn shuriken
        else if (other.gameObject.tag == "Shuriken")
        {
            //Nếu va chạm với shuriken -> xóa shuriken
            Destroy(other.gameObject);
            AudioControl.PlaySound(soundsGame.boom);
            if (GameControl.health > 0)
                GameControl.health-=2;
            score-=2;
            if (score < 0) score = 0;
            if (GameControl.health < 0) GameControl.health = 0;
            GameControl.UpdateHealthText();
            UpdateScore();
        }
        //giảm điểm và mạng khi ăn energy
        else if (other.gameObject.tag == "Energy")
        {
            //Nếu va chạm với energy -> xóa banh
            Destroy(other.gameObject);
            AudioControl.PlaySound(soundsGame.boom);
            if (GameControl.health > 0)
                GameControl.health-=3;
            score-=3;
            if (score < 0) score = 0;
            if (GameControl.health < 0) GameControl.health = 0;
            GameControl.UpdateHealthText();
            UpdateScore();
        }
        //giảm điểm và mạng khi ăn GenkiDama
        else if (other.gameObject.tag == "GenkiDama")
        {
            //Nếu va chạm với GenkiDama -> xóa GenkiDama
            Destroy(other.gameObject);
            AudioControl.PlaySound(soundsGame.boom);
            if (GameControl.health > 0)
                GameControl.health -= 20;
            score -= 20;
            if (score < 0) score = 0;
            if (GameControl.health < 0) GameControl.health = 0;
            GameControl.UpdateHealthText();
            UpdateScore();
        }
    }
    //cập nhật điểm
    public void UpdateScore()
    {
        scoreText.text = "Score:\n" + score;
    }

    //Cập nhật high score
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
