using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float forceMagnitude = 100f;
    public Canvas canvas;
    void Start()
    {
        StartCoroutine(Spawn());
    }
    private IEnumerator Spawn()
    {
        for (int i = 0; i < 10e9; i++)
        {
            GameObject newBullet = Instantiate(bulletPrefab, canvas.transform);
            newBullet.transform.position = transform.position; ;
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(Vector2.up * forceMagnitude * 1000, ForceMode2D.Impulse);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
