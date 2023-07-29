
using System.Collections;
using UnityEngine;

internal class BladeStrikeState : State
{
    UnitFriendlyWarrior unitFriendlyWarrior;
    public BladeStrikeState(BattleHandler battleHandler, UnitFriendlyWarrior unitFriendlyWarrior) : base(battleHandler)
    {
        this.unitFriendlyWarrior = unitFriendlyWarrior;
    }
    public override IEnumerator Start()
    {
        //Debug.Log("TESTING " + Random.Range(4, 8) + Random.Range(4, 8) + Random.Range(4, 8) + Random.Range(4, 8) + Random.Range(4, 8) + Random.Range(4, 8) + Random.Range(4, 8) + Random.Range(4, 8) + Random.Range(4, 8) + Random.Range(4, 8) + Random.Range(4, 8)); 
        if (unitFriendlyWarrior.allInTurns > 0)
        {
            int allInDmg = Random.Range(4, 8);
            Debug.Log("RANDOM RANGE WAS " + allInDmg);
            BattleHandler.selectedUnitEnemy.TakeDamage((BattleHandler.currentPlayerUnit.attack + allInDmg) * 3);
            BattleHandler.dialogueText.text = BattleHandler.currentPlayerUnit.unitName + " used Blade Strike on " + BattleHandler.selectedUnitEnemy.unitName + " for " + (BattleHandler.currentPlayerUnit.attack + allInDmg) * 3 + " damage.";
        }
        else
        {
            BattleHandler.selectedUnitEnemy.TakeDamage(BattleHandler.currentPlayerUnit.attack * 3);
            BattleHandler.dialogueText.text = BattleHandler.currentPlayerUnit.unitName + " used Blade Strike on " + BattleHandler.selectedUnitEnemy.unitName + " for " + BattleHandler.currentPlayerUnit.attack * 3 + " damage.";
        }
        BattleHandler.selectedUnitEnemy.SetHP();
        BattleHandler.WarriorAttacksHUD.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        unitFriendlyWarrior.DecrementBuffs();
        if (!BattleHandler.selectedUnitEnemy.isAlive)
        {
            BattleHandler.selectedUnitEnemy.Die();
            BattleHandler.currentPlayerUnit.xp += BattleHandler.selectedUnitEnemy.xpReward;
            if (BattleHandler.currentPlayerUnit.xp >= BattleHandler.currentPlayerUnit.xpLimit)
            {
                BattleHandler.SetState(new LevelUP(BattleHandler, BattleHandler.currentPlayerUnit.xp));
                BattleHandler.selectedUnitEnemy = null;
                yield break;
            }
            else if (BattleHandler.AnEnemyStillAlive())
            {
                BattleHandler.SetState(new EnemyTurn(BattleHandler));
                BattleHandler.selectedUnitEnemy = null;
                yield break;
            }
            else
            {
                BattleHandler.SetState(new Won(BattleHandler));
                BattleHandler.selectedUnitEnemy = null;
                yield break;
            }
        }
        else
        {
            BattleHandler.SetState(new EnemyTurn(BattleHandler));
            BattleHandler.selectedUnitEnemy = null;
            yield break;
        }
    }
}