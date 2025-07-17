using UnityEngine;

public class PickupHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {  
            Debug.Log(this.gameObject.name);
        }
    }
}
