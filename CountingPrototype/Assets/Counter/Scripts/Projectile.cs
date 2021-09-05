using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rigidbody;
    private GameObject muzzle;
    private GunController gc;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("Gun").GetComponent<GunController>();
        rigidbody = GetComponent<Rigidbody>();
        muzzle = GameObject.Find("Muzzle");

        rigidbody.AddForce(muzzle.transform.forward * gc.power, ForceMode.Impulse);
    }
}