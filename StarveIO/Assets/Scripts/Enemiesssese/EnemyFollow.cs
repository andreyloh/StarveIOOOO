using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject triggerObj;
    public float speed;
    public float speedRotation;
    private Transform player;
    private float turnFloat;
    public bool shouldTurn;
    public bool isTurning;
    private float tudaSuda;//влево вправо

    private float wasZ;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        
    }

    private void turnAround()
    {   


        
    }
}
