using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAnimationScript : MonoBehaviour
{
    [SerializeField]
    private float startScale;

    [SerializeField]
    private float maxMouseDistanceScale;

    [SerializeField]
    private float maxCannonScale;

    public Transform cannonArmTran;

    [SerializeField]
    private Transform cannonTipTran;

    private Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        cannonArmTran.localScale = new Vector3(startScale, 1, 1);
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Scale(float f)
    {
        cannonArmTran.localScale = new Vector3(f, 1, 1);
    }



    /*
     * Public Methods
     * 
     */





    // function returns the position of the cannon tip
    public Vector3 getCannonTip()
    {
        return cannonTipTran.position;
    }



    // function scales the cannon relative to the mousePos, the maxMouseDistanceScale, and maxCannonScale
    public void ScaleToMousePos(Vector3 mousePos)
    {
        Vector3 dir = mousePos - trans.position;
        float dist = (Mathf.Sqrt((dir.x * dir.x) + (dir.y * dir.y)) ) / maxMouseDistanceScale;

        if (dist > 1)
        {
            dist = 1;
        }

        this.Scale(dist*maxCannonScale);
    }



    // function points the cannon to a point
    public void PointTo(Vector3 p)
    {
        Vector3 dir = p - trans.position;

        //Dunno why this works it just does
        if(dir.x < 0)
        {
            trans.rotation = Quaternion.Euler(0, 0, Mathf.Atan(dir.y / dir.x) * Mathf.Rad2Deg + 180);
        } else
        {
            trans.rotation = Quaternion.Euler(0, 0, Mathf.Atan(dir.y / dir.x) * Mathf.Rad2Deg);
        }
    }


    //get the angle of the cannon
    public Quaternion getAngle()
    {
        return transform.rotation;
    }
}
