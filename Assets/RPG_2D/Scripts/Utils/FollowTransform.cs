using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        if (target == null)
        {
            return;
        }
        transform.position = target.position;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
