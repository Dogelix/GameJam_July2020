using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dogelix.LevelEditor
{
    public class ImmovableButton : MonoBehaviour
    {
        public void Selected()
        {
            FindObjectOfType<EditorMouse>()._immovableSelected = true;
        }
    }
}
