using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VerticalMovingObstacle : MonoBehaviour
{
    public float speed = 3f; // Vitesse de d�placement de l'obstacle
    public float lowerLimit = 0f; // Limite inf�rieure
    public float upperLimit = 5f; // Limite sup�rieure

    private bool movingUp = true; // Indique si l'obstacle se d�place vers le haut

    void Update()
    {
        // D�placement de l'obstacle
        if (movingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        // V�rification des limites et inversion de la direction si n�cessaire
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
