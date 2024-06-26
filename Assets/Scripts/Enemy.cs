using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] targetPositions1;
    public Transform[] targetPositions2;
    public Transform[] targetPositions3;
    public Transform[] targetPositions4;
    public float speed = 15f;
    private List<GameObject> enemyList = new List<GameObject>();
    public float currentEnemy;
    public Transform canvasTransform;

    public float currentTime;
    public float time;

    public bool checkMove1 = true;
    public bool checkMove2;
    public bool checkMove3;
    public bool checkMove4 ;
    
    public static Enemy instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }
        private IEnumerator Spawn()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, canvasTransform);
            enemyList.Add(newEnemy);
            yield return new WaitForSeconds(0.25f);
        }
        Debug.Log("Coroutine ended.");
    }

    void Start()
    {
        StartCoroutine(Spawn());
        currentTime = Time.time;
        currentEnemy = 16;
    }

    void Update()
    {
        time = Time.time;
        if (time - currentTime >= 10)
        {
            checkMove1 = false;
            checkMove2 = true;
        }
        if (time - currentTime >= 15)
        {
            checkMove2 = false;
            checkMove3 = true;
        }
        if (time - currentTime >= 20)
        {
            checkMove3 = false;
            checkMove4 = true;
        }
        Debug.Log(time - currentTime);
        if (checkMove1)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                GameObject enemy = enemyList[i];
                if (i < targetPositions1.Length)
                {
                    Transform targetPosition = targetPositions1[i];
                    float step = speed * Time.deltaTime;
                    enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, targetPosition.position, step);
                }
            }
        }
        if (checkMove2)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                GameObject enemy = enemyList[i];
                if (i < targetPositions2.Length)
                {
                    Transform targetPosition = targetPositions2[i];
                    float step = speed * Time.deltaTime;
                    enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, targetPosition.position, step);
                }
            }
        }
        if (checkMove3)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                GameObject enemy = enemyList[i];
                if (i < targetPositions3.Length)
                {
                    Transform targetPosition = targetPositions3[i];
                    float step = speed * Time.deltaTime;
                    enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, targetPosition.position, step);
                }
            }
        }
        if (checkMove4)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                GameObject enemy = enemyList[i];
                if (i < targetPositions4.Length)
                {
                    Transform targetPosition = targetPositions4[i];
                    float step = speed * Time.deltaTime;
                    enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, targetPosition.position, step);
                }
            }
        }
    }
}
