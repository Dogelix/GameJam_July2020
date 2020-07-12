using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{   
    // How long the timer is. Changeable in-editor. Set to -1 for no timer.
    public float time;
    // Text
    // private string hours; <- If needed in future
    private string minutes;
    private string seconds;

    // TODO : Time to complete game. Goes up -> Will need to sort out saving & loading between saves. Maybe better seperate script?
    private float timeGame;
    // Timer text (Displays the timer on a text box)
    public Text textBox;
    // Checks if the timer is active or not. Can set to false when 0.
    bool timerActive;

    // If game is paused, changes how game interacts with timer
    public bool pauseCheck;

    // Image and Text box to overwrite the player - Set in editor.
    public GameObject gameoverUI;
    // Player game object - Set in editor
    public GameObject playerObject;
    

    void Start()
    {

        // Set to work with Clone if not set in editor
        if (playerObject == null)
            playerObject = GameObject.FindGameObjectWithTag("Player");

        // Sets game to be playing when load up
        pauseCheck = false;

        // Error checking. Sets to 0f if nothing displayed
        timeGame += timeGame + 0.00f;
        // Timer active to be true beginning of level
        timerActive = true;

            // Hides game over image & text box
            gameoverUI.SetActive(false);
            // Makes player active
            playerObject.SetActive(true);
    }

    void Update()
    {
        // Checks if timer true, and timer is above 0
        if (timerActive == true && time >= 0 && pauseCheck == false)
        {
            // Enables player after pause
            if (playerObject.activeSelf == false) 
                playerObject.SetActive(true);

            // time ticks down
            time -= Time.deltaTime;

            // Calculates time. Put hours here in case we need it. 
            // hours = Mathf.Floor((time % 216000) / 3600).ToString("00");
            minutes = Mathf.Floor((time % 3600) / 60).ToString("00");
            seconds = (time % 60).ToString("00");
            
            textBox.text = minutes + ":" + seconds;
        }

        // If timer is not active (E.g. player dies), or time runs out AND game is not paused
        else if ((timerActive == false || time < 0) && pauseCheck == false)
        {
            // Stops timer
            timerActive = false;                                                                                // Stops Timer

            // Swaps Image & text in, and player out to stop input
            gameoverUI.SetActive(true);
            playerObject.SetActive(false);
        }

        // If there is still time on the clock/player alive AND the game is paused
        else if (timerActive == true && pauseCheck == true)
        {
            playerObject.SetActive(false);
            // Whilst game is paused, if unpaused, set playerObject to be true
            if (pauseCheck == false)
            {
                playerObject.SetActive(true);
            }
        }
    }
}
