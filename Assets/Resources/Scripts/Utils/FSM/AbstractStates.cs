using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractStates
{
    public virtual void OnEnter() { }
    public virtual void OnUpdate() { }
    public virtual void OnFixedUpdate() { }
    public virtual void OnExit() { }
    public virtual void OnDestroy() { }
    public virtual void OnCollisionEnter(Collision collision) { }
    public virtual void OnCollisionEnter2D(Collision2D collision) { }
    public virtual void OnTriggerEnter(Collider other) { }
    public virtual void OnTriggerExit(Collider other) { }
    public virtual void OnTriggerEnter2D(Collider2D other) { }
    public virtual void OnTriggerExit2D(Collider2D other) { }
}