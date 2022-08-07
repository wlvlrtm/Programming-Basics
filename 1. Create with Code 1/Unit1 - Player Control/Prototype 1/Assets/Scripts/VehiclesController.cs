using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VehiclesController : MonoBehaviour
{
    // SerializeField: You can change that variables value in the Inspector, but you cannot do it in other scripts.
    [SerializeField] private float horsePower = 20f;
    [SerializeField] private float rotateSpeed = 45f;
    [SerializeField] private float speed;
    [SerializeField] private float rpm;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private int wheelsOnGround;    
    [SerializeField] private List<WheelCollider> allWheels;

    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;
     


    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }


    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            // Car Controll
            playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);
            transform.Rotate(Vector3.up, rotateSpeed * horizontalInput * Time.deltaTime);

            // speed & rpm Calculating
            speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
            rpm = Mathf.Round((speed % 30) * 40);

            // UI texts print
            speedometerText.SetText("Speed: " + speed + " km/h");
            rpmText.SetText("RPM: " + rpm);
        }

        
    }


    private bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
