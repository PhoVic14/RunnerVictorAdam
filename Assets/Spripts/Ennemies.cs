using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 3f; // Vitesse de d�placement de l'obstacle
    public float leftLimit = -5f; // Limite de gauche
    public float rightLimit = 5f; // Limite de droite

    private bool movingRight = true; // Indique si l'obstacle se d�place vers la droite

    void Update()
    {
        // D�placement de l'obstacle
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // V�rification des limites et inversion de la direction si n�cessaire
        if (transform.position.x >= rightLimit)
        {
            movingRight = false;
        }
        else if (transform.position.x <= leftLimit)
        {
            movingRight = true;
        }
    }
}