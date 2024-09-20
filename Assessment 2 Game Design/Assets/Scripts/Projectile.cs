using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public CircleCollider2D collider;
    public Vector3 direction;
    public LayerMask layerMask;
    public int projectileDamage;
    public float projectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dv = direction * Time.deltaTime * projectileSpeed;
        Vector3 p = transform.position + dv;
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, collider.radius, direction, dv.magnitude, layerMask);
        if (hit.collider != null)
        {
            EnemyMovement hitEnemy = hit.collider.GetComponentInParent<EnemyMovement>();
            if (hitEnemy != null)
            {
                hitEnemy.TakeDamage(projectileDamage);
            }
            Destroy(gameObject);
        }
        transform.position = p;
    }
}
