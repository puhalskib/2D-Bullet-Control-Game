using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScript : MonoBehaviour
{
    //reference to the other portal
    public portalScript otherPortal;

    private bool first;

    // Start is called before the first frame update
    void Start()
    {
        first = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //might have to check tag to make sure object is a projectile
        if (first)
        {
            otherPortal.first = false;
            collision.transform.position = otherPortal.transform.position;

        } else
        {
            first = true;
        }
    }

}