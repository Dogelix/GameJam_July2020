using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Win : MonoBehaviour
{
    // Calls timer
    Timer timer;

    // Calculates how long it took player to win the level
    private float winTime;

    // To convert winTime into minutes and seconds
    private string minutes;
    private string seconds;

    // Text Timer
    public GameObject textBox;

    // The UI display for winning the level
    public GameObject winUI;

    // Start is called before the first frame update
    void Start()
    {
        // timer gets components of Timer
        timer = GetComponent<Timer>();

        winUI = GameObject.FindGameObjectWithTag("WinUI");
    }

    // Update is called once per frame - Left just in case needed
    void Update()
    {
        
    }

    // When level has been won, can call this
    public void WinLevel()
    {
        
        winUI.GetComponent<Canvas>().enabled = true;              // Sets winUI in UI to active 
        timer.timerActive = false;          // Sets timerActive in Timer to false

        // Checks original time limit vs how much has been
        winTime = (timer.timeUp - timer.time);

        // Converts to minutes and seconds
        minutes = Mathf.Floor((winTime % 3600) / 60).ToString("00");
        seconds = (winTime % 60).ToString("00");

        // Displays in a text box specified in editor
        GameObject.Find("winText").GetComponent<TextMeshPro>().text = minutes + ":" + seconds;
    }
}
