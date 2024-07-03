using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    // animator -> trigger Hit ȣ��

    private Animator NoteHit_Animator;
    private Animator Judgement_Animator;
    private Image Judgement_Img;

    private string Key = "Hit";

    [Header("Perfect -> Cool -> Good -> Bad")]
    [SerializeField] private Sprite[] Judgement_sprite; // ���� �Ҵ�

    private void Awake()
    {
        // NoteHit_Animator = transform.GetChild(0).GetComponent<Animator>();
        // = ���� ���� �ڵ����� null �Ҵ�.
        // �� �� ���ԵǸ� null ������ ���� ������ �÷��Ͱ� �۵��Ǿ���.
        transform.GetChild(0).TryGetComponent(out NoteHit_Animator);
        transform.GetChild(1).TryGetComponent(out Judgement_Animator);
        transform.GetChild(1).TryGetComponent(out Judgement_Img);
    }

    public void Judgement_Effect(int effect)
    {
        Judgement_Img.sprite = Judgement_sprite[effect];
        Judgement_Animator.SetTrigger(Key);
    }

    public void NoteHit_Effect()
    {
        NoteHit_Animator.SetTrigger(Key);
    }
}
