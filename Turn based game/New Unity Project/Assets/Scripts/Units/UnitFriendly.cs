using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFriendly : Unit
{
    public float xp;
    public float xpLimit;
    protected override void Awake()
    {
        xpLimit = 100;
        base.Awake();
    }


}
