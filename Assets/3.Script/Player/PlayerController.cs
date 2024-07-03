using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private TimeManager timemanager;
    private void Start()
    {
        timemanager = FindObjectOfType<TimeManager>();
    }
    private void Update()
    {
        // 입력했을때 타이밍 판정
        if(Input.GetKeyDown(KeyCode.Space))
        {
            timemanager.Check_Timing();
        }
    }
}
