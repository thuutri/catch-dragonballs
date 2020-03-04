using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Điều khiển game
public class GameController : MonoBehaviour
{

    private float epsilon = 1f;
    public Camera cam;
    private int level = 0;
    public GameObject ball;
    public GameObject heart;
    public GameObject boom;
    public GameObject energy;
    public GameObject shuriken;
    public GameObject genkiDama;
    private float maxWidth;
    public static float timeLeft;
    public Text timerText;
    public Text healthText;
    public GameObject gameOverText;
    public GameObject levelText;
    public GameObject restartButton;
    public GameObject splashScreen;
    public GameObject startButton;
    public GokuController gokuController;
    public GameObject Goku;
    public GameObject TutText;
    public GameObject TutButton;
    public GameObject HomeButton;
    public GameObject QuitButton;
    public GameObject warning;
    private bool playing;
    private bool bonus;
    private bool displayWarning = false;
    public int health;
    public float levelStartDelay = 2f;
    public int i, j, k, t, z, createBonus;
    public float tmp = timeLeft;


    void Start()
    {
        AudioControl.PlaySound(soundsGame.nhacnen);
        //Tương tự GokuController, ngăn không spawn ball khỏi màn hình
        if (cam == null) cam = Camera.main;
        playing = false;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth;
        UpdateText();
        UpdateHealthText();
        Goku.SetActive(false);
        TutText.SetActive(false);
        HomeButton.SetActive(false);
        levelText.SetActive(false);
        bonus = false;
    }

    void FixedUpdate()
    {
        //Giảm time (nếu đang chơi -> trừ time)
        if (playing)
        {
            timeLeft += Time.deltaTime;
            UpdateText();
        }
    }

    //Bắt đầu game
    public void StartGame()
    {
        //Tắt "Dragon Ball Z" + start button
        splashScreen.SetActive(false);
        startButton.SetActive(false);
        TutButton.SetActive(false);
        QuitButton.SetActive(false);
        Goku.SetActive(true);
        timeLeft = 0;
        UpdateText();
        //Spawn bóng
        StartCoroutine(Spawn());
    }

    //Điều khiển Tutorial button
    public void Tutorial()
    {
        splashScreen.SetActive(false);
        startButton.SetActive(false);
        TutButton.SetActive(false);
        Goku.SetActive(false);
        QuitButton.SetActive(false);
        TutText.SetActive(true);
        HomeButton.SetActive(true);
    }
    // Điều khiểu home button
    public void Home()
    {
        splashScreen.SetActive(true);
        startButton.SetActive(true);
        TutButton.SetActive(true);
        QuitButton.SetActive(true);
        Goku.SetActive(false);
        TutText.SetActive(false);
        HomeButton.SetActive(false);
    }

