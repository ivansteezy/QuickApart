using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAreaDetector : MonoBehaviour
{
    BoxCollider2D collider2d;
    public BoxCollider2D characterBoxCollider;

    void Start()
    {
        collider2d = GetComponent<BoxCollider2D>();
    }
}
