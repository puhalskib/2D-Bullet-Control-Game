using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelToJson))]
public class BetaEdit : Editor
{
    public override void OnInspectorGUI()
    {
        //draw the normal component unity edit ui
        DrawDefaultInspector();
        //add a button

        if (GUILayout.Button("Export to Json"))
        {
            /*
            *   Map Objects
            */

            GameObject[] ar = GameObject.FindGameObjectsWithTag("Map");

            int GameObjectID = 0;

            gvdt.LevelData dat = new gvdt.LevelData();

            gvdt.Object[] objects = new gvdt.Object[ar.Length];
            for (int i = 0; i < ar.Length; i++)
            {
                GameObject g = ar[i];
                //Debug.Log(g.name + " :: " + PrefabUtility.GetPrefabAssetType(g));
                Vector3 v = g.transform.position;


                gvdt.Object ob = new gvdt.Object();
                ob.id = GameObjectID;
                GameObjectID++;
                ob.x = v.x;
                ob.y = v.y;
                ob.z = v.z;
                ob.xScale = g.transform.localScale.x;
                ob.yScale = g.transform.localScale.y;
                ob.zRot = g.transform.rotation.z;
                //ob.PrefabVariant = 0;

                (ob.Prefabid, ob.PrefabVariant) = getMapPrefabID(g.name);

                //string json = JsonUtility.ToJson(ob);
                //Debug.Log("Json: " + json); 
                if (ob.Prefabid == 1 || ob.Prefabid == 2)
                {
                    dat.cannon = ob;
                } 
                else
                {
                    objects[i] = ob;
                }


            }
            dat.entities = objects;
            dat.level = 0;
            dat.playerName = "usersname";
            string json = JsonUtility.ToJson(dat);
            Debug.Log(json);





        }
        
    }


    private (int prefab, int variant) getMapPrefabID(string s)
    {
        if (s.Contains("Background"))
        {
            return (0, 0);
        }
        else if (s.Contains("Cannon"))
        {
            if (s.Contains("GravityCannon"))
            {
                //ob.Prefabid = 2;
                //ob.PrefabVariant = 1;
                return (2, 1);
            }
            else
            {
                //base cannon
                //ob.Prefabid = 1;
                return (1, 0);
            }
        }
        else if (s.Contains("CirclePortalRoot"))
        {
            //ob.Prefabid = 3;
            return (3, 0);
        }
        else if (s.Contains("DirectionPortalRoot"))
        {
            //ob.Prefabid = 4;
            return (4, 0);
        }
        else if (s.Contains("GravityPoint"))
        {
            //ob.Prefabid = 5;
            return (5, 0);
        }
        else if (s.Contains("Projectile"))
        {
            if (s.Contains("ThrustProjectile"))
            {
                //ob.Prefabid = 7;
                //ob.PrefabVariant = 1;
                return (7, 1);
            }
            else
            {
                //base projectile
                //ob.Prefabid = 6;
                return (6, 0);
            }
        }
        else if (s.Contains("Rect"))
        {
            if (s.Contains("ShadowRect"))
            {
                if (s.Contains("BouncyShadowRect"))
                {
                    //ob.Prefabid = 11;
                    //ob.PrefabVariant = 3;
                    return (11, 3);
                }
                else if (s.Contains("StickyShadowRect"))
                {
                    //ob.Prefabid = 10;
                    //ob.PrefabVariant = 2;
                    return (10, 2);
                }
                else
                {
                    //shadowRect
                    //ob.Prefabid = 9;
                    //ob.PrefabVariant = 1;
                    return (9, 1);
                }
            }
            else
            {
                //Rect
                //ob.Prefabid = 8;
                return (8, 0);
            }
        }
        else if (s.Contains("Win Zone"))
        {
            //ob.Prefabid = 12;
            return (12, 0);
        } else  if(s.Contains("Point Light 2D"))
        {
            return (13, 0);
        }
        else
        {
            Debug.LogError("object: " + s + " not included in prefab list");
            return (-1, -1);
        }
    }

}
