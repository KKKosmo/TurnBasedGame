using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitEnemy : Unit
{
    public float xpReward;
    public GameObject HUD;
    public Button btn;

    public Text nameText;
    public Text levelText;
    public Slider hpSlider;
    public Text hpText;

    private void Start()
    {
        //btn = GetComponent<Button>();
        btn.onClick.AddListener(OnUnitClick);
    }
    public void OnUnitClick()
    {
        StartCoroutine(BattleHandler.State.selectUnit(GetComponent<UnitEnemy>()));
    }
    public void FlipHUD()
    {
        HUD.transform.localPosition = new Vector3(-HUD.transform.localPosition.x, HUD.transform.localPosition.y);
        HUD.transform.localScale = new Vector3(-HUD.transform.localScale.x, HUD.transform.localScale.y, HUD.transform.localScale.z);
    }
    public void SetHUD()
    {
        nameText.text = unitName;
        levelText.text = unitLevel.ToString();
        hpSlider.maxValue = maxHP;
        hpSlider.value = currentHP;
        hpText.text = currentHP + "/" + maxHP;
    }
    public void SetHP()
    {
        hpSlider.value = currentHP;
        if (currentHP < 0)
        {
            hpText.text = "0/" + maxHP;
        }
        else
        {
            hpText.text = currentHP + "/" + maxHP;
        }
    }
    public void SetLV(Unit unit)
    {
        levelText.text = "Lvl " + unit.unitLevel;
    }
}
