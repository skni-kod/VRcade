using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaPointGenerator : MonoBehaviour
{
    [SerializeField]
    Vector2 size;

    public Vector3 GetPoint()
    {
        return new Vector3(Random.Range(transform.position.x - (size.x / 2), transform.position.x + (size.x / 2)),
                            Random.Range(transform.position.y - (size.y / 2), transform.position.y + (size.y / 2)), 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(size.x, size.y, 0f));
    }
}
