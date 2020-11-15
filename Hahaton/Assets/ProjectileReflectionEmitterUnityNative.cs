using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class ProjectileReflectionEmitterUnityNative : MonoBehaviour
{
    public int sceneNumber = 0;


    [SerializeField]
    private GameObject LightPrefab;

    [SerializeField]
    private float drr = 0.5f;


    public int maxReflectionCount = 5;
    public float maxStepDistance = 200;

    [SerializeField]
    List<GameObject> lights = new List<GameObject>();

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.ArrowHandleCap(0, this.transform.position + this.transform.up * 0.25f, this.transform.rotation, 0.5f, EventType.Repaint);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, 0.25f);
        //DrawPredictedReflectionPattern(this.transform.position + this.transform.up * 0.75f, this.transform.up, maxReflectionCount);
    }
#endif

    private void DrawPredictedReflectionPattern(Vector2 position, Vector2 direction, int reflectionsRemaining)
    {      
        if (reflectionsRemaining <= 0)
        {
            return;
        }

        Vector2 startingPosition = position;

        RaycastHit2D hit = Physics2D.Raycast(position, direction * maxStepDistance);
        if (hit.collider != null && hit.collider.tag == "Mirror")
        {
            direction = Vector2.Reflect(direction, hit.normal);
            position = hit.point + direction * drr;//2
        }
        else
        {
            if (hit.collider != null && hit.collider.tag == "Banana")
            {
                SceneManager.LoadScene(sceneNumber);
            }
            position += direction * maxStepDistance;
        }

        
        Debug.DrawLine(startingPosition, position, Color.yellow);
        var g = Instantiate(LightPrefab);
        g.transform.position = startingPosition;
        g.SetActive(true);
        g.transform.up = (position - startingPosition).normalized;//
        lights.Add(g);

        DrawPredictedReflectionPattern(position, direction, reflectionsRemaining - 1);
    }

    public void Update()
    {
        for (int i = 0; i < lights.Count; i++)
        {
            Destroy(lights[i]);
            lights.RemoveAt(i);
        }
        DrawPredictedReflectionPattern(this.transform.position + this.transform.up * 0.75f, this.transform.up, maxReflectionCount);
        //if (lights.Count > 5)
        //{
        //    for (int i = 5; i < lights.Count; i++)
        //    {
        //        Destroy(lights[i]);
        //        lights.RemoveAt(i);
        //    }
        //}
    }
}