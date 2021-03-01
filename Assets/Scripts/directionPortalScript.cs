using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionPortalScript : MonoBehaviour
{
    //reference to the other portal
    public directionPortalScript otherPortal;

    private bool first;

    /*
#if UNITY_EDITOR
    private Vector3 lineVect;
    private Vector3 inVect;
#endif
    */

    // Start is called before the first frame update
    void Start()
    {
        first = true;
        //lineVect = transform.position + transform.TransformDirection(Vector3.down);
        //inVect = transform.position + transform.TransformDirection(Vector3.up);
    }
    /*
#if UNITY_EDITOR
    private void Update()
    {
        Debug.DrawLine(transform.position, inVect, Color.red);
        Debug.DrawLine(transform.position, lineVect, Color.green);
    }
#endif
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //might have to check tag to make sure object is a projectile
        if (first)
        {
            otherPortal.first = false;
            collision.transform.position = otherPortal.transform.position;


#if UNITY_EDITOR
            //inVect = transform.position + new Vector3(collision.attachedRigidbody.velocity.x, collision.attachedRigidbody.velocity.y, 0);
#endif
        }
        else
        {
            first = true;
            Vector2 originalVelocity = collision.attachedRigidbody.velocity;

            float angle = (transform.rotation.eulerAngles.z - otherPortal.transform.rotation.eulerAngles.z) * Mathf.Deg2Rad;
            //set the new velocity
            collision.attachedRigidbody.velocity = -1 * new Vector2(Mathf.Cos(angle) * originalVelocity.x - Mathf.Sin(angle) * originalVelocity.y,
                Mathf.Sin(angle) * originalVelocity.x + Mathf.Cos(angle) * originalVelocity.y);

#if UNITY_EDITOR
            //lineVect = transform.position + new Vector3(collision.attachedRigidbody.velocity.x, collision.attachedRigidbody.velocity.y, 0);
#endif
        }
    }

}
