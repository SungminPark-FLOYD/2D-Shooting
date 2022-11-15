using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int maxhealth;
    public int curhealth;

    Rigidbody2D rigid;
    BoxCollider2D Box;
    Material mat;
    

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Box = GetComponent<BoxCollider2D>();
        mat = GetComponent<SpriteRenderer>().material;
        
    }

    void Update()
    {
        
    }
    void OnHit(int dmg)
    {
        curhealth -= dmg;

        if(curhealth <= 0)
        {
            Destroy(gameObject);
        }
    } 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();
            OnHit(bullet.dmg);
            StartCoroutine(OnDamage());
        }
    }
    IEnumerator OnDamage()
    {
        mat.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        if(curhealth > 0)
        {
            mat.color = new Color(65f/255f, 194f/255f, 204f/255f, 255f/255);
        }
    }

    
}