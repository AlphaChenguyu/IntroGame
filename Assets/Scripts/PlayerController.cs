using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
using System;


public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;

    public float speed;
    private int count;
    private int numPickups = 3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI playerPosition;
    public TextMeshProUGUI playerVelocity;
    private Rigidbody rb;
    private float moveSpeed;

    void Start()
    {
        count = 0 ;
        winText.text = "";
        SetCountText();
        rb = GetComponent<Rigidbody>();
    }
    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);

        Vector3 velocity = rb.velocity;
        moveSpeed = velocity.magnitude;
        playerVelocity.text = moveSpeed.ToString();

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {         
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
    private void SetCountText()
    {
        scoreText.text = " Score : " + count.ToString();

        if (count >= numPickups)
        {
            winText.text = "You win!";
        }
        playerPosition.text = transform.position.ToString(); 
        
    }
}
