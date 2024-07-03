using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public Note_Pooling note_Pooling;

    // BPM 120 -> 0.5초에 노트 1개
    [Header("BPM 설정")]
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
            // 노트 생성하는 부분
            // 1. 노트를 풀에서 꺼내온다.
            GameObject note_obj = note_Pooling.GetObjectFromPool();
            // 2. 꺼내온 노트의 위치를 설정한다.
            note_obj.transform.position = noteSpawner.position;
            // 3. 노트 오브젝트의 부모를 변경한다. 
            note_obj.transform.SetParent(this.transform);
            // 4. (이거 이제 없어도 되지 않나?? - 근데 일단 계속 쓰자)
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
        // 노트가 사라지는 부분, 미스 판정 포함
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
