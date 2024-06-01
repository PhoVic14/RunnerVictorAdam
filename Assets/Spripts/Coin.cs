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

        // Jouer le son de la pi�ce
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayCoinCollectSound();
        }

        // D�sactiver le rendu de la pi�ce et le collider pour �viter d'autres collisions
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // D�truire l'objet apr�s la fin du son
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
