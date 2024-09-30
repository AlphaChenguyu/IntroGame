using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    void Start()
    { 
        lineRenderer = gameObject.AddComponent<LineRenderer>();
    }
    
}
