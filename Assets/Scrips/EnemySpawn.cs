using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] prefabs; //게임 오브젝트
                                 
                                 
    private BoxCollider2D area;    
    public int count = 20;      //찍어낼 게임 오브젝트 갯수

    private List<GameObject> gameObject = new List<GameObject>();

    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        StartCoroutine("Spawn", 20);
    }
    private Vector2 GetRandomPosition()
    {
        Vector2 basePosition = transform.position;
        Vector2 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }
    private IEnumerator Spawn(float delayTime)
    {
        for (int i = 0; i < count; i++) //count만큼 블럭 생성
        {
            Vector3 spawnPos = GetRandomPosition(); //랜덤 위치 return
            int selection = Random.Range(0, prefabs.Length);

            GameObject selectedPrefab = prefabs[selection];
            //원본, 위치, 회전값을 매개변수로 받아 오브젝트 복제
            GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
            gameObject.Add(instance); //오브젝트 관리를 위해 리스트에 add
        }
        area.enabled = false;
        yield return new WaitForSeconds(delayTime);   //주기 : 20초

        for (int i = 0; i < count; i++) //블럭삭제
            Destroy(gameObject[i].gameObject);

        gameObject.Clear();           //List 비우기
        area.enabled = true;
        StartCoroutine("Spawn", 20);    //블럭 다시 스폰
    }
}
