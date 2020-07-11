using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetection : MonoBehaviour
{
    private void OnTriggerEnter( Collider collision )
    {
        if(collision.tag == "Player" )
        {
            GameObject.FindGameObjectWithTag("GameOverCanvas").GetComponent<Canvas>().enabled = true;
            Debug.Log("Win");
        }
    }
}
