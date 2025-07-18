using UnityEngine;

public class Apple : PickupHandler
{
    LevelGenerator levelGenerator;
    [SerializeField] float adjustMovementSpeed = 2f;
    private void Start() {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }
    protected override void OnPickUp()
    {
        levelGenerator.ChangeMovementSpeed(adjustMovementSpeed);
    }
}
