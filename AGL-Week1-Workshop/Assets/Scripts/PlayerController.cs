using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private GroundChecker groundChecker;
    [SerializeField] private float jumpSpeed = 1f;
    [SerializeField] private float gravity = 9.8f;

    private Vector2 _currentInput;
    private Vector3 _currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StoreCurrentInput();
        MoveWithInput();

        ApplyGravity();

        if (Input.GetKeyDown(KeyCode.Space))
            TrytoJump();

        playerRigidBody.velocity = _currentVelocity;
    }

    private void ApplyGravity()
    {
        if (groundChecker.IsGrounded == false)
            _currentVelocity.y -= gravity * Time.deltaTime;
    }

    private void TrytoJump()
    {
        if (groundChecker.IsGrounded)
            _currentVelocity.y = jumpSpeed;
    }

    private void MoveWithInput()
    {
        _currentVelocity.x = _currentInput.x * movementSpeed;

        
    }

    private void StoreCurrentInput()
    {
        _currentInput.x = Input.GetAxisRaw("Horizontal");

        _currentInput.Normalize();
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

    private void OnGUI()
    {
        GUILayout.Label(text: $"Current Input: { _currentInput}");
        GUILayout.Label(text: $"Current Speed: {playerRigidBody.velocity.magnitude}");
        GUILayout.Label(text: $"Is Grounded: {groundChecker.IsGrounded}");
        GUILayout.Label(text: $"Velocity: {playerRigidBody.velocity}");
    }
}
