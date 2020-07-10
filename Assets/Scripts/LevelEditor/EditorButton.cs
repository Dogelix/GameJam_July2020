using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Dogelix.LevelEditor
{
    public class EditorButton : MonoBehaviour
    {
        public BlockType _blockType;

        private void Awake()
        {
            GetComponentInChildren<TextMeshProUGUI>().text = _blockType.Name;
        }

        public void ActivateButton()
        {
            FindObjectOfType<EditorMouse>()._selectedType = _blockType;
            GetComponent<Button>().Select();
        }
    }

}
