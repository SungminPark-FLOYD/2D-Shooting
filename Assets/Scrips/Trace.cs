using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trace : MonoBehaviour
{
    public float speed;
    public Transform target;
    Rigidbody2D rigid;
    Vector2 movement;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    
}
