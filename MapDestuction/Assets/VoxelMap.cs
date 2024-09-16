using UnityEngine;

public class VoxelMap : MonoBehaviour
{
    public GameObject voxelPrefab; // Verwijs naar je kubus prefab
    public int mapWidth = 10;
    public int mapHeight = 10;
    public int mapDepth = 10;
    public Vector3 mapOffset = Vector3.zero; // Basispositie voor het plaatsen van de map

    private GameObject[,,] voxels; // 3D array om voxels bij te houden

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        voxels = new GameObject[mapWidth, mapHeight, mapDepth];

        // Loop door de dimensies van de map
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int z = 0; z < mapDepth; z++)
                {
                    // Pas de positie aan op basis van de mapOffset
                    Vector3 pos = new Vector3(x, y, z) + mapOffset;
                    voxels[x, y, z] = Instantiate(voxelPrefab, pos, Quaternion.identity);
                }
            }
        }
    }

    // Functie om een voxel te verwijderen
    public void RemoveVoxel(Vector3 position, float radius)
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int z = 0; z < mapDepth; z++)
                {
                    if (voxels[x, y, z] != null)
                    {
                        // Bereken de wereldpositie van de voxel
                        Vector3 voxelPosition = voxels[x, y, z].transform.position;
                        float distance = Vector3.Distance(voxelPosition, position);
                        if (distance < radius)
                        {
                            Destroy(voxels[x, y, z]); // Verwijder de voxel
                            voxels[x, y, z] = null; // Verwijder de referentie uit de array
                        }
                    }
                }
            }
        }
    }
}
