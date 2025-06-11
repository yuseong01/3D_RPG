using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carmera : MonoBehaviour
{
    [SerializeField] private Transform target;     
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -3); // 위치 오프셋
    [SerializeField] private float followSpeed = 5f;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.LookAt(target); // 항상 대상 바라보기
    }
}
