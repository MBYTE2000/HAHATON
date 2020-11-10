using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour
{
    [SerializeField]
    private GameObject luch;

    public List<GameObject> lights = new List<GameObject>();
    public void DrawRay(Vector3 pos, Vector3 dir, float dist)
    {
        Debug.DrawRay(pos, dir * dist, Color.red);
        var g = Instantiate(luch, pos, Quaternion.identity);
        g.transform.rotation = Quaternion.Euler(dir);
        lights.Add(g);
    }

    public void delRays()
    {
        if (lights == null) return;
        foreach (var i in lights)
        {
            Destroy(i);
        }
    }
}
