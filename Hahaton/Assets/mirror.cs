using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour
{
    [SerializeField]
    private GameObject luch;

    private GameObject ray;

    //public List<GameObject> lights = new List<GameObject>();
    public void DrawRay(Vector3 pos, Vector3 dir, float dist)
    {
        Debug.DrawRay(pos, dir * dist, Color.red);
        if (ray == null)
        { 
            ray = Instantiate(luch, pos, Quaternion.identity); 
        }
        else
        {
            ray.transform.position = pos;
            ray.transform.up = dir;
        }
        //g.transform.rotation = Quaternion.Euler(dir);
        //lights.Add(g);
    }

    public void Update()
    {
        
    }
}
