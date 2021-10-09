using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;

    private void FixedUpdate()
    {
        transform.position = playerPosition.position + new Vector3(0f,0f,-10f);
    }
}
