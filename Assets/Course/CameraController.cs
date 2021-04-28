using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform characterTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var newPosition = new Vector4(0, characterTransform.position.y + 10, characterTransform.position.z - 10);
        transform.position = newPosition;
    }
}
