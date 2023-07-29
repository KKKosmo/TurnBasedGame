using System.Collections;
using UnityEngine;

internal class ToughenUpState : State
{
    UnitFriendlyWarrior unitFriendlyWarrior;
    public ToughenUpState(BattleHandler battleHandler, UnitFriendlyWarrior unitFriendlyWarrior) : base(battleHandler)
    {
        this.unitFriendlyWarrior = unitFriendlyWarrior;
    }
    public override IEnumerator Start()
    {
        unitFriendlyWarrior.toughenUpTurns += 2;
        BattleHandler.dialogueText.text = BattleHandler.currentPlayerUnit.unitName + " used Toughen Up!, " + BattleHandler.currentPlayerUnit.unitName + " will block half of the damage for the next 2 turns.";
        BattleHandler.WarriorAttacksHUD.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        unitFriendlyWarrior.DecrementBuffs();
        unitFriendlyWarrior.toughenUpTurns++;
        BattleHandler.SetState(new EnemyTurn(BattleHandler));
        yield break;
    }
}