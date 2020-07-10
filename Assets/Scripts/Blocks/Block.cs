using Dogelix;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public BlockType _type;

    public static void Create(BlockType type, Vector3 location )
    {
        Transform resultantGO;
        switch ( type.EBlockType )
        {
            case EBlockType.Rectangle:
                resultantGO = Instantiate(GameAssets.i.RBlock, location, Quaternion.Euler(0, type.Rotation.y, 0));
                break;
            case EBlockType.LShape:
                resultantGO = Instantiate(GameAssets.i.LBlock, location, Quaternion.Euler(0, type.Rotation.y, 0));
                break;
            case EBlockType.Cube:
                resultantGO = Instantiate(GameAssets.i.Block, location, type.Rotation);
                break;
            default:
                throw new System.Exception("No EBlockType assigned");
        }

        resultantGO.GetComponent<Block>()._type = type;
    }
}
