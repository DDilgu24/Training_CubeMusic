using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFrame : MonoBehaviour
{
    // 1번째 노드가 지나갈 때(충돌했을 때 - 트리거 발생) 노래 시작
    private AudioSource audiosource;
    private bool isStart = false;
    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!isStart && col.CompareTag("Note"))
        {
            audiosource.Play();
            isStart = true;
        }
    }
}
