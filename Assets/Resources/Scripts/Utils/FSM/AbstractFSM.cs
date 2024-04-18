using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFSM : MonoBehaviour
{
    protected AbstractStates currentState;
    protected Dictionary<Type, AbstractStates> states = new();

    protected virtual void Update() { currentState?.OnUpdate(); }
    protected virtual void FixedUpdate() { currentState?.OnFixedUpdate(); }
    protected virtual void OnDestroy() { currentState?.OnDestroy(); }
    protected virtual void OnCollisionEnter(Collision collision) { currentState?.OnCollisionEnter(collision); }
    protected virtual void OnCollisionEnter2D(Collision2D collision) { currentState?.OnCollisionEnter2D(collision); }
    public virtual void OnTriggerEnter(Collider other) { currentState?.OnTriggerEnter(other); }
    public virtual void OnTriggerExit(Collider other) { currentState?.OnTriggerExit(other); }
    public virtual void OnTriggerEnter2D(Collider2D other) { currentState?.OnTriggerEnter2D(other); }
    public virtual void OnTriggerExit2D(Collider2D other) { currentState?.OnTriggerExit2D(other); }

    public void AddState(Type t, AbstractStates state)
    {
        if (!states.ContainsKey(t)) states.Add(t, state);
    }
    public void SwitchState(Type t)
    {
        if (!states.ContainsKey(t)) return;
        currentState?.OnExit();
        currentState = states[t];
        currentState.OnEnter();
    }
}