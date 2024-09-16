using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] private Transform[] startingPositions;
    [SerializeField] private GameObject[] Rooms;
    private int direction;
    [SerializeField] private float moveAmount;
    [SerializeField] private float timebtwroom;
    [SerializeField] private float startTimeBtwRoom = 0.12f;
    private void Start()
    {
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;
        Instantiate(Rooms[0], transform.position, Quaternion.identity);
        direction = Random.Range(1, 6);
    }
    private void Update()
    {
        if (timebtwroom <= 0)
        {
            Move();
            timebtwroom = startTimeBtwRoom;
        }
        else
        {
            timebtwroom -= Time.deltaTime;
        }
    }
    private void Move()
    {
        if (direction == 1 || direction == 2)
        {

            Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
            transform.position = newPos;
        }
        if (direction == 3 || direction == 4)
        {

            Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
            transform.position = newPos;
        }
        if (direction == 5)
        {
            Vector2 newPos = new Vector2(transform.position.y - moveAmount, transform.position.x);
            transform.position = newPos;
        }
    }
}
