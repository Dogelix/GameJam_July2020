﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // To go to next Scene - Set nextLevel to true or just call LoadNextLevel
    private bool nextLevel;
    // Scene name
    Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        // Gets current scene name, sets as scene
        scene = SceneManager.GetActiveScene();
    }

    /// <summary>
    /// Loads next numerical scene
    /// </summary>
    public void LoadNextLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    /// <summary>
    /// Reloads scene by loading whatever scene name is in scene
    /// </summary>
    public void ReloadScene()
    {
        SceneManager.LoadScene(scene.name);
    }

    /// <summary>
    /// Loads the Main Menu. Usable from Pause Menu?
    /// Will need to set game timer back to 0, else maybe begin button does that?
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene("0_MainMenu");
    }

/// <summary>
/// Exits Application
/// </summary>
public void QuitGame ()
{
Debug.Log ("QUIT!");
Application.Quit();
}

}

