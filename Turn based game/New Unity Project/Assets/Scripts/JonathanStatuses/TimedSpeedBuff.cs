//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TimedSpeedBuff : TimedBuff
//{
//    private readonly MovementComponent _movementComponent;

//    public TimedSpeedBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
//    {
//        //Getting MovementComponent, replace with your own implementation
//        _movementComponent = obj.GetComponent();
//    }

//    protected override void ApplyEffect()
//    {
//        //Add speed increase to MovementComponent
//        ScriptableSpeedBuff speedBuff = (ScriptableSpeedBuff)Buff;
//        _movementComponent.MovementSpeed += speedBuff.SpeedIncrease;
//    }

//    public override void End()
//    {
//        //Revert speed increase
//        ScriptableSpeedBuff speedBuff = (ScriptableSpeedBuff)Buff;
//        _movementComponent.MovementSpeed -= speedBuff.SpeedIncrease * EffectStacks;
//        EffectStacks = 0;
//    }
//}