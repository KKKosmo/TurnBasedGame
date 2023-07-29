using UnityEngine;
using UnityEngine.UI;

public class BattleHandler : StateMachine
{
    [SerializeField] GameObject[] characterFriendly;
    [SerializeField] GameObject[] characterEnemy;
    [HideInInspector] public UnitFriendly[] playerUnit;
    [HideInInspector] public UnitEnemy[] enemyUnits;
    public UnitEnemy selectedUnitEnemy;
    public UnitFriendly currentPlayerUnit;

    public Text dialogueText;
    public BattleHUD playerHUD;
    public Canvas defaultCanvasHUD;
    public Canvas WarriorAttacksHUD;
    public Button[] attackButtons = new Button[4];

    public Transform enemySpacer;

    private void Start()
    {
        SetState(new Begin(this));
    }
    
    

    public UnitFriendly[] SpawnCharacterFriendlies()
    {
        Vector3 rotation = new Vector3(0, 0);
        UnitFriendly[] unitFriendly = new UnitFriendly[0];
        switch (characterFriendly.Length)
        {
            case 1:
                unitFriendly = new UnitFriendly[1];
                unitFriendly[0] = Instantiate(characterFriendly[0], new Vector3(-5, 0), Quaternion.Euler(rotation)).GetComponent<UnitFriendly>();
                break;
            case 2:
                unitFriendly = new UnitFriendly[2];
                unitFriendly[0] = Instantiate(characterFriendly[0], new Vector3(-5, 1), Quaternion.Euler(rotation)).GetComponent<UnitFriendly>();
                unitFriendly[1] = Instantiate(characterFriendly[1], new Vector3(-5, -1), Quaternion.Euler(rotation)).GetComponent<UnitFriendly>();
                break;
            case 3:
                unitFriendly = new UnitFriendly[3];
                unitFriendly[0] = Instantiate(characterFriendly[0], new Vector3(-5, 0), Quaternion.Euler(rotation)).GetComponent<UnitFriendly>();
                unitFriendly[1] = Instantiate(characterFriendly[1], new Vector3(-5, 2), Quaternion.Euler(rotation)).GetComponent<UnitFriendly>();
                unitFriendly[2] = Instantiate(characterFriendly[2], new Vector3(-5, -2), Quaternion.Euler(rotation)).GetComponent<UnitFriendly>();
                break;
        }
        currentPlayerUnit = unitFriendly[0];
        playerHUD.unitFriendly = unitFriendly[0];
        return unitFriendly;
    }
    public UnitEnemy[] SpawnCharacterEnemies()
    {
        Vector3 scale = new Vector3(-1, 1, 1);
        UnitEnemy[] unitEnemy;
        unitEnemy = new UnitEnemy[characterEnemy.Length];
        for (int i = 0; i < characterEnemy.Length; i++){
            unitEnemy[i] = Instantiate(characterEnemy[i], enemySpacer.position, Quaternion.identity, enemySpacer).GetComponent<UnitEnemy>();
            unitEnemy[i].gameObject.transform.localScale = scale;
            unitEnemy[i].SetHUD();
            unitEnemy[i].FlipHUD();

        }
        return unitEnemy;
    }

    public bool AnEnemyStillAlive()
    {
        foreach (UnitEnemy enemyUnit in enemyUnits)
        {
            if (enemyUnit.isAlive)
            {
                return true;
            }
        }
        return false;
    }
    public void ToggleUnitEnemyButtons(UnitEnemy[] unitEnemy, bool boolean)
    {
        for (int i = 0; i < characterEnemy.Length; i++)
        {
            if (unitEnemy[i].isAlive)
            {
                unitEnemy[i].btn.enabled = boolean;
            }
        }
    }
    public void OnAttackButton()
    {
        StartCoroutine(State.Attack());
    }
    public void OnHealButton()
    {
        StartCoroutine(State.Heal());
    }
    public void OnBladeStrikeButton()
    {
        StartCoroutine(State.BladeStrike());
    }
    public void OnCleaveButton()
    {
        StartCoroutine(State.Cleave());
    }
    public void OnToughenUpButton()
    {
        StartCoroutine(State.ToughenUp());
    }
    public void OnAllInButton()
    {
        StartCoroutine(State.AllIn());
    }
}