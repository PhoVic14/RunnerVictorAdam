using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mur : MonoBehaviour
{
    PlayerMovement playerMovement;
    [SerializeField] Rigidbody rb;
    [SerializeField] float horizontalMultiplier;

    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Get the Rigidbody from PlayerMovement
            Rigidbody playerRigidbody = playerMovement.GetRigidbody();

            // Calculate the direction of the bounce
            Vector3 bounceDirection = transform.right * horizontalMultiplier;

            // Apply the bounce force to the player's Rigidbody
            playerRigidbody.AddForce(bounceDirection, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
