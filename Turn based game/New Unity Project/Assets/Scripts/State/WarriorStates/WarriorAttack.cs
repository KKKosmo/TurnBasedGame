using System;
using System.Collections;
using UnityEngine;

internal class WarriorAttack : State
{
    UnitFriendlyWarrior unitFriendlyWarrior;
    public WarriorAttack(BattleHandler battleHandler) : base(battleHandler)
    {
    }
    public override IEnumerator Start()
    {
        unitFriendlyWarrior = BattleHandler.currentPlayerUnit.gameObject.GetComponent<UnitFriendlyWarrior>();
        BattleHandler.defaultCanvasHUD.gameObject.SetActive(false);
        BattleHandler.dialogueText.text = "Choose an attack: ";
        BattleHandler.WarriorAttacksHUD.gameObject.SetActive(true);
        yield break;
    }
    public override IEnumerator BladeStrike()
    {
        if (BattleHandler.selectedUnitEnemy == null)
        {
            BattleHandler.SetState(new SelectTarget(BattleHandler, () => {
                BattleHandler.SetState(new BladeStrikeState(BattleHandler, unitFriendlyWarrior));
            }, "Blade Strike"));
        }
        yield break;
    }
    public override IEnumerator Cleave()
    {
        if (BattleHandler.selectedUnitEnemy == null)
        {
            BattleHandler.SetState(new SelectTarget(BattleHandler, () => {
                BattleHandler.SetState(new CleaveState(BattleHandler, unitFriendlyWarrior));
            }, "Cleave"));
        }
        yield break;
    }
    public override IEnumerator ToughenUp()
    {
        BattleHandler.SetState(new ToughenUpState(BattleHandler, unitFriendlyWarrior));
        yield break;
    }
    public override IEnumerator AllIn()
    {
        BattleHandler.SetState(new AllInState(BattleHandler, unitFriendlyWarrior));
        yield break;
    }
}