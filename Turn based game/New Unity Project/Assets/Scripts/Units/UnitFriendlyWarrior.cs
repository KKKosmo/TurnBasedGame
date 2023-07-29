using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFriendlyWarrior : UnitFriendly
{
    public int toughenUpTurns = 0;
    public int allInTurns = 0;
    private void OnMouseDown()
    {
        Debug.Log("CLICKED ON MOUSE DOWN");
    }
    public override void TakeDamage(int damage)
    {
        if (allInTurns > 0 && toughenUpTurns > 0)
        {
            damage = (damage - (defence / 2)) / 2;
            //Debug.Log("both");
        }
        else if (allInTurns > 0)
        {
            damage -= defence / 2;
            //Debug.Log("all in");
        }
        else if (toughenUpTurns > 0)
        {
            damage = (damage-defence)/ 2;
            //Debug.Log("toughen up");
        }
        else
        {
            damage -= defence;
            //Debug.Log("none");
        }
        currentHP -= damage;

        //Debug.Log("damage taken was " + damage);
        if (currentHP <= 0)
        {
            isAlive = false;
        }
    }
    public override void DecrementBuffs()
    {
        if (toughenUpTurns > 0)
        {
            toughenUpTurns--;
        }
        if (allInTurns > 0)
        {
            allInTurns--;
        }
        base.DecrementBuffs();
    }
}