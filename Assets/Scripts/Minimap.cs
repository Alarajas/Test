using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    public bool isMinimapRotable;

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        if (isMinimapRotable)
        {
            transform.rotation = Quaternion.Euler(90f, 0f, player.eulerAngles.z);
        }
    }
}
