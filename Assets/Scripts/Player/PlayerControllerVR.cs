using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]

public class PlayerControllerVR : MonoBehaviour
{
    [SerializeField] private InputActionReference JumpActionReference;
    [SerializeField] private float JumpHeight = 200.0f;

    private Rigidbody _body;

    private bool IsGrounded => Physics.Raycast(
        new Vector2(transform.position.x, transform.position.y + 2.0f),
        Vector3.down, 2.0f);

    // Start is called before the first frame update
    void Start()
    {
        JumpActionReference.asset.Enable();
        _body = GetComponent<Rigidbody>();
        JumpActionReference.action.performed += OnJump;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        if (!IsGrounded) return;
        Debug.Log("JUMPING");
        _body.AddForce(Vector3.up * JumpHeight);
    }
}
