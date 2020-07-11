using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEditor;

namespace Dogelix.LevelEditor
{
    public class SaveEditorButton : MonoBehaviour
    {
        public void SaveFormat()
        {
            var name = transform.parent.GetComponentInChildren<TMP_InputField>().text;

            string path = "Assets/Levels/" + name + ".lvl";
            GameObject[] blockObjects = FindObjectsOfType<Block>().Select(e => e.gameObject).ToArray();

            //foreach ( var item in blockObjects )
            //{
            //    Debug.Log(item.name);
            //}
            EditorGrid grid = FindObjectOfType<EditorGrid>();

            using ( StreamWriter sw = new StreamWriter(path) )
            {
                // some math to find the most left and bottom offset
                float offsetLeft = (-grid._size.Width/2f)*grid._size.DistanceX + grid._size.DistanceX/2f;
                float offsetBottom = (-grid._size.Length/2f)*grid._size.DistanceY + grid._size.DistanceY/2f;

                // set it as first spawn position (z=1 because you had it in your script)
                Vector3 nextPosition = new Vector3(offsetLeft, 0f, offsetBottom);

                string dataToWrite = "";

                for ( int y = 0; y < grid._size.Length; y++ )
                {
                    for ( int x = 0; x < grid._size.Width; x++ )
                    {
                        dataToWrite = x.ToString() + y.ToString();

                        if(blockObjects.FirstOrDefault(e => e.transform.position == ( nextPosition + Vector3.up )) != null )
                        {
                            var blockData = blockObjects.First(e => e.transform.position == ( nextPosition + Vector3.up ));
                            var b = blockData.GetComponent<Block>();
                            dataToWrite += "-" + b._type.EBlockType.ToString() + String.Format("-{0},{1},{2}", blockData.transform.rotation.eulerAngles.x, blockData.transform.rotation.eulerAngles.y, blockData.transform.rotation.eulerAngles.z);
                        }

                        sw.WriteLine(dataToWrite);

                        // add x distance
                        nextPosition.x += grid._size.DistanceX;
                    }
                    // reset x position and add y distance
                    nextPosition.x = offsetLeft;
                    nextPosition.z += grid._size.DistanceY;
                    //Debug.Log(nextPosition);
                }
            }

            AssetDatabase.ImportAsset(path);
        }
    }
}
