using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float MovementSpeed = 2;
    public float JumpForce = 1;


    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        var upDown = Input.GetAxis("Vertical");


        transform.position += Vector3.right * MovementSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f) {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            _rigidbody.AddTorque(Mathf.Cos(MovementSpeed * Mathf.PI));
           
        }
        
    }
}
