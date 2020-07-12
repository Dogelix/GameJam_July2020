using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetection : MonoBehaviour
{
    // Uses Next Scene in Game Manager
    private NextScene nextScene;

    // nextScene finds gamemanager and gets NextScene script from it
    private void Start()
    {
        nextScene = GameObject.FindGameObjectWithTag("GameManager").GetComponent<NextScene>();
    }

    private void OnTriggerEnter( Collider collision )
    {
        if(collision.tag == "Player" )
        {
            GameObject.FindGameObjectWithTag("GameOverCanvas").GetComponent<Canvas>().enabled = true;
            Debug.Log("Win");

            // Loads next scene in numerical order
            nextScene.LoadNextLevel();
        }
    }
}
