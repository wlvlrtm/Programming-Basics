using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;


    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public bool isDeath;


    private Animator animator;

    private float gravityModifier = 3f;
    private float jumpPower = 12;

    private bool isGround;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround && !isDeath)
        {
            animator.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isGround = false;
            dirtParticle.Stop();
        }
        else if (isDeath)
        {
            dirtParticle.Stop();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            animator.SetBool("Death_b", true);
            isDeath = true;
        }
        else if (collision.gameObject.CompareTag("Ground") && !isDeath)
        {
            dirtParticle.Play();
            isGround = true;
        }
    }
}