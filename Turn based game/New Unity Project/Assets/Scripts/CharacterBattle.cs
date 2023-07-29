using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class CharacterBattle : MonoBehaviour
{
    private State state;
    enum State { Idle, Sliding, Busy}
    Vector3 slideTargetPosition;
    Action onSlideComplete;
    Animator anim;

    Vector3 startingPosition;
    //internal string currentState;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        state = State.Idle;
        startingPosition = transform.position;
    }
    private void Update()
    {
        switch (state)
        {
            case State.Idle:
                break;
            case State.Busy:
                break;
            case State.Sliding:
                transform.position += (slideTargetPosition - transform.position) * 2 * Time.deltaTime;
                
                break;
        }
    }

    void SlideToPosition()
    {
        state = State.Sliding;
    }
    //public IEnumerator Attack(CharacterBattle characterBattle)
    //{
    //    slideTargetPosition = characterBattle.gameObject.transform.position + (transform.position - characterBattle.gameObject.transform.position).normalized * 2f;

    //    //slide to target
    //    SlideToPosition();
    //    //arrived at target, attack him
    //    state = State.Busy;
    //    Debug.Log(gameObject.name + " ATTACKED " + characterBattle.gameObject.name);
    //    anim.Play("Attack");
    //    if (Vector3.Distance(transform.position, slideTargetPosition) < 1f)
    //    {
    //        yield return new WaitForSeconds(3f);
    //    }

    //    //attack completed, slide back
    //    slideTargetPosition = startingPosition;
    //    SlideToPosition();
    //    Debug.Log("SLIDING BACK");
    //    anim.Play("Idle");
    //    state = State.Idle;
    //}
    public void Attack(CharacterBattle characterBattle)
    {
        Debug.Log(gameObject.name + " ATTACKED " + characterBattle.gameObject.name);
    }


    void OnDrawGizmos()
    {
        Handles.Label(transform.position, state.ToString());
    }
    //internal void ChangeStateWithAnimation(State newState)
    //{
    //    if (newState != state)
    //    {
    //        anim.Play(newState.ToString());

    //        State = newState;
    //        Debug.Log(gameObject.name + " CHANGED STATE TO " + newState);
    //    }
    //}
}
