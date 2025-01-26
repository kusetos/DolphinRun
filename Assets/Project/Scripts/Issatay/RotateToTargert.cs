using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTargert : MonoBehaviour
{
    [SerializeField]
    public float _rotationSpeed;
    [SerializeField]
    private float _moveSpeed;     
    [SerializeField]
    private float _bubbleImpactSpeed;   
     [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private Transform _visual;

    private Vector2 _direction;
    private Vector2 m_Input;
    void Update()
    {
        //Debug.Log(m_Input);

        _direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(_direction.y, _direction. x)* Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        _visual.transform.rotation = Quaternion.Slerp(
                                _visual.transform.rotation,
                                rotation,
                                _rotationSpeed * Time. deltaTime);

        m_Input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }
    private void FixedUpdate()
    {
        Vector2 targetVelocity = m_Input * _moveSpeed;
        _rb.velocity = Vector2.Lerp(_rb.velocity, targetVelocity, 0.1f); 
        if(Input.GetMouseButton(0))
        {
            BubbleImpact();
        }

    }

    private void BubbleImpact()
    {
        SoundManager.Instance.PlaySound2D("1");
        _rb.AddForce(-(_direction * _bubbleImpactSpeed));
    }
}