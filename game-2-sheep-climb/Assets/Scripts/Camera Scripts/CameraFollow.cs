using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    private float damping = 2f;
    private float height = 10f;

    private Vector3 startPos;

    private bool can_Follow;

    public bool CanFollow
    {
        get
        {
            return can_Follow;
        }
        set
        {
            can_Follow = value;
        }
    }
    void Follow()
    {
        if (can_Follow)
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        startPos = transform.position;
        can_Follow = true;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }
} // class
