using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float JumpForce = 10.0f;
    private float gravityModifier = 1.8f;

    private bool isGrounded = true;
    public bool gameOver = false;
    private Animator animator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtSplatter;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
        {
            playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetTrigger("Jump_trig");
            dirtSplatter.Stop();
            playerAudio.PlayOneShot(jumpSound);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtSplatter.Play();
        } else if (collision.gameObject.CompareTag("Obstacles"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            animator.SetInteger("DeathType_int", 1);
            animator.SetBool("Death_b", true);
            explosionParticle.Play();
            dirtSplatter.Stop();
            playerAudio.PlayOneShot(crashSound);
            

        }
        
    }
}
