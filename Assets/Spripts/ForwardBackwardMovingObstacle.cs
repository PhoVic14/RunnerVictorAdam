using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForwardBackwardMovingObstacle : MonoBehaviour
{
    public float speed = 3f; // Vitesse de d�placement de l'obstacle
    public float forwardLimit = 5f; // Limite avant
    public float backwardLimit = -5f; // Limite arri�re

    private bool movingForward = true; // Indique si l'obstacle se d�place vers l'avant

    void Update()
    {
        // D�placement de l'obstacle
        if (movingForward)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        // V�rification des limites et inversion de la direction si n�cessaire
        if (transform.position.z >= forwardLimit)
        {
            movingForward = false;
        }
        else if (transform.position.z <= backwardLimit)
        {
            movingForward = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                SceneManager.LoadScene(2);
                playerMovement.Die();
            }
        }
    }
}
