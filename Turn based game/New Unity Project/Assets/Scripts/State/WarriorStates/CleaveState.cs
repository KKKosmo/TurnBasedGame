using System.Collections;
using UnityEngine;
internal class CleaveState : State
{
    UnitFriendlyWarrior unitFriendlyWarrior;
    public CleaveState(BattleHandler battleHandler, UnitFriendlyWarrior unitFriendlyWarrior) : base(battleHandler)
    {
        this.unitFriendlyWarrior = unitFriendlyWarrior;
    }
    public override IEnumerator Start()
    {
        float totalXP = 0;
        if (unitFriendlyWarrior.allInTurns > 0)
        {
            int allInDmg = Random.Range(4, 8);
            Debug.Log("ALLINDMG WAS " + allInDmg);
            Debug.Log("TESTING " + Random.Range(4, 8) + Random.Range(4, 8) + Random.Range(4, 8) + Random.Range(4, 8) + Random.Range(4, 8) + Random.Range(4, 8));
            BattleHandler.dialogueText.text = BattleHandler.currentPlayerUnit.unitName + " used Cleave on all enemies for " + (BattleHandler.currentPlayerUnit.attack + allInDmg) * 2 + " damage.";
            foreach (UnitEnemy unit in BattleHandler.enemyUnits)
            {
                unit.TakeDamage((BattleHandler.currentPlayerUnit.attack + allInDmg) * 2);
                unit.SetHP();
            }
        }
        else
        {
            BattleHandler.dialogueText.text = BattleHandler.currentPlayerUnit.unitName + " used Cleave on all enemies for " + BattleHandler.currentPlayerUnit.attack * 2 + " damage."; foreach (UnitEnemy unit in BattleHandler.enemyUnits)
            {
                unit.TakeDamage(BattleHandler.currentPlayerUnit.attack * 2);
                unit.SetHP();
            }
        }
        BattleHandler.WarriorAttacksHUD.gameObject.SetActive(false);

        
        yield return new WaitForSeconds(2f);
        unitFriendlyWarrior.DecrementBuffs();
        foreach (UnitEnemy unit in BattleHandler.enemyUnits)
        {
            if (!unit.isAlive && unit.gameObject.activeInHierarchy == true)
            {

                unit.Die();
                totalXP += unit.xpReward;
            }
        }
        //float tempXP = BattleHandler.currentPlayerUnit.xp;
        BattleHandler.currentPlayerUnit.xp += totalXP;
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
}