using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject SelectedMirror;

    public void Right()
    {
        if (SelectedMirror != null)
        {
            SelectedMirror.transform.Rotate(new Vector3(0, 0, -5));
        }
    }

    public void Left()
    {
        if (SelectedMirror != null)
        {
            SelectedMirror.transform.Rotate(new Vector3(0, 0, 5));
        }
    }
}
