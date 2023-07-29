using System;
using System.Collections;
using UnityEngine;

public abstract class State
{
    protected BattleHandler BattleHandler;

    public State(BattleHandler battleHandler)
    {
        BattleHandler = battleHandler;
    }
    public virtual IEnumerator selectUnit(UnitEnemy unit)
    {
        yield break;
    }
    public virtual IEnumerator Start()
    {
        yield break;
    }
    public virtual IEnumerator Attack()
    {
        yield break;
    }
    public virtual IEnumerator Heal()
    {
        yield break;
    }
    public virtual IEnumerator BladeStrike()
    {
        yield break;
    }
    public virtual IEnumerator Cleave()
    {
        yield break;
    }
    public virtual IEnumerator ToughenUp()
    {
        yield break;
    }
    public virtual IEnumerator AllIn()
    {
        yield break;
    }
}