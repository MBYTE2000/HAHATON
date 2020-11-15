using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mirror : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.SelectedMirror = this.gameObject;
    }
}
