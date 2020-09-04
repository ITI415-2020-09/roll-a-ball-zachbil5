using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0;
    private Rigidbody rigB;
    private float moveX, moveY;

    void Start()
    {
        rigB = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue inputVal)
    {
        Vector2 movementVec = inputVal.Get<Vector2>();
        moveX = movementVec.x;
        moveY = movementVec.y;
    }

    void FixedUpdate()
    {
        rigB.AddForce(new Vector3(moveX, 0.0f, moveY) * speed);
    }
}
