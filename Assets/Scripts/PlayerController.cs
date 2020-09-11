using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0;
    public TextMeshProUGUI countText;
    private Rigidbody rigB;
    private float moveX, moveY;
    private int count;


    void Start()
    {
        rigB = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text += count.ToString();
    }
}
