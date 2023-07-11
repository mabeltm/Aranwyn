using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform unit;
    private Rigidbody2D rigbodyRB;
    private Animator anim;
    private Transform currentPoint;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigbodyRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPoint == pointB.transform) {
            rigbodyRB.velocity = new Vector2(speed, 0);
        }
        else {
            rigbodyRB.velocity = new Vector2(-speed, 0);
        }

        float x = unit.transform.position.x;
        print(currentPoint.position.x - x );
        if (currentPoint.position.x - x < 1.6f && currentPoint == pointB.transform) {

            currentPoint = pointA.transform;
        }
        if (currentPoint.position.x - x  > 1.6f && currentPoint == pointA.transform) {
            currentPoint = pointB.transform;
        }
    }
}
