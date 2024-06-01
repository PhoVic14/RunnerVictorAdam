using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "Player")
        {
            return;
        }

        GameManager.inst.IncrementScore();

        // Jouer le son de la pièce
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayCoinCollectSound();
        }

        // Désactiver le rendu de la pièce et le collider pour éviter d'autres collisions
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // Détruire l'objet après la fin du son
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
