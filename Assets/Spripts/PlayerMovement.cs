using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    bool hasJumped = false;
    public int position = 0;
    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = Vector3.zero;

        if (horizontalInput != 0)
        {
            if ((horizontalInput < 0 && this.gameObject.transform.position.x > LevelBoundary.leftSide) ||
                (horizontalInput > 0 && this.gameObject.transform.position.x < LevelBoundary.rightSide))
            {
                horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
            }
        }

        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        if (!alive) return;

        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && !hasJumped && IsGrounded()) // Vérifier si le joueur peut sauter
        {
            Jump();
            hasJumped = true;
        }

        if (IsGrounded()) // Réinitialiser hasJumped lorsque le joueur touche le sol
        {
            hasJumped = false;
        }

        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayPlayerDeathSound();
        }
        Invoke("Restart", 2);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
    }

    private bool IsGrounded()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        return Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
    }
}
