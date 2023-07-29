using System.Collections;
using UnityEngine;

internal class PlayerTurn : State
{
    public PlayerTurn(BattleHandler battleHandler) : base(battleHandler)
    {
    }
    public override IEnumerator Start()
    {
        BattleHandler.dialogueText.text = "Choose an action: ";
        BattleHandler.defaultCanvasHUD.gameObject.SetActive(true);
        yield break;
    }
    public override IEnumerator Attack()
    {
        BattleHandler.SetState(new WarriorAttack(BattleHandler));
        yield break;
    }
    
    public override IEnumerator Heal()
    {
        BattleHandler.currentPlayerUnit.Heal(5);
        BattleHandler.playerHUD.SetHP();
        BattleHandler.dialogueText.text = BattleHandler.currentPlayerUnit.unitName + " healed for 5 hp";
        yield return new WaitForSeconds(2f);
        BattleHandler.SetState(new EnemyTurn(BattleHandler));
    }
}