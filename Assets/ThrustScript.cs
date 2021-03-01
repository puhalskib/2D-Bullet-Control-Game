using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustScript : MonoBehaviour
{
    public float thrust;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;

        Vector2 forward = transform.TransformDirection(Vector3.right).normalized;

        rb.AddForce(forward * thrust);
    }
}
