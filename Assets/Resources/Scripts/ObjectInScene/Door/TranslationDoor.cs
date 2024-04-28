using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationDoor : TransformDoor
{
    [SerializeField] private bool x;
    [SerializeField] private bool y;
    protected override void AdjustAxis()
    {
        if (x) centerDistance.x = -centerDistance.x;
        if (y) centerDistance.y = -centerDistance.y;
    }
}
