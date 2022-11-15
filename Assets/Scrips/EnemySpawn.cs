using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] prefabs; //���� ������Ʈ
                                 
                                 
    private BoxCollider2D area;    
    public int count = 20;      //�� ���� ������Ʈ ����

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
        for (int i = 0; i < count; i++) //count��ŭ �� ����
        {
            Vector3 spawnPos = GetRandomPosition(); //���� ��ġ return
            int selection = Random.Range(0, prefabs.Length);

            GameObject selectedPrefab = prefabs[selection];
            //����, ��ġ, ȸ������ �Ű������� �޾� ������Ʈ ����
            GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
            gameObject.Add(instance); //������Ʈ ������ ���� ����Ʈ�� add
        }
        area.enabled = false;
        yield return new WaitForSeconds(delayTime);   //�ֱ� : 20��

        for (int i = 0; i < count; i++) //������
            Destroy(gameObject[i].gameObject);

        gameObject.Clear();           //List ����
        area.enabled = true;
        StartCoroutine("Spawn", 20);    //�� �ٽ� ����
    }
}
