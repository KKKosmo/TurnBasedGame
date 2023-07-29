//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class StatusFriendlyWarrior : Status
//{
//    UnitFriendlyWarrior unitFriendlyWarrior;
//    int durationToughenUp = 0;
//    int durationAllIn = 0;

//    void ApplyToughenUp()
//    {
//        //unitFriendlyWarrior.unitTurn += () => { durationToughenUp--; };
//        unitFriendlyWarrior.unitTurn += ToughenUpDecrement;
//        durationToughenUp += 3;
//    }
//    void RemoveToughenUp()
//    {
//        //unitFriendlyWarrior.unitTurn -= () => { durationToughenUp--; };
//        unitFriendlyWarrior.unitTurn -= ToughenUpDecrement;
//    }
//    void ToughenUpDecrement()
//    {
//        durationToughenUp--;
//    }
//}
