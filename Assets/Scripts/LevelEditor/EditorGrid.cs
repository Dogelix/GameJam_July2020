using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dogelix.LevelEditor
{
    public class EditorGrid : MonoBehaviour
    {
        public Size _size;


        private void Start()
        {
            CreateGrid();
        }

        public void CreateGrid()
        {
            GameObject newEmptyGameObject = new GameObject("Grid");
            // following line is probably not neccessary
            newEmptyGameObject.transform.position = Vector3.zero;

            // some math to find the most left and bottom offset
            float offsetLeft = (-_size.Width/2f)*_size.DistanceX + _size.DistanceX/2f;
            float offsetBottom = (-_size.Length/2f)*_size.DistanceY + _size.DistanceY/2f;
            // set it as first spawn position (z=1 because you had it in your script)
            Vector3 nextPosition = new Vector3(offsetLeft, 0f, offsetBottom);
            

            for ( int y = 0; y < _size.Length; y++ )
            {
                for ( int x = 0; x < _size.Width; x++ )
                {
                    GameObject clone = Instantiate(GameAssets.i.TestCube.gameObject, nextPosition, Quaternion.identity) as GameObject;
                    clone.transform.parent = newEmptyGameObject.transform;
                    clone.name = String.Format("Q{0}{1}", x, y);
                    // add x distance
                    nextPosition.x += _size.DistanceX;
                }
                // reset x position and add y distance
                nextPosition.x = offsetLeft;
                nextPosition.z += _size.DistanceY;
                //Debug.Log(nextPosition);
            }
        }
    }

    [System.Serializable]
    public class Size
    {
        public int Width;
        public int Length;
        public float DistanceX;
        public float DistanceY;
    }
}
