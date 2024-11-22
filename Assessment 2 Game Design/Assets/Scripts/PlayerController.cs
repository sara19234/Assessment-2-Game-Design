using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpspeed = 200f;
    public GameObject projectilePrefab;
    public GameObject pauseMenu;
    public int bulletInGun = 12;
    public bool noAmmo = false;
    public Text ammoDisplay;
    public SpriteRenderer sprite;
    private Animator animate;
    public Rigidbody2D rb;

    Vector2 movement;

    bool isGrounded;
    bool facingRight;
    public bool ifPaused;
    private bool ifUnpaused;

    // Start is called before the first frame update
    void Start()
    {
        animate = gameObject.GetComponent<Animator>();

        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        ammoDisplay.text = bulletInGun.ToString("Ammo " + bulletInGun.ToString());

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //animate.SetFloat("Speed", Mathf.Abs(movement.x));

        if (movement.x < 0 && facingRight)
        {

            GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (movement.x > 0 && !facingRight)
        {

            GetComponent<SpriteRenderer>().flipX = false;
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

        if (Input.GetMouseButtonDown(0) & bulletInGun > 0)
        {
            GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectile projectile = newProjectile.GetComponent<Projectile>();
            if (facingRight)
            {

                projectile.direction = Vector3.right;
            }
            else
            {

                projectile.direction = -Vector3.right;
            }
            bulletInGun -= 1;
        }
        if (bulletInGun == 0)
        {
            //Luke need to integrate into ui if u can thanks   
            noAmmo = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!ifPaused)
            {
                Time.timeScale = 0;
                ifPaused = true;
                pauseMenu.SetActive(true);

            }

            else
            {
                Time.timeScale = 1;
                ifPaused = false;
                pauseMenu.SetActive(false);
            }

        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }



}
