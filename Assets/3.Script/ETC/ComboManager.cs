using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    [SerializeField] private GameObject combo_img;
    [SerializeField] private Text comboText;

    private int current_combo = 0;

    private Animator ani;
    private string key = "Combo";

    private void Start()
    {
        ani = GetComponent<Animator>();
        combo_img.SetActive(false);
        comboText.gameObject.SetActive(false);
    }

    public void ResetCombo()
    {
        current_combo = 0;
        comboText.text = string.Format("{0:#,##0}", current_combo);
        combo_img.SetActive(false);
        comboText.gameObject.SetActive(false);
    }

    public void AddCombo(int combo = 1)
    {
        current_combo += combo;
        comboText.text = string.Format("{0:#,##0}", current_combo);
        if(current_combo >= 2)
        {
            combo_img.SetActive(true);
            comboText.gameObject.SetActive(true);
            ani.SetTrigger(key);
        }
    }
}
