using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public Text PowerText;
    public GameObject Muzzle;
    public GameObject projectile;
    public float power = 0f;


    [SerializeField] private float speed = 50f;

    private float n = 0;
    private bool coroutineSwitch;


    private void Start()
    {
        power = 0;
    }


    void GunRotation()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * speed);

        if (transform.rotation.x > 0.3f)
        {
            speed = -50f;
        }

        if (transform.rotation.x < -0.3f)
        {
            speed = 50f;
        }
    }


    IEnumerator PowerControll()
    {
        while (Input.GetMouseButton(0))
        {
            if (power >= 15.0f)
            {
                n = -1;
            }
            else if (power <= 0.0f)
            {
                n = 1;
            }

            power += (1 * n);

            yield return new WaitForSeconds(0.1f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        PowerText.text = "Power: " + power;

        if (!Input.GetMouseButton(0))
        {
            GunRotation();
            coroutineSwitch = true;
        }
        else
        {
            if (coroutineSwitch)
            {
                StartCoroutine(PowerControll());
                coroutineSwitch = false;
            }
        }


        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(projectile, Muzzle.gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
