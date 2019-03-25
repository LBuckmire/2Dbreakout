using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// This is the code which will be used for the GM (Game Manager) class
/// The game manager will cover fucntions such as Score, Total Score, Scene Management and the start and end of the game
/// </summary>
public class GM : MonoBehaviour
{



    // publicly declared variables
    #region New GM variables
    public GameObject mainMenuPanel;        // This connects to the GameObject we are using as the main menu panel
    public Text txtScore;                   // A text variable used to display the score in the game
    public int Totalscore;                  // An integer used to keep track of the total accumulated score
    public string loadScene;                // A string used to denote which scene to load
    public static bool startGame = false;   // A true or false statement (boolean) about whether the game has started or not
    public static bool gameOver = false;    // A true or false statement (boolean) about whether the game has finished or not
    [HideInInspector] public static GM sGM; // The static Game Manager  
    #endregion

    void Awake()
    {
        Time.timeScale = 0;     // Sets the timescale so that when the game wakes it is paused until activated

        // Sets the condition that the if the Game Manager is referenced
        if (sGM == null)
        {     
            sGM = this;     // The Game Manager has been referenced in an instance
        }

        // Sets the condition that if the Game Manager referenced in first instance then the actions in the statement below are to be taken
        else if (sGM != this)
        {  
            Destroy(gameObject);    // Destroy any Game Manager that isn't the original from the first instance (Duplicate)
        }
        

    }


    // Update is called once per frame
    void Update()
    {
        Physics2D.gravity = new Vector2(0, -0.001f);    // We have set the gravity in the game on the X and Y axis

        // Score Text
        txtScore.text = "Score:" + Totalscore;       // Int value takes over Text. Whatever int value is displays on Text
       
        // If the game hasn't started and the Jump (Space Bar) has been pressed then the statement will be activated
        if (Input.GetButtonDown("Jump") && startGame == false)
        {
            Time.timeScale = 1;         // The time scale is set to 1 and the game runs in realtime
            startGame = true;	        // the game will start the game
            // Find the main menu again cause it will have lost reference.
            mainMenuPanel.SetActive(false);		// it will turn off the main menu panel
            
        }

        // If the game has ended and the Jump (Space Bar) has been pressed then the statement will be activated
        if (Input.GetButtonDown("Jump") && gameOver == true)
        {
            startGame = false;      // The game resets to its state before the game was started
            gameOver = false;		// Then the game over goes back to being false 
            mainMenuPanel.SetActive(true);  // The gameobject linked to mainMenuPanel is active
            SceneManager.LoadScene(loadScene);  // followed by the scene manager loading the chosen scene	
            
        }

    }
 
    void Score_Points(int AddPoints)   // A function used to keep track of points aquired (Points receiver)
    {
        Totalscore += AddPoints; // Points collected will be added to the total score
    }

    #region Score collision
    void OnCollisionEnter2D(Collision2D BallColl)   // A function for declaring collision detection once an object has entered a collision
    {
        // Set a condition that if the objects involved in the collision are tagged "Ball" & "Brick", then the statement will be activated
        if (BallColl.gameObject.tag == "Ball" && BallColl.gameObject.tag == "Brick")
        {
            BallColl.gameObject.GetComponent<Brick>().score += Totalscore; // It gets the score from the brick and adds it to the total score
            txtScore.text = Totalscore.ToString("000000"); // The score will be displayed on the text object named txtScore and displayed as a string of numbers
            Destroy(GameObject.FindGameObjectWithTag("Brick")); // Any gameobject tagged "Brick" will be destroyed
        }
    }


    #endregion
    

    
}