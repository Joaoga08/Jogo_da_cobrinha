using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    public GameObject snakeSegmentPrefab;
    public float moveSpeed = 1f;
    private Vector2 direction;
    private List<Transform> segments = new List<Transform>();
    private float timer;

    void Start()
    {
        segments.Add(transform);    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            direction = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            direction = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            direction = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            direction = Vector2.right;


        timer += Time.deltaTime;
        if (timer >= moveSpeed)
        {
            Move();
            timer = 0;
        }
    }

    void Move()
    {
        Vector3 previousPosition = transform.position;
        // Move a cabe�a da cobra
        transform.position += (Vector3)direction;

        // Move a cauda
        for (int i = 1; i < segments.Count; i++)
        {
            Vector3 tempPosition = segments[i].position;
            segments[i].position = previousPosition;
            previousPosition = tempPosition;
        }
        // Checa colis�o com a cauda
        for (int i = 1; i < segments.Count; i++)
        {
            if (transform.position == segments[i].position)
            {
                GameOver();
            }
        }

    }

    public void Grow()
{
    // Cria um novo segmento da cobra
    GameObject segment = Instantiate(snakeSegmentPrefab);
    segment.transform.position = segments[segments.Count - 1].position; // Posiciona na �ltima cauda
    segments.Add(segment.transform); // Adiciona o novo segmento � lista
}
void GameOver()
{
}
private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Apple"))
    {
        Grow();
        Destroy(collision.gameObject); 
    }
}

}
