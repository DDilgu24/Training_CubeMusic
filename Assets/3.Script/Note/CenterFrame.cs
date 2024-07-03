using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFrame : MonoBehaviour
{
    // 1��° ��尡 ������ ��(�浹���� �� - Ʈ���� �߻�) �뷡 ����
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
