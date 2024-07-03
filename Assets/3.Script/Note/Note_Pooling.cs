using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_Pooling : MonoBehaviour
{
    // 1�ܰ�: Ǯ ����
    // 1-1. Ǯ���� ������Ʈ�� �������� ����
    public GameObject notePrefab;
    // 1-2. Ǯ���� ���� ����
    public int poolSize;
    // 1-3. Ǯ���� ������ ť�� ����
    private Queue<GameObject> NotePool = new Queue<GameObject>();
    // 1-4. ť�� ������Ʈ���� ä���
    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            // 1-4-1. ������Ʈ ����
            GameObject note_obj = Instantiate(notePrefab);
            // 1-4-2. ������ �� ��Ȱ��ȭ
            note_obj.SetActive(false);
            // 1-4.3. ť�� �߰�
            NotePool.Enqueue(note_obj);
        }
    }

    // 2�ܰ�: ������Ʈ�� Ǯ���� ���� �� �޼���
    public GameObject GetObjectFromPool()
    {
        // ���� ó��: Ǯ�� ���� ����ع��� ���
        if(NotePool.Count.Equals(0))
        {
            Debug.Log("!!! Ǯ�� ������ �ʰ���");
            return null;
        }
        // 2-1. ť���� ������Ʈ�� ������
        GameObject note_obj = NotePool.Dequeue();
        // 2-2. ���� �� Ȱ��ȭ
        note_obj.SetActive(true);
        // 2-3. ���� ������Ʈ�� ��ȯ
        return note_obj;
    }

    // 3�ܰ�: ������Ʈ�� Ǯ�� �ݳ��ϴ� �޼���
    public void ReturnObjectToPool(GameObject obj)
    {
        // 3-1. ���� �� ��Ȱ��ȭ
        obj.SetActive(false);
        // 3-2. �ٽ� ť�� �ֱ�
        NotePool.Enqueue(obj);
    }

    public int GetActiveNoteCount()
    {
        return poolSize - NotePool.Count;
    }
}
