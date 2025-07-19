using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;
    [SerializeField] float adjustMovementSpeed = -1f;
    const string hitString = "Hit";
    float cooldownTimer = 0f;
    LevelGenerator levelGenerator;

    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }
    void Update()
    {
        cooldownTimer+= Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (cooldownTimer < collisionCooldown) return;

        levelGenerator.ChangeMovementSpeed(adjustMovementSpeed);
        animator.SetTrigger(hitString);
        cooldownTimer = 0f;
    }
}
