using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    NextScene nextScene;

    private void Start()
    {
        nextScene = GetComponent<NextScene>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("CollisionSuccessful");
            nextScene.LoadNextLevel();
        }
            
    }
}
