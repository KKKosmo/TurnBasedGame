using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int attack;
    //public int tempAttack = 0;
    public int defence;
    //public int tempDefence = 0;

    public int maxHP;
    public int currentHP;

    public delegate void Turn();
    public Turn unitTurn;

    public bool isAlive = true;
    protected virtual void Awake()
    {
        currentHP = maxHP;
    }
    public virtual void DecrementBuffs()
    {

    }

    public virtual void TakeDamage(int damage)
    {
        damage -= defence;
        currentHP -= damage;
        if (currentHP <= 0)
        {
            isAlive = false;
        }
    }
    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        //btn.interactable = false;
    }
}
