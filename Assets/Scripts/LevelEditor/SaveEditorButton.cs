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

            string path = "Assets/Levels/" + name + ".lvl.txt";
            GameObject[] blockObjects = FindObjectsOfType<Block>().Select(e => e.gameObject).ToArray();

            //foreach ( var item in blockObjects )
            //{
            //    Debug.Log(item.name);
            //}
            //EditorGrid grid = FindObjectOfType<EditorGrid>();

            using ( StreamWriter sw = new StreamWriter(path) )
            {
                foreach ( var block in blockObjects )
                {
                    string dataToWrite = "block";

                    var b = block.GetComponent<Block>();
                    dataToWrite += ":" + b._type.EBlockType.ToString() + String.Format(":{0},{1},{2}", block.transform.position.x, block.transform.position.y, block.transform.position.z) +
                        String.Format(":{0},{1},{2}", block.transform.rotation.eulerAngles.x, block.transform.rotation.eulerAngles.y, block.transform.rotation.eulerAngles.z);
                    sw.WriteLine(dataToWrite);
                }
            }

            AssetDatabase.ImportAsset(path);
        }
    }
}
