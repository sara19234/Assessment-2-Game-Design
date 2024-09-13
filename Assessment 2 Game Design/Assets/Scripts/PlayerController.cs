using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2000f;
    public float jumpspeed = 200f;
    public GameObject projectilePrefab;


    bool isGrounded;
    bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * speed * Time.deltaTime);
            facingRight = true;
        }
        // making the player move right

        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * speed * Time.deltaTime);
            facingRight = false;
        }
        // making the player move left otherwise

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpspeed);
            isGrounded = false;
        }
        // making the player move up/jump
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectile projectile = newProjectile.GetComponent<Projectile>();
            if(facingRight)
            {
                projectile.direction = Vector3.right;
            }
            else
            {
                projectile.direction = -Vector3.right;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            isGrounded = true;
    }
}
