
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager _i;
    public KeybindingData _keybindings;

    public void Awake()
    {
        if ( _i == null )
            _i = this;
        else
            Destroy(this);

        //DontDestroyOnLoad(this);
    }

    /// <summary>
    /// Get both keycodes for an action
    /// </summary>
    /// <param name="keybindingAction">Action Keys for</param>
    /// <returns>Size 2 Array of Type KeyCode</returns>
    public KeyCode[] GetKeyCodeByAction( KeybindingActions keybindingAction )
    {
        var keybind = _keybindings.Keybindings.FirstOrDefault(e => e.Action == keybindingAction);
        return new KeyCode[2] { keybind.PositiveKeyCode, keybind.NegativeKeyCode };
    }

    /// <summary>
    /// Get an int based on the key down
    /// </summary>
    /// <param name="keyCode">Action</param>
    /// <returns>-1 (-ve Key) - 0 (not pressed) - 1 (+ve Key)</returns>
    public int GetKeyDown( KeybindingActions keyCode )
    {
        if ( Input.GetKeyDown(_keybindings.Keybindings.FirstOrDefault(e => e.Action == keyCode).PositiveKeyCode) )
        {
            return 1;
        }
        else if ( Input.GetKeyDown(_keybindings.Keybindings.FirstOrDefault(e => e.Action == keyCode).NegativeKeyCode) )
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// Get an int based on the key up
    /// </summary>
    /// <param name="keyCode">Action</param>
    /// <returns>-1 (-ve Key) - 0 (not pressed) - 1 (+ve Key)</returns>
    public int GetKeyUp( KeybindingActions keyCode )
    {
        if ( Input.GetKeyUp(_keybindings.Keybindings.FirstOrDefault(e => e.Action == keyCode).PositiveKeyCode) )
        {
            return 1;
        }
        else if ( Input.GetKeyUp(_keybindings.Keybindings.FirstOrDefault(e => e.Action == keyCode).NegativeKeyCode) )
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// Get an int based on the key pressed
    /// </summary>
    /// <param name="keyCode">Action</param>
    /// <returns>-1 (-ve Key) - 0 (not pressed) - 1 (+ve Key)</returns>
    public int GetKey( KeybindingActions keyCode )
    {
        if ( Input.GetKey(_keybindings.Keybindings.FirstOrDefault(e => e.Action == keyCode).PositiveKeyCode) )
        {
            return 1;
        }
        else if ( Input.GetKey(_keybindings.Keybindings.FirstOrDefault(e => e.Action == keyCode).NegativeKeyCode) )
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}