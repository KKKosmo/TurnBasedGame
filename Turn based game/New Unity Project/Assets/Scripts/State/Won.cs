using System.Collections;

internal class Won : State
{
    public Won(BattleHandler battleHandler) : base(battleHandler)
    {
    }
    public override IEnumerator Start()
    {
        BattleHandler.dialogueText.text = "You won the battle!";
        yield break;
    }
}