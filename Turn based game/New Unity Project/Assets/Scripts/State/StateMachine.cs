using UnityEngine;
public abstract class StateMachine : MonoBehaviour
{
    public static State State;
    public void SetState(State state)
    {
        State = state;
        StartCoroutine(State.Start());
        //Debug.Log("NOW ON " + state.ToString() + " STATE");
    }
}
