using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rigid;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;

    private void Awake()
    {
        {
            rigid = GetComponent<Rigidbody2D>();
        }
    }
     
    public void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector3 lookDir = mousePos - rigid.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rigid.rotation = angle;
    }


}
