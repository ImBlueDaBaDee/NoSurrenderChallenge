using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
    TextMeshProUGUI counter;
    void Start()
    {
        counter = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        counter.SetText("Remaining Enemies = "+GameManager.Instance.GetEnemyCount().ToString());
    }
}
