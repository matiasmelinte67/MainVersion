using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; 

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
     public AudioSource audioPlay;
     public AudioSource sourceAudio;
     public AudioSource audioPlayer;
    private float movementX;
    private float movementY;
    public float speed = 0;
    private int count;
    public TextMeshProUGUI countText; // ref to UI text component
    public GameObject winTextObject; 

    // Start is called before the first frame update
    // check every frame for player input
    // apply that to player game object as movement
    // fixed update <= called just before physics calculations
    void Start()
    {
        count = 0; //sets initial count to zero
        rb = GetComponent<Rigidbody>();

        setCountText();

        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementVal)
    {
        //getting input value from player
        // gets vector 2 data from movement value and stores it into the vector2 variable = movementVector
        Vector2 movementVector = movementVal.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }
void setCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            countText.gameObject.SetActive(true);
            countText.text = "You Win!";

            // Play the win sound
            if (audioPlay != null) 
            {
                audioPlay.Play();
            }

            // Destroy the enemy object
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Enemy"))
    {
        // Play the audio if assigned
        if (sourceAudio != null)
        {
            sourceAudio.Play();
        }

        // Destroy the player GameObject
        Destroy(gameObject);

        // Update UI to show "You Lose!"
        if (countText != null)
        {
            countText.gameObject.SetActive(true);
            countText.text = "You Lose!";
        }
    }
}


private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("PickUp"))
    {
        // Play sound effect at the pickup location
        if (audioPlayer != null)
        {
            audioPlayer.Play();
        }

        // Disable the pickup
        other.gameObject.SetActive(false);

        // Increment count and update the UI
        count += 1;
        setCountText();
    }
}


    }
