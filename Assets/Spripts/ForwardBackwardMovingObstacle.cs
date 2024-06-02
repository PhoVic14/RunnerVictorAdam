using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForwardBackwardMovingObstacle : MonoBehaviour
{
    public float speed = 3f; // Vitesse de déplacement de l'obstacle
    public float forwardLimit = 5f; // Limite avant
    public float backwardLimit = -5f; // Limite arrière

    private bool movingForward = true; // Indique si l'obstacle se déplace vers l'avant

    void Update()
    {
        // Déplacement de l'obstacle
        if (movingForward)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        // Vérification des limites et inversion de la direction si nécessaire
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
