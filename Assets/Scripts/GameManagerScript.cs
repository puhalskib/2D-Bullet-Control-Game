using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject[] gravityPoints;
    public GravityPointScript[] gravityScripts;

    public GameObject[] entities;

    [SerializeField]
    private GameObject projectile;

    public int secondsUntilDestroy = 5;

    public GameObject mainCannon;

    private CannonAnimationScript mainCannonScript;

    public int mainCannonForceScaler;
    // Start is called before the first frame update
    void Start()
    {
        /*
        LevelData l = new LevelData();
        l.level = 2;
        l.playerName = "joe";
        l.sampleFloat = 1.23f;
        string json = JsonUtility.ToJson(l);
        Debug.Log("Json: " + json);*/

        mainCannonScript = mainCannon.GetComponent<CannonAnimationScript>();

        //get all gravityScript components from the gravityPoints
        gravityScripts = new GravityPointScript[gravityPoints.Length];


        for(int i = 0; i < gravityPoints.Length; i++)
        {
            gravityScripts[i] = gravityPoints[i].GetComponent<GravityPointScript>();
        }

        //assign the entities in the scene to the gravity points
        //TODO change to not start a coroutine for every projectile
        foreach (GravityPointScript gs in gravityScripts)
        {
            foreach(GameObject g in entities)
            {
                StartCoroutine(DestroyEntity(g, secondsUntilDestroy));
            }
        }




    }

    // Update is called once per frame
    void Update()
    {
        // Point cannon to mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mainCannonScript.PointTo(mousePos);

        /* Scale the cannon according to the mouse position
         * has parameters maxMouseDistance and maxCannonScale, 
         */
        mainCannonScript.ScaleToMousePos(mousePos);

        // Fire cannon
        if (Input.GetButtonDown("Fire1"))
        {
            // create and fire projectile
            Vector3 cntp = mainCannonScript.getCannonTip();


            GameObject proj = Instantiate(projectile, cntp, mainCannonScript.getAngle());
            proj.GetComponent<Rigidbody2D>().AddForce(mainCannonForceScaler * (cntp - mainCannon.transform.position));
            

            // add the projectile to all the gravity points components
            foreach (GravityPointScript gs in gravityScripts)
            {
                gs.AddEntity(proj);
            }

            //destroy the projectile after a few seconds
            StartCoroutine(DestroyEntity(proj, secondsUntilDestroy));
        }

    }

    //finish the level
    public void CompleteLevel()
    {
        Debug.Log("Level complete");
    }

    IEnumerator DestroyEntity(GameObject g, int sec)
    {
        //wait seconds
        yield return new WaitForSeconds(sec);

        // remove the gameobject from all the gravity points
        foreach (GravityPointScript gs in gravityScripts)
        {
            gs.RemoveEntity(g);
        }
        //remove gameobject
        Destroy(g);
    }
}
