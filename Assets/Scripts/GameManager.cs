using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextAsset _levelData;

    private void Awake()
    {
        string[] stringSeparators = new string[] { "\r\n" };
        string[] lines = _levelData.text.Split(stringSeparators, System.StringSplitOptions.None);

        foreach ( var line in lines )
        {
            if ( line.Contains(":") )
            {
                var split = line.Split(new string[] { ":" }, StringSplitOptions.None);
                EBlockType blockType = (EBlockType)Enum.Parse(typeof(EBlockType), split[1]);

                var splitPos = split[2].Split(new string[] { "," }, StringSplitOptions.None);
                Vector3 location = new Vector3(int.Parse(splitPos[0]), int.Parse(splitPos[1]), int.Parse(splitPos[2]));

                var splitRot = split[3].Split(new string[] { "," }, StringSplitOptions.None);
                Vector3 rot = new Vector3(int.Parse(splitRot[0]), int.Parse(splitRot[1]), int.Parse(splitRot[2]));

                Block.Create(blockType, location, rot);
            }
        }

        Debug.Log(_levelData.text);
    }

    private void LateUpdate()
    {
    }
}
