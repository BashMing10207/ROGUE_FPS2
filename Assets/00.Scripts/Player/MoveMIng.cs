using UnityEngine;

public class MoveMIng : MonoBehaviour
{
    public float speed, maxspeed, jumppower, rotspeedx, rotspeedy, gravity, maxdeg = 45, airSpeed = 1.5f, airMax = 1.5f,dash=5,speedMulti=1,speedTime,
        sphereCastRadius = 0.5f,sphereCastDis=0.5f,slidingSp=3,SLBPMMULTI=1;
    public LayerMask GroundLa,WallLa;
    public Transform Cameraa;
    public Rigidbody rb;
    RaycastHit _hit;
    Vector3 _moveVector,_InputVector;
    float _roty,_dash;
    public bool _isGrounded = false,_isSlide=false;
    Vector3 _boxsize = new Vector3(0.5f, 0.2f, 0.5f);
    Collider[] _collider = new Collider[1];
    public GameObject SLiding;
    public AudioSource SlidingSound;
    public Collider[] Colliders;

    // Start is called before the first frame update
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        GameMana.instance.mov = this;
    }

    private void Start()
    {
        GameMana.instance.skill.originAction[(int)ActionType.Jump].AddListener(Jump);
        GameMana.instance.skill.originAction[(int)ActionType.Dash].AddListener(Dash);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(speedMulti > 1)
        {
            if(speedTime >= 0)
            {
                speedTime -= Time.fixedDeltaTime;
            }
            else
            {
                speedMulti = 1;
            }
        }

        Vector3 ming = rb.velocity;

        if (Physics.SphereCast(transform.position, 0.4f,Vector3.down, out _hit, 0.7f, GroundLa))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }

        _isSlide = false;

        if (!Input.GetKey(KeyCode.LeftControl))
        {
            _InputVector = transform.TransformVector(new Vector3(Input.GetAxisRaw("Horizontal") * 1.5f, 0, Input.GetAxisRaw("Vertical")));
            if (_isGrounded)
            {
                _moveVector = _InputVector - (ming / maxspeed);
                _moveVector = Vector3.ProjectOnPlane(_moveVector, _hit.normal) * speed;
            }
            else
            {
                _moveVector = (_InputVector - (ming / (maxspeed * airMax * speedMulti))) * speed * airSpeed;
                _moveVector += Vector3.up * -gravity;
                //_moveVector = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal") - ming.x / 2/maxspeed, 0, Input.GetAxis("Vertical") - ming.z/2/maxspeed)).normalized * speed;

            }

        }
        else
        {
                _isSlide = true;
        }
        SlidingSound.mute = !_isSlide;
        SLiding.SetActive(_isSlide);
        if (_isSlide)
        {
            GameMana.instance.songMana.BPMMULTI = SLBPMMULTI;
            if (_isGrounded)
            {
                if(!Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
                {
                    _InputVector = transform.forward;
                }
            _moveVector = (_InputVector - (ming / (maxspeed * slidingSp * speedMulti))) * speed * 0.7f;

            }
            else
            {
                _moveVector += Vector3.up * -gravity/2;   
            }
                GameMana.instance.maincam.transform.localPosition = Vector3.zero;
            SLiding.transform.forward = _moveVector;
            Colliders[0].enabled = false;
            Colliders[1].enabled = true;
        }
        else
        {
            GameMana.instance.songMana.BPMMULTI = 1;
            GameMana.instance.maincam.transform.localPosition = Vector3.up;
            Colliders[0].enabled = true;
            Colliders[1].enabled = false;
        }

        rb.AddForce(_moveVector);

        if (_dash > 2)
        {
            _dash -= _dash / 4f;
            //rb.AddForce(transform.TransformVector(new Vector3(Input.GetAxisRaw("Horizontal") * 1.5f, 0, Input.GetAxisRaw("Vertical")))
            //    * _dash, ForceMode.VelocityChange);
            rb.velocity = transform.TransformVector(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical") * 1.2f))
                * _dash;
        }
    }

    private void Update()
    {
        Rot();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            GameMana.instance.skill.originAction[(int)ActionType.Jump].Invoke(new SkillData(ActionType.Jump,transform,2));
            print(GameMana.instance.skill.originAction[(int)ActionType.Jump].GetPersistentEventCount());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameMana.instance.skill.originAction[(int)ActionType.Dash].Invoke(new SkillData(ActionType.Dash, transform, 2));
        }

        if(transform.position.y < -35)
        {
            transform.position = new Vector3(15, 35, 15);
        }
    }

    void Dash(SkillData actionType)
    {
        _dash = dash;
    }
    void Jump(SkillData actionType)
    {
        if (Vector3.Angle(transform.up, _hit.normal) > maxdeg)
        {
            rb.AddForce((Vector3.up + _hit.normal * 3) * jumppower, ForceMode.Impulse);
        }
        else
        {
            rb.AddForce((Vector3.up * 3) * jumppower, ForceMode.Impulse);
        }
    }

    private void Rot()
    {
        transform.Rotate(0, Input.GetAxisRaw("Mouse X") * rotspeedx * Time.deltaTime, 0);
        //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y+(Input.GetAxisRaw("Mouse X") * rotspeedx * Time.deltaTime), 0);
        _roty += Input.GetAxisRaw("Mouse Y") * rotspeedy*Time.deltaTime;
        _roty = Mathf.Clamp(_roty, -80, 80);
        Cameraa.localRotation = Quaternion.Euler(_roty, 0, -Input.GetAxis("Horizontal"));
    }
}
