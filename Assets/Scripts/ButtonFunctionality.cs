using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctionality : MonoBehaviour
{
    private void Start()
    {
        var t = FindObjectOfType<MusicClass>();
        
        if(t != null )
        {
            Destroy(t.gameObject);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
