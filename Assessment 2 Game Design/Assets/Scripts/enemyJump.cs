using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float timer;
    [SerializeField] private float lunchForce;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.AddComponent<Rigidbody2D>();
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3f)
        {
            timer = 0f;
            rb2D.AddForce(transform.up * lunchForce);
        }
    }
}
