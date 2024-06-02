using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VerticalMovingObstacle : MonoBehaviour
{
    public float speed = 3f; // Vitesse de déplacement de l'obstacle
    public float lowerLimit = 0f; // Limite inférieure
    public float upperLimit = 5f; // Limite supérieure

    private bool movingUp = true; // Indique si l'obstacle se déplace vers le haut

    void Update()
    {
        // Déplacement de l'obstacle
        if (movingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        // Vérification des limites et inversion de la direction si nécessaire
        if (transform.position.y >= upperLimit)
        {
            movingUp = false;
        }
        else if (transform.position.y <= lowerLimit)
        {
            movingUp = true;
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
