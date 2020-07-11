using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dogelix;

public class GameManager : MonoBehaviour
{
    public TextAsset _levelData;

    private void Awake()
    {
        if(_levelData != null)
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
                    Vector3 location = new Vector3(float.Parse(splitPos[0]), float.Parse(splitPos[1]), float.Parse(splitPos[2]));

                    var splitRot = split[3].Split(new string[] { "," }, StringSplitOptions.None);
                    Vector3 rot = new Vector3(float.Parse(splitRot[0]), float.Parse(splitRot[1]), float.Parse(splitRot[2]));

                    if(blockType == EBlockType.Start || blockType == EBlockType.Goal )
                    {
                        Block.Create(blockType, new Vector3(location.x, 1, location.z), rot);
                    }
                    else
                    {
                        var t = Block.Create(blockType, location, rot);
                        t.GetComponent<Rigidbody>().useGravity = true;
                    }

                }
            }

            var start  = GameObject.FindObjectsOfType<Block>().First(e => e._type.EBlockType == EBlockType.Start);

            Instantiate(GameAssets.i.Player, start.transform.position, Quaternion.identity);
        }
        
    }

    private void LateUpdate()
    {
    }
}
