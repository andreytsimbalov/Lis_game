using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSorter : MonoBehaviour
{
    [SerializeField]
    private int sortOrdBase = 500;
    [SerializeField]
    public float offset = 0f;
    private Renderer rend;

    private void Awake()
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        rend.sortingOrder = (int)((sortOrdBase - transform.position.y- offset)*10);
    }
}
