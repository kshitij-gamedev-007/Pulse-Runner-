using UnityEngine;

public class Coin : PickupHandler
{
    protected override void OnPickUp()
    {
        Debug.Log("Add 1000 to coins");
    }
}
