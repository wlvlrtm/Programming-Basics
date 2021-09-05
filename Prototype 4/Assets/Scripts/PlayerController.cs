using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;
    private GameObject focalPoint;
    private float vertical;
    private float powerUpStrength = 15.0f;
    private bool hasPowerUp;

    public GameObject powerUpIndicator;
    public bool isDeath;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
        rigidbody = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        rigidbody.AddForce(focalPoint.transform.forward * vertical * speed * Time.deltaTime, ForceMode.Impulse);

        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
            Debug.Log("GameOver!");
            isDeath = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUP"))
        {
            powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            hasPowerUp = true;
            StartCoroutine(PowerUpCountDownRoutine());
        }
    }

    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }

}
