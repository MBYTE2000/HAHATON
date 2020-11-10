using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class light : MonoBehaviour
{
    public float factor;
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);

        if (hit.collider != null && hit.collider.tag == "Mirror")
        {
            Vector2 dir = Vector2.Reflect(transform.up, hit.normal);

            var mirror = hit.collider.GetComponent<mirror>();
            mirror.DrawRay(hit.point, dir, factor);
        }
        else
        {
            mirror.delRays();
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.up*factor);
    }
}
