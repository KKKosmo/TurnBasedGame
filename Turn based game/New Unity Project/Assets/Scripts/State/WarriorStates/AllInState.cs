using System.Collections;
using UnityEngine;

internal class AllInState : State
{
    UnitFriendlyWarrior unitFriendlyWarrior;
    public AllInState(BattleHandler battleHandler, UnitFriendlyWarrior unitFriendlyWarrior) : base(battleHandler)
    {
        this.unitFriendlyWarrior = unitFriendlyWarrior;
    }
    public override IEnumerator Start()
    {
        unitFriendlyWarrior.allInTurns += 3;
        BattleHandler.dialogueText.text = BattleHandler.currentPlayerUnit.unitName + " used All In!, " + BattleHandler.currentPlayerUnit.unitName + " traded half of his defence for more dmg for 3 turns";
        BattleHandler.WarriorAttacksHUD.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        unitFriendlyWarrior.DecrementBuffs();
        unitFriendlyWarrior.allInTurns++;
        BattleHandler.SetState(new EnemyTurn(BattleHandler));
        yield break;
    }
}