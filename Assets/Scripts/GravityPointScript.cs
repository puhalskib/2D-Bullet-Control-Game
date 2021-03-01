using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPointScript : MonoBehaviour
{
    public List<GameObject> entities;
    private List<Rigidbody2D> rbs;

    private Transform thisTransform;
    public float thisMass = 1;

    // Start is called before the first frame update
    void Start()
    {
        //fill rbs with all the rigidbodies
        rbs = new List<Rigidbody2D>();
        for (int i = 0; i < entities.Count; i++)
        {
            rbs.Add(entities[i].GetComponent<Rigidbody2D>());
        }

        //get this transform
        thisTransform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        for(int i = 0; i < entities.Count; i++)
        {
            Vector3 v = thisTransform.position - entities[i].transform.position;
            float dist = Vector3.Distance(entities[i].transform.position, thisTransform.position);
            if(dist > 0.1)
                rbs[i].AddForce(((rbs[i].mass * thisMass) / (dist*dist) ) * v);
        }
    }

    public void AddEntity(GameObject g)
    {
        entities.Add(g);
        rbs.Add(g.GetComponent<Rigidbody2D>());
    }
    public void RemoveEntity(GameObject g)
    {
        rbs.Remove(g.GetComponent<Rigidbody2D>());
        entities.Remove(g);
    }
}
