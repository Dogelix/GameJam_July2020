using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // TODO - Check if pause was called
    private bool paused;
    // TODO - Set timer to false > Timer handles player. If paused, will set to false there, and true when unpaused
    Timer pausedGame;
    // TODO - Set Pause UI Menu to true
    public GameObject pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        pauseUI = GameObject.FindGameObjectWithTag("PauseUI");
        paused = false;
        pausedGame = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks input manager input. If input for pause is pressed, do this
        if (InputManager._i.GetKeyDown(KeybindingActions.Pause) > 0)
        {
            // Checks if paused or not. Can be improved to just a toggle
            if (paused == false)
                Paused();

            else if (paused == true)
                Play();
        }
    }

    /// <summary>
    /// Paused check set to true, sets timer paused (which sets player false), pauseUI Displayed last.
    /// </summary>
    private void Paused()
    {
        paused = true;
        pausedGame.pauseCheck = true;
        pauseUI.GetComponent<Canvas>().enabled = true;
    }

    /// <summary>
    /// Paused check set to false, PauseUI removed, timer resumed (which sets player true).
    /// </summary>
    private void Play()
    {
        paused = false;
        pauseUI.GetComponent<Canvas>().enabled = false;
        pausedGame.pauseCheck = false;
    }
}
