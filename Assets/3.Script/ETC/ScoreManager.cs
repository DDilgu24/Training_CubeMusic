using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text Score_Text;
    [SerializeField] private Animator ani;

    private string key = "Score";

    private int Current_Score = 0;
    private int Default_Score = 10;

    [SerializeField] private float[] weight;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        transform.GetChild(0).TryGetComponent(out Score_Text);
    }

    public void AddScore(int index)
    {
        int _score = (int)(Default_Score * weight[index]);
        Current_Score += _score;
        Score_Text.text = string.Format("{0:#,##0}", Current_Score); // 1,000 이렇게 표시
        ani.SetTrigger(key);
    }
}
