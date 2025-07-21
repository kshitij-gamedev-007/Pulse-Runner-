using UnityEngine;

public class Apple : PickupHandler
{
    LevelGenerator levelGenerator;
    [SerializeField] float adjustMovementSpeed = 2f;
    public void Init(LevelGenerator levelGenerator) {
        this.levelGenerator = levelGenerator;
    }
    protected override void OnPickUp()
    {
        levelGenerator.ChangeMovementSpeed(adjustMovementSpeed);
    }
}
