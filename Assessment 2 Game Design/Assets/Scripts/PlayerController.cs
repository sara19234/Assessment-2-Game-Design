using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 2000f;
    public float jumpspeed = 200f;
    public GameObject projectilePrefab;
    public GameObject pauseMenu;
    public int bulletInGun = 12;
    public bool noAmmo = false;
    public Text ammoDisplay;

    bool isGrounded;
    bool facingRight;
    public bool ifPaused;
    private bool ifUnpaused;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        ammoDisplay.text = bulletInGun.ToString("Ammo " + bulletInGun.ToString());

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

        if (Input.GetMouseButtonDown(0) & bulletInGun > 0)
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
            bulletInGun -= 1;
        }
        if( bulletInGun == 0)
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
            isGrounded = true;
    }
}