    public void quitbutton()
    {
        Application.Quit();
    }
    //Routine bơm bóng
    IEnumerator Spawn()
    {
        //Đợi 1 s
        yield return new WaitForSeconds(1.0f);
        //Set playing = true -> time giảm
        playing = true;
        //Trong lúc còn health
        while (health > 0)
        {
            Quaternion spawnRotation = Quaternion.identity;
            Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0.0f);
            if (!bonus) Instantiate(ball, spawnPosition, spawnRotation);

            if (timeLeft > 5 && timeLeft <= 10)
            {
                //In level ra màn hình
                if (timeLeft - 5 < epsilon)
                {
                    level++;
                    levelText.GetComponent<Text>().text = "Level " + level;
                    levelText.SetActive(true);
                    yield return new WaitForSeconds(2.0f);
                    levelText.SetActive(false);
                }
                //Vector position sinh ra heart
                Vector3 spawnPosition1 = new Vector3(Random.Range(-maxWidth + 0.8f, maxWidth - 0.8f), transform.position.y, 0.0f);
                //Vector position sinh ra boom
                Vector3 spawnPosition2 = new Vector3(Random.Range(-maxWidth + 0.8f, maxWidth - 0.8f), transform.position.y, 0.0f);

                //Spawn heart chỉ khi i=0
                i = Random.Range(0, 5);
                //Spawn boom chỉ khi j=0
                j = Random.Range(0, 2);
                if (i == 0)
                {
                    yield return new WaitForSeconds(Random.Range(0.7f, 1.5f));
                    Instantiate(heart, spawnPosition1, spawnRotation);
                }
                if (j == 0)
                {
                    yield return new WaitForSeconds(Random.Range(0.8f, 1.2f));
                    Instantiate(boom, spawnPosition2, spawnRotation);
                }
            }
            if (timeLeft > 10 && timeLeft <= 30)
            {
                //In level ra màn hình
                if (timeLeft - 10 < epsilon)
                {
                    level++;
                    levelText.GetComponent<Text>().text = "Level " + level;
                    levelText.SetActive(true);
                    yield return new WaitForSeconds(2.0f);
                    levelText.SetActive(false);
                }
                //i, j, k vai trò như đoạn trên
                i = Random.Range(0, 5);
                j = Random.Range(0, 2);
                k = Random.Range(0, 3);
                //Vector position sinh ra heart
                Vector3 spawnPosition1 = new Vector3(Random.Range(-maxWidth + 0.8f, maxWidth - 0.8f), transform.position.y, 0.0f);
                //Vector position sinh ra boom
                Vector3 spawnPosition2 = new Vector3(Random.Range(-maxWidth + 0.8f, maxWidth - 0.8f), transform.position.y, 0.0f);
                //Vector position sinh ra energy
                Vector3 spawnPosition3 = new Vector3(Random.Range(-maxWidth + 0.8f, maxWidth - 0.8f), transform.position.y, 0.0f);
           
                if (i == 0)
                {
                    yield return new WaitForSeconds(Random.Range(0.7f, 1.5f));
                    Instantiate(heart, spawnPosition1, spawnRotation);
                }
                if (j == 0)
                {
                    yield return new WaitForSeconds(Random.Range(0.8f, 1.2f));
                    Instantiate(boom, spawnPosition2, spawnRotation);
                }
                if (k == 0)
                {
                    yield return new WaitForSeconds(Random.Range(0.8f, 1.2f));
                    Instantiate(energy, spawnPosition3, spawnRotation);
                }
            }

            if (timeLeft > 30 && timeLeft <= 50)
            {
                //In level ra màn hình
                if (timeLeft - 30 < epsilon)
                {
                    level++;
                    levelText.GetComponent<Text>().text = "Level " + level;
                    levelText.SetActive(true);
                    yield return new WaitForSeconds(2.0f);
                    levelText.SetActive(false);
                }
                //Vector position sinh ra heart
                Vector3 spawnPosition1 = new Vector3(Random.Range(-maxWidth + 0.8f, maxWidth - 0.8f), transform.position.y, 0.0f);
                //Vector position sinh ra boom
                Vector3 spawnPosition2 = new Vector3(Random.Range(-maxWidth + 0.8f, maxWidth - 0.8f), transform.position.y, 0.0f);
                //Vector position sinh ra energy
                Vector3 spawnPosition3 = new Vector3(Random.Range(-maxWidth + 0.8f, maxWidth - 0.8f), transform.position.y, 0.0f);
                //Vector position sinh ra shuriken
                Vector3 spawnPosition4 = new Vector3(Random.Range(-maxWidth + 0.8f, maxWidth - 0.8f), transform.position.y, 0.0f);
                
                i = Random.Range(0, 5);
                j = Random.Range(0, 2);
                k = Random.Range(0, 3);
                t = Random.Range(0, 4);

                if (i == 0)
                {
                    yield return new WaitForSeconds(Random.Range(0.7f, 1.5f));
                    Instantiate(heart, spawnPosition1, spawnRotation);
                }
                if (j == 0)
                {
                    yield return new WaitForSeconds(Random.Range(0.8f, 1.2f));
                    Instantiate(boom, spawnPosition2, spawnRotation);
                }
                if (k == 0)
                {
                    yield return new WaitForSeconds(Random.Range(0.8f, 1.2f));
                    Instantiate(energy, spawnPosition3, spawnRotation);
                }
                if (t == 0)
                {
                    yield return new WaitForSeconds(Random.Range(0.8f, 1.2f));
                    Instantiate(shuriken, spawnPosition4, spawnRotation);
                }
            }

            if (timeLeft > 50)
            {
                //In level ra màn hình
                if (timeLeft - 50 < epsilon)
                {
                    level++;
                    levelText.GetComponent<Text>().text = "Level " + level +"\nGood luck";
                    levelText.SetActive(true);
                    yield return new WaitForSeconds(2.0f);
                    levelText.SetActive(false);
                }
                //Vector position sinh ra heart
                Vector3 spawnPosition1 = new Vector3(Random.Range(-maxWidth + 0.8f, maxWidth - 0.8f), transform.position.y, 0.0f);
                //Vector position sinh ra boom
                Vector3 spawnPosition2 = new Vector3(Random.Range(-maxWidth + 0.8f, maxWidth - 0.8f), transform.position.y, 0.0f);
                //Vector position sinh ra energy
                Vector3 spawnPosition3 = new Vector3(Random.Range(-maxWidth + 0.8f, maxWidth - 0.8f), transform.position.y, 0.0f);
                //Vector position sinh ra shuriken
                Vector3 spawnPosition4 = new Vector3(Random.Range(-maxWidth + 0.8f, maxWidth - 0.8f), transform.position.y, 0.0f);
                i = Random.Range(0, 5);
                j = Random.Range(0, 2);
                k = Random.Range(0, 3);
                t = Random.Range(0, 4);
                z = Random.Range(0, 6);
                if (bonus==false) createBonus = Random.Range(0, 10);
                if (createBonus==0&&!bonus)
                {
                    //In warning
                    if (!displayWarning)
                    {
                        for (int index = 0; index < 5; index++)
                        {
                            warning.SetActive(true);
                            yield return new WaitForSeconds(0.1f);
                            warning.SetActive(false);
                            yield return new WaitForSeconds(0.1f);
                        }
                        displayWarning = true;
                        tmp = timeLeft;
                    }
                    //Khẳng định đang trong khoảng bonus
                    bonus = true;
                }
                //Sau 10 s tắt bonus
                if (timeLeft-tmp>=10)
                {
                    bonus = false;
                    displayWarning = false;
                    tmp = timeLeft;
                }
                if (bonus)
                {
                    i = 1;
                    j = k = t = z = 0;
                }
                else
                {
                    i = Random.Range(0, 5);
                    j = Random.Range(0, 2);
                    k = Random.Range(0, 3);
                    t = Random.Range(0, 4);
                    z = Random.Range(0, 10);
                }

                if (i == 0)
                {
                    yield return new WaitForSeconds(Random.Range(0.7f, 1.5f));
                    Instantiate(heart, spawnPosition1, spawnRotation);
                }
                if (j == 0)
                {
                    if (!bonus) yield return new WaitForSeconds(Random.Range(0.8f, 1.2f));
                    Instantiate(boom, spawnPosition2, spawnRotation);
                }
                if (k == 0)
                {
                    if (!bonus) yield return new WaitForSeconds(Random.Range(0.8f, 1.2f));
                    Instantiate(energy, spawnPosition3, spawnRotation);
                }
                if (t == 0)
                {
                    if (!bonus) yield return new WaitForSeconds(Random.Range(0.8f, 1.2f));
                    Instantiate(shuriken, spawnPosition4, spawnRotation);
                }
                if (z == 0)
                {
                    if (!bonus) yield return new WaitForSeconds(Random.Range(0.8f, 1.2f));
                    Instantiate(genkiDama, spawnPosition4, spawnRotation);
                }

            }
            yield return new WaitForSeconds(Random.Range(0.5f, 1.2f));
        }

        //Bật text GameOver + button restart + quit button và chỉnh bonus lại false khi hết game
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        QuitButton.SetActive(true);
        bonus = false;
    }

    //In time lên màn hình
    public void UpdateText()
    {
        if (health > 0)
            timerText.text = "Time:\n" + Mathf.RoundToInt(timeLeft);
    }
    //In health lên màn hình
    public void UpdateHealthText()
    {
        healthText.text = "Health:\n" + Mathf.RoundToInt(health);
    }

}
