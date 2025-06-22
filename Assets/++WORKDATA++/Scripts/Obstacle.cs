using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 pointA, pointB;
    private Vector2 target;

    void Start()
    {
        target = pointB;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if ((Vector2)transform.position == target)
            target = target == pointA ? pointB : pointA;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.LoseGame();
        }
    }
}