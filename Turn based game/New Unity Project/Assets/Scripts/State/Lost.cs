using System.Collections;

internal class Lost : State
{
    public Lost(BattleHandler battleHandler) : base(battleHandler)
    {
    }
    public override IEnumerator Start()
    {
        BattleHandler.dialogueText.text = "You were defeated.";
        yield break;
    }
}