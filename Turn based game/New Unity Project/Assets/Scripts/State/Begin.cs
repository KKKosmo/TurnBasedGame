using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin : State
{
    public Begin(BattleHandler battleHandler) : base(battleHandler){}
    public override IEnumerator Start()
    {
        BattleHandler.playerUnit = BattleHandler.SpawnCharacterFriendlies();
        BattleHandler.enemyUnits = BattleHandler.SpawnCharacterEnemies();
        BattleHandler.ToggleUnitEnemyButtons(BattleHandler.enemyUnits, false);
        string enemies = "";
        foreach (UnitEnemy unit in BattleHandler.enemyUnits)
        {
            enemies += unit.unitName + " ";
        };
        BattleHandler.dialogueText.text = "GET OUT OF MI GRASSFIELD " + enemies;
        BattleHandler.playerHUD.SetHUD();
        //BattleHandler.enemyHUD.SetHUD(BattleHandler.enemyUnit[0]);

        yield return new WaitForSeconds(2f);

        BattleHandler.SetState(new PlayerTurn(BattleHandler));
    }
}
