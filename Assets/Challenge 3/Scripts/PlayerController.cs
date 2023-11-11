using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private AudioSource playerAudio;

    public float floatForce;
    public float gravityModifier;

    public bool gameOver;
    public bool isLowEnough;

    public ParticleSystem balloonParticle;
    public ParticleSystem bombParticle;

    public AudioClip balloonSound;
    public AudioClip bombSound;
    public AudioClip groundSound;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > 13)
        {
            isLowEnough = false;
        }
        else
        {
            isLowEnough = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isLowEnough && !gameOver )
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }   
    }

    private void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            balloonParticle.Play();
            playerAudio.PlayOneShot(balloonSound, 1.0f);
            
            Destroy(other.gameObject);

        } else if (other.gameObject.CompareTag("Bomb"))
        {
            bombParticle.Play();
            playerAudio.PlayOneShot(bombSound, 1.0f);

            gameOver = true;

            Debug.Log("Game Over !");

            
            Destroy(other.gameObject);
        
        } else if (other.gameObject.CompareTag("Ground"))
        {
            playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            playerAudio.PlayOneShot(groundSound, 1.0f);

        }    
            
    }
}
