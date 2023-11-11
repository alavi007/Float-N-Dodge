using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float speed = -3;
    public Vector3 positionChange = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f * Time.deltaTime * speed, 60.0f * Time.deltaTime * speed, 0f * Time.deltaTime * speed);
        transform.position += positionChange;
    }
}
