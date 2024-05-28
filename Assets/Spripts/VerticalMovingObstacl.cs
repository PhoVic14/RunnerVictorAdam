using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingObstacl : MonoBehaviour
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
}
