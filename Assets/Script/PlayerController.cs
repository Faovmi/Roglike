using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    private Vector3 _moveVectore;
    private float _fallVelocity = 0;

    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _moveVectore = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVectore += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVectore -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVectore += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVectore -= transform.right;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }

    }
    // Update is called once per frame
    void  FixedUpdate()
    {
        _characterController.Move(_moveVectore * speed * Time.fixedDeltaTime);

        _fallVelocity += gravity * Time.deltaTime;
        GetComponent<CharacterController>().Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if(_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}