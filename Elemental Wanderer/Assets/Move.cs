using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Range(-1, 1)]
    public float delta_x;

    [Range(0, 2 * Mathf.PI)]
    public float phi;

    // Start is called before the first frame update
    void Start()
    {
        delta_x = .3f;
        phi = 2 * Mathf.PI / 20;
        Debug.Log("began");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 7.3 || transform.position.x < -7.3)
            delta_x *= -1;
        
        transform.Translate(delta_x, 0, 0);
        transform.Rotate(new Vector3(phi, 0, 0));
        Debug.Log(transform.position.x + ", " + transform.position.y + ", " + transform.position.z);
    }
}
