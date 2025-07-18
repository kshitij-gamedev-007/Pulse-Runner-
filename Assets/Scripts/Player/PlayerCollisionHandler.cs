using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f; 
    const string hitString = "Hit";
    float cooldownTimer = 0f;
    void Update()
    {
        cooldownTimer+= Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (cooldownTimer < collisionCooldown) return; 

            animator.SetTrigger(hitString);
            cooldownTimer = 0f;
    }
}
