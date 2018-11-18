using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public int PlayerLives = 3;
    public int Bricks = 20;
    public float DelayReset = 1f;
    public Text livesText;
    public GameObject GameOver;
    public GameObject PlayerWin;
    public GameObject bricksPrefab;
    public GameObject Paddle;
    public GameObject death;
    public static GM instance = null;

    private GameObject clonePaddle;

    // Use this for initialization
    void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Setup();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }
    #region Game Setup
    public void Setup()
    {
        clonePaddle = Instantiate(Paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }
    #endregion

    #region Game Over
    void CheckGameOver()
    {
        if (Bricks < 1)
        {
            PlayerWin.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", DelayReset);
        }

        if (PlayerLives < 1)
        {
            GameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", DelayReset);
        }
    }
    #endregion
    #region Game Reset
    void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion

    #region Lives
    public void LoseLives()
    {
        PlayerLives--;
        livesText.text = "Lives: " + PlayerLives;
        Instantiate(death, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", DelayReset);
        CheckGameOver();
    }
    #endregion
    #region Paddle Setup
    void PaddleSetup()
    {
        clonePaddle = Instantiate(Paddle, transform.position, Quaternion.identity) as GameObject;
    }
    #endregion

    #region Destroy Bricks
    public void BrickDestroy()
    {
        Bricks--;
        CheckGameOver();
    }
    #endregion
}
