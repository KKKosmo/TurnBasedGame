using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{

	public Text nameText;
	public Text levelText;
	public Text hpText;
	public Slider hpSlider;
	public UnitFriendly unitFriendly;

	public void SetHUD()
	{
		nameText.text = unitFriendly.unitName;
		levelText.text = "Lvl " + unitFriendly.unitLevel;
		hpSlider.maxValue = unitFriendly.maxHP;
		hpSlider.value = unitFriendly.currentHP;
		hpText.text = "HP " + unitFriendly.maxHP + "/" + unitFriendly.maxHP;
	}

	public void SetHP()
	{
		hpText.text = "HP " + unitFriendly.currentHP + "/" + unitFriendly.maxHP;
		hpSlider.value = unitFriendly.currentHP;
	}
	public void SetLV()
    {
		levelText.text = "Lvl " + unitFriendly.unitLevel;
	}
}
