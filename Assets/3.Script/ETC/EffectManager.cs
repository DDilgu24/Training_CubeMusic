using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    // animator -> trigger Hit 호출

    private Animator NoteHit_Animator;
    private Animator Judgement_Animator;
    private Image Judgement_Img;

    private string Key = "Hit";

    [Header("Perfect -> Cool -> Good -> Bad")]
    [SerializeField] private Sprite[] Judgement_sprite; // 직접 할당

    private void Awake()
    {
        // NoteHit_Animator = transform.GetChild(0).GetComponent<Animator>();
        // = 쓰는 순간 자동으로 null 할당.
        // 그 후 대입되면 null 삭제를 위해 가비지 컬렉터가 작동되야함.
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
