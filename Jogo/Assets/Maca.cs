using System.Collections;


using System.Collections.Generic;


using UnityEngine;

public class SpawnApple : MonoBehaviour


{


    public Collider2D gridArea;

    private SnakeMove snake;

    private void Awake()


    {


        snake = FindObjectOfType<SnakeMove>();


    }

    private void Start()


    {


        RandomizePosition();


    }

    public void RandomizePosition()


    {


        Bounds bounds = gridArea.bounds;




        int x = Mathf.RoundToInt(Random.Range(bounds.min.x, bounds.max.x));


        int y = Mathf.RoundToInt(Random.Range(bounds.min.y, bounds.max.y));




    }

}

 


