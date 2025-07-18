using UnityEngine;

public abstract class PickupHandler : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 20f;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnPickUp();
            Destroy(gameObject);
        }
    }
    protected abstract void OnPickUp();
}
