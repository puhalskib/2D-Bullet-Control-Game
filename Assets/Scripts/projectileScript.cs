using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    private Rigidbody2D rb;

    public float rotateSpeed = 2056;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the projectile towards the direction of velocity
        //rotate at a set speed so when the velocity is near zero the projectile does not GO NUTS
        if (rb.velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }
}
