using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector2 _currentInput;

    private void StoreCurrentInput()
    {
        StoreInput(KeyCode.UpArrow, Vector2.up);
        StoreInput(KeyCode.DownArrow, Vector2.down);
        StoreInput(KeyCode.LeftArrow, Vector2.left);
        StoreInput(KeyCode.RightArrow, Vector2.right);
    }

    private void StoreInput(KeyCode key, Vector2 direction)
    {
        bool keyUp = Input.GetKeyUp(key);
        bool keyDown = Input.GetKeyDown(key);

        if (keyDown == true)
            _currentInput += direction;
        
        if (keyUp == true)
            _currentInput -= direction;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUILayout.Label(text: $"Current Input: { _currentInput}");
    }
}
