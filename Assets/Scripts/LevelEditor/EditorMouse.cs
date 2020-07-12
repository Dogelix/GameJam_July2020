using Dogelix;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Dogelix.LevelEditor
{
    public class EditorMouse : MonoBehaviour
    {
        public BlockType _selectedType;
        public bool _immovableSelected = false;
        public string[] _maskNames;

        private void Awake()
        {
        
        }

        private void FixedUpdate()
        {
            if( InputManager._i.GetKeyDown(KeybindingActions.Interact) > 0 )
            {
                PlaceBlock();
            }
        }

        private void PlaceBlock()
        {
            if(_selectedType != null)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if ( _immovableSelected )
                {
                    int combinedMask = LayerMask.GetMask(_maskNames[0]);

                    if ( Physics.Raycast(ray, out hit) )
                    {
                        Debug.Log(hit.collider.name);

                        if ( hit.collider.GetComponent<Block>() == null )
                        {
                            return;
                        }
                        else
                        {
                            hit.collider.GetComponent<Block>()._canMove = false;
                            Debug.Log("Set immovable");
                        }

                        _selectedType = null;
                        _immovableSelected = false;

                        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
                    }
                }
                else
                {
                    int combinedMask = LayerMask.GetMask(_maskNames);

                    if ( Physics.Raycast(ray, out hit, Mathf.Infinity, combinedMask) )
                    {
                        Debug.Log(hit.collider.name);

                        if ( hit.collider.GetComponent<Block>() != null )
                        {
                            return;
                        }

                        var postition = hit.collider.transform.position + Vector3.up;

                        Block.Create(_selectedType, postition);
                        _selectedType = null;

                        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
                    }
                }
               
            }
        }
    }

}


//Physics.Raycast(raycast, out hit, range, 1 << LayerMask.NameToLayer("Walkable"))