using System.Collections;
using UnityEngine;

internal class LevelUP : State
{
    float xpRemaining;
    public LevelUP(BattleHandler battleHandler, float xpRemaining) : base(battleHandler)
    {
        this.xpRemaining = xpRemaining;
    }
    public override IEnumerator Start()
    {
        xpRemaining -= BattleHandler.currentPlayerUnit.xpLimit;
        BattleHandler.dialogueText.text = BattleHandler.currentPlayerUnit.unitName + " Leveled up!";
        BattleHandler.currentPlayerUnit.unitLevel += 1;
        BattleHandler.currentPlayerUnit.xp = xpRemaining;
        BattleHandler.currentPlayerUnit.xpLimit *= 1.5f;
        BattleHandler.currentPlayerUnit.attack += 3;
        BattleHandler.currentPlayerUnit.defence += 5;
        BattleHandler.playerHUD.SetLV();
        if (BattleHandler.currentPlayerUnit.unitLevel != 3 && BattleHandler.currentPlayerUnit.unitLevel != 5 && BattleHandler.currentPlayerUnit.unitLevel != 7)
        {
            //Debug.Log("NO MILESTONE, LEVEL IS " + BattleHandler.currentPlayerUnit.unitLevel);
        }
        else if (BattleHandler.currentPlayerUnit.unitLevel == 3)
        {
            //Debug.Log(BattleHandler.currentPlayerUnit.unitName + " IS NOW LEVEL 3!, UNLOCKED 2ND ATTACK");
            BattleHandler.attackButtons[1].interactable = true;
        }
        else if (BattleHandler.currentPlayerUnit.unitLevel == 5)
        {
            //Debug.Log(BattleHandler.currentPlayerUnit.unitName + " IS NOW LEVEL 5!, UNLOCKED 3RD ATTACK");
            BattleHandler.attackButtons[2].interactable = true;
        }
        else if (BattleHandler.currentPlayerUnit.unitLevel == 7)
        {
            //Debug.Log(BattleHandler.currentPlayerUnit.unitName + " IS NOW LEVEL 7!, UNLOCKED 4TH ATTACK");
            BattleHandler.attackButtons[3].interactable = true;
        }
        yield return new WaitForSeconds(2f);
        BattleHandler.dialogueText.text = BattleHandler.currentPlayerUnit.unitName + " Is now level " + BattleHandler.currentPlayerUnit.unitLevel;
        yield return new WaitForSeconds(2f);
        if (xpRemaining >= BattleHandler.currentPlayerUnit.xpLimit)
        {
            BattleHandler.SetState(new LevelUP(BattleHandler, xpRemaining));
            yield break;
        }
        if (BattleHandler.AnEnemyStillAlive())
        {
            BattleHandler.SetState(new EnemyTurn(BattleHandler));
            yield break;
        }
        else
        {
            BattleHandler.SetState(new Won(BattleHandler));
            yield break;
        }
    }
}