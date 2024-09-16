using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject impactEffect;    // Optioneel: Een explosie-effect prefab
    public float explosionRadius = 3f; // Straal van de explosie

    private VoxelMap voxelMap;         // Verwijzing naar het voxelmap-script

    void Start()
    {
        // Zoek naar het VoxelMap script in de scene
        voxelMap = FindObjectOfType<VoxelMap>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Optioneel: Maak een impacteffect aan wanneer het projectiel iets raakt
        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
        }

        // Roep de functie aan om voxels te verwijderen in de voxelmap
        if (voxelMap != null)
        {
            voxelMap.RemoveVoxel(transform.position, explosionRadius);
        }

        // Vernietig het projectiel na impact
        Destroy(gameObject);
    }
}
