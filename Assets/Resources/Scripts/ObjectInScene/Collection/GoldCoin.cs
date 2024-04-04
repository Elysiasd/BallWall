using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class GoldCoin : BaseCollection
{
    protected override string colName => CollectionName.Money;

    protected override void Start()
    {
        base.Start();
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("1234");
        base.OnTriggerEnter2D(other);
    }
}
