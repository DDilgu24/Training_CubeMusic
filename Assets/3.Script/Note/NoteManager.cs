using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public Note_Pooling note_Pooling;

    // BPM 120 -> 0.5�ʿ� ��Ʈ 1��
    [Header("BPM ����")]
    public int BPM = 0;
    private double current_time = 0d;

    [Header("ETC")]
    [SerializeField] private GameObject notePrefabs;
    [SerializeField] private Transform noteSpawner;
    private TimeManager timemanager;
    private void Awake()
    {
        timemanager = FindObjectOfType<TimeManager>();
    }

    private void Update()
    {
        current_time += Time.deltaTime;
        if (current_time > 60d / BPM)
        {
            // ��Ʈ �����ϴ� �κ�
            // 1. ��Ʈ�� Ǯ���� �����´�.
            GameObject note_obj = note_Pooling.GetObjectFromPool();
            // 2. ������ ��Ʈ�� ��ġ�� �����Ѵ�.
            note_obj.transform.position = noteSpawner.position;
            // 3. ��Ʈ ������Ʈ�� �θ� �����Ѵ�. 
            note_obj.transform.SetParent(this.transform);
            // 4. (�̰� ���� ��� ���� �ʳ�?? - �ٵ� �ϴ� ��� ����)
            timemanager.boxnote_List.Add(note_obj);

            /*
            GameObject note_obj = Instantiate(notePrefabs, noteSpawner.position, Quaternion.identity);
            note_obj.transform.SetParent(this.transform);
            timemanager.boxnote_List.Add(note_obj);
            */
            current_time -= (60d / BPM);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // ��Ʈ�� ������� �κ�, �̽� ���� ����
        if(col.CompareTag("Note"))
        {
            if(col.TryGetComponent(out Note n))
            {
                if (n.GetNoteFlag()) Debug.Log("Miss");
            }
            // timemanager.boxnote_List.Remove(col.gameObject);
            note_Pooling.ReturnObjectToPool(col.gameObject);
            // Destroy(col.gameObject);
        }
    }
}
