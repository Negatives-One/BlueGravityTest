using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class YSort : MonoBehaviour
{
    private SortingGroup sortingGroup;
    private void Start()
    {
        sortingGroup = GetComponent<SortingGroup>();
    }
    
    private void Update()
    {
        sortingGroup.sortingOrder = Mathf.Abs((int)(transform.position.y * 100) + 5);
    }
}
