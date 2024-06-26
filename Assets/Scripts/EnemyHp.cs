using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public float Hp = 5;
    public float time;
    public float currentTime;

    public void TakeDame()
    {
        Hp -= 1;
        if(Hp <= 0)
        {
            Enemy.instance.currentEnemy -= 1;
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        time = Time.time;
        currentTime = Time.time;
    }
    private void Update()
    {
        time = Time.time;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(time - currentTime >=25 && collision.CompareTag("Bullet")) 
        {
            TakeDame();
            Debug.Log("va cham");
        }
    }
}
