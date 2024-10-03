using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Correct method call
        if (player != null)
        {
            inventory = player.GetComponent<Inventory>(); // Correct syntax for GetComponent
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("player"))
            {
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.isfull[i] == false)
                    {
                        inventory.isfull[i] = true;
                        break;
                    }
                }
            }

        }
    }
}
