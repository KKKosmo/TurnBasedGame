using System.Collections;
using UnityEngine;

internal class EnemyTurn : State
{
    public EnemyTurn(BattleHandler battleHandler) : base(battleHandler)
    {
    }
    public override IEnumerator Start()
    {
        BattleHandler.dialogueText.text = BattleHandler.enemyUnits[0].unitName + " walljump headshotted " + BattleHandler.currentPlayerUnit.unitName;
        yield return new WaitForSeconds(1f);
        BattleHandler.currentPlayerUnit.TakeDamage(BattleHandler.enemyUnits[0].attack);
        BattleHandler.playerHUD.SetHP();
        yield return new WaitForSeconds(1f);
        if (!BattleHandler.currentPlayerUnit.isAlive)
        {
            BattleHandler.selectedUnitEnemy.Die();
            BattleHandler.SetState(new Lost(BattleHandler));
            yield break;
        }
        else
        {
            BattleHandler.SetState(new PlayerTurn(BattleHandler));
            yield break;
        }
    }
}