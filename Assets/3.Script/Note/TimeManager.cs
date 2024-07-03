using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Timing -> 노트의 현재 position 기준으로 판정을 내림
    [Header("Perfect -> Cool -> Good -> Bad")]
    [SerializeField] private RectTransform[] timingRect;
    [SerializeField] private RectTransform Center;
    private Vector2[] TimeBox;
    public Note_Pooling note_Pooling;
    public List<GameObject> boxnote_List = new List<GameObject>();
    private EffectManager effect;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private ComboManager comboManager;

    private void Start()
    {
        effect = FindObjectOfType<EffectManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        comboManager = FindObjectOfType<ComboManager>();
        
        TimeBox = new Vector2[timingRect.Length];
        //최소값과 최대값. 이미지의 중심 +-(이미지 너비의 절반).
        for (int i = 0; i < timingRect.Length; i++)
        {
            TimeBox[i].Set
                (Center.localPosition.x - timingRect[i].rect.width / 2,
                Center.localPosition.x + timingRect[i].rect.width / 2);

        }
    }

    public bool Check_Timing()
    {
        // 키 입력시 판정하는 부분
        for (int i = 0; i < boxnote_List.Count; i++)
        {
            float notePos_X = boxnote_List[i].transform.localPosition.x;
            for (int j = 0; j < TimeBox.Length; j++)
            {
                if (TimeBox[j].x <= notePos_X && notePos_X <= TimeBox[j].y)
                {
                    if (boxnote_List[i].transform.TryGetComponent(out Note n)) n.HideNote();
                    effect.NoteHit_Effect();
                    effect.Judgement_Effect(j);
                    scoreManager.AddScore(j);
                    if (j < 3) 
                        comboManager.AddCombo();
                    else 
                        comboManager.ResetCombo();
                    // Debug.Log(Debug_Note(j));
                    return true;
                }
            }
        }
        return false;
    }

    public string Debug_Note(int x)
    {
        return x switch
        {
            0 => "Perfect",
            1 => "Cool",
            2 => "Good",
            3 => "Bad",
            _ => "",
        };
    }
}
