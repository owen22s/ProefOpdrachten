using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;  // The projectile prefab
    public Transform shootPoint;         // The point from which the projectile is shot
    public float projectileSpeed = 20f;  // Speed of the projectile
    public float fireRate = 0.2f;        // Rate of fire

    private float nextTimeToFire = 0f;   // Time when the player can shoot again

    void Update()
    {
        // Check if the left mouse button is pressed and the fire rate is met
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        if (projectilePrefab == null)
        {
            Debug.LogError("Projectile Prefab is not assigned!");
            return;
        }

        if (shootPoint == null)
        {
            Debug.LogError("Shoot Point is not assigned!");
            return;
        }

        // Instantiate the projectile at the shoot point with the same rotation as the player
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

        // Ensure the projectile has a Rigidbody component
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("The projectile prefab does not have a Rigidbody component!");
            return;
        }

        // Add forward velocity to the projectile
        rb.velocity = shootPoint.forward * projectileSpeed;
    }
}
