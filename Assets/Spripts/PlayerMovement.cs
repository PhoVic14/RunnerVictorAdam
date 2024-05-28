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
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && !hasJumped && IsGrounded())
        {
            Jump();
            hasJumped = true;
        }

        if (IsGrounded())
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
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
    }

    bool IsGrounded()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool grounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        return grounded;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Collision with wall detected!");
            // Arr�ter le mouvement
            rb.velocity = Vector3.zero;
            // Si n�cessaire, ajustez la position du joueur pour �viter qu'il ne passe � travers le mur
            Vector3 closestPoint = collision.collider.ClosestPoint(transform.position);
            transform.position = new Vector3(closestPoint.x, transform.position.y, closestPoint.z - 0.5f);
        }
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }
}
