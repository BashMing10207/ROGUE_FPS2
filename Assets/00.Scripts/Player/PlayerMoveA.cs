using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveA : MonoBehaviour
{
    public float speed,jumppower,rotspeedx,rotspeedy;
    public LayerMask la;
    public Transform Cameraa;
    public Rigidbody rb;

    RaycastHit _hit;
    Vector3 _moveVector;
    float _roty;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //GameMana.instance.mov = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _moveVector = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))).normalized * speed;
        if(Physics.Raycast(transform.position,Vector3.down,out _hit,1f,la))
        {
            _moveVector = Vector3.ProjectOnPlane(_moveVector, _hit.normal);
        }
        else
        {
            _moveVector += Vector3.up * rb.velocity.y;
        }
        rb.velocity = _moveVector;

        //Cameraa.Rotate(Input.GetAxisRaw("Mouse Y"),0, 0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumppower, ForceMode.Impulse);
        }
        transform.Rotate(0, Input.GetAxisRaw("Mouse X") * rotspeedx * Time.deltaTime, 0);
        _roty += Input.GetAxisRaw("Mouse Y") * rotspeedy * Time.deltaTime;
        Cameraa.localRotation = Quaternion.Euler(_roty, 0, 0);
    }
}
