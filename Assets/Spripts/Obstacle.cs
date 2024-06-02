using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Dan.Main;


public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {

            SceneManager.LoadScene(2);
            playerMovement.Die();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
