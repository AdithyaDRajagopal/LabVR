using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Status : MonoBehaviour
{
    public TextMeshProUGUI stat;
    private int count;

    void Start()
    {
        count = 0;
    }

    public void StatUpdate()
    {
        count = (count + 1) % 3;
        stat = GetComponent<TextMeshProUGUI>();
        if (count == 0)
        stat.text = "START";
        else if (count == 1)
        stat.text = "STOP";
        else
        stat.text = "RESET";
    }
}
