using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    private Transform player;
    public float height = 6f;
    public float undergroundHeight = -11f;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    private void LateUpdate()
    {
        Vector3 cameraPositon = transform.position; 
        cameraPositon.x = Mathf.Max(cameraPositon.x, player.position.x);
        transform.position = cameraPositon;
    }
    public void SetUnderground(bool underground)
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.y = underground ? undergroundHeight : height;
        transform.position = cameraPosition;
    }
}
