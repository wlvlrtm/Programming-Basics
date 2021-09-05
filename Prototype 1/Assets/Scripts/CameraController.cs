using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject vehicles;    // Car object

    [SerializeField] Vector3 offset = new Vector3(0, 7, -8); // Vector3 of car to Camera

    // Start is called before the first frame update
    void Start()
    {
        vehicles = GameObject.Find("Car");  // Set a Car object
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = vehicles.transform.position + offset;  // Camera's pos. == Car's pos. + offset
    }
}