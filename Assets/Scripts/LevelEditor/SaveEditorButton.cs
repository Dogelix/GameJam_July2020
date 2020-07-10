using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Dogelix.LevelEditor
{
    public class SaveEditorButton : MonoBehaviour
    {
        public void SaveFormat()
        {
            var name = transform.parent.GetComponentInChildren<TMP_InputField>().text;
            Debug.Log(name);
        }
    }
}
