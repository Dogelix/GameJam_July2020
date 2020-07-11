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
        paused = false;
        pausedGame = GetComponent<Timer>();
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager._i.GetKeyDown(KeybindingActions.Pause) > 0)
        {
            if (paused == false)
            {
                Paused();
            }
            else if (paused == true)
            {
                Play();
            }
        }
    }

    /// <summary>
    /// Paused check set to true, sets timer paused (which sets player false), pauseUI Displayed last.
    /// </summary>
    private void Paused()
    {
        paused = true;
        pausedGame.pauseCheck = true;
        pauseUI.SetActive(true);
    }

    /// <summary>
    /// Paused check set to false, PauseUI removed, timer resumed (which sets player true).
    /// </summary>
    private void Play()
    {
        paused = false;
        pauseUI.SetActive(false);
        pausedGame.pauseCheck = false;
    }
}
