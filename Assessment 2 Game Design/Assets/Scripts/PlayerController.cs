using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 2000f;
    public float jumpspeed = 200f;
    public GameObject projectilePrefab;
    public int bulletInGun = 12;
<<<<<<< Updated upstream
    public bool noAmmo = false;
    public Text ammoDisplay;
=======
    private float dirX;
    public Animator anim;
    public SpriteRenderer sprite;
>>>>>>> Stashed changes

    bool isGrounded;
    bool facingRight;
    // Start is called before the first frame update

    private enum MovementState { Walking, Idle, Shooting }
    void Start()
    {
        isGrounded = true;
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        ammoDisplay.text = bulletInGun.ToString("Ammo" + bulletInGun);

=======
        dirX = Input.GetAxis("Horizontal");
>>>>>>> Stashed changes
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            isGrounded = true;
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if(dirX > 0f)
        {
            sprite.flipX = false;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            state = MovementState.Walking;
        }
        else
        {
            state = MovementState.Idle;
        }
            

        






        anim.SetInteger("state", (int)state);
    }
       
}
