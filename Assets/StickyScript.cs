using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        col.attachedRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX 
            | RigidbodyConstraints2D.FreezePositionY;
    }
}
