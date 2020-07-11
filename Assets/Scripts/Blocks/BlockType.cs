using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Block Type", menuName = "Block Type Data")]
public class BlockType : ScriptableObject
{
    public string Name;
    public EBlockType EBlockType;
    public Quaternion Rotation;
}

public enum EBlockType
{
    Rectangle,
    LShape,
    Cube,
    Start,
    Goal
}