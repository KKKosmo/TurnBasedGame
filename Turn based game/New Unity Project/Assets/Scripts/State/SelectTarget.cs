using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

internal class SelectTarget : State
{
    Action afterClick;
    string special;
    public SelectTarget(BattleHandler battleHandler, Action afterClick, string special) : base(battleHandler)
    {
        this.afterClick = afterClick;
        this.special = special;
    }
    public override IEnumerator Start()
    {
        BattleHandler.dialogueText.text = "Select a target to use " + special + " on";
        BattleHandler.ToggleUnitEnemyButtons(BattleHandler.enemyUnits, true);
        yield break;
    }
    public override IEnumerator selectUnit(UnitEnemy unit)
    {

        //Debug.Log("DEBUG ON SELECT TARGET");
        BattleHandler.selectedUnitEnemy = unit;
        if (BattleHandler.selectedUnitEnemy == null)
        {
            Debug.Log("SELECT TARGET UNIT == NULL");
        }
        else
        {
            //Debug.Log("SELECT TARGET UNIT != NULL");

            if (afterClick == null)
            {
                Debug.Log("after click = null");
            }
            else
            {
                BattleHandler.ToggleUnitEnemyButtons(BattleHandler.enemyUnits, false);
                afterClick();
            }
        }

        yield break;
    }
}