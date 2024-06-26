using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TotalPoint : MonoBehaviour
{
    public Text txt;
    private void Awake()
    {
        txt = GetComponent<Text>();
    }
    private void Update()
    {
        float count = 16 - Enemy.instance.currentEnemy;
        txt.text = count.ToString();
    }
}
