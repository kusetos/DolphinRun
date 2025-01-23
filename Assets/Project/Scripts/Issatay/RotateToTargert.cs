using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTargert : MonoBehaviour
{
    [SerializeField]
    public float _rotationSpeed;
    [SerializeField]
    private float _moveSpeed;

    private Vector2 _direction;
    void Update()
    {
        _direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(_direction.y, _direction. x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform. rotation = Quaternion.Slerp(
                                transform.rotation,
                                rotation,
                                _rotationSpeed * Time. deltaTime);

        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(
                                    transform.position,
                                    cursorPos,
                                    _moveSpeed * Time.deltaTime);

    }

}