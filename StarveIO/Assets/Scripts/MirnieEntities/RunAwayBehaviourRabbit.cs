using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAwayBehaviourRabbit : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private float _verySpeed;

    public float chasingTime;
    public float chillTime;
    public float timer;
    public float timer2;
    public bool canChase;
    public bool oleg; //начало второго таймеееера
    public bool polya;//if(nikita_daun) writeln(задавание второогооо трансомфрфпф короче там плеер который отсталый раньше был а щас уже ушел норм, но типа да, вот дак палучаетвсяя что он там был а потом нет и кароче авргаврга идеит к последянримиу месту кшгде он был аыаы);  
    public bool canMove = true;
    public bool Inokentiy; /// шобы олег не убегал. Инокентий фас

    public float RandomChisferka1;
    public float RandomChisferka2;
    public float RandomCd1;
    public float RandomCd2;

    private Vector2 lastPlayerTransform;



    [SerializeField]
    private float _rotationSpeed;
    private float _veryRotationSpeed;

    private Rigidbody2D _rigidbody;
    private PlayerAwarenessController _playerAwarenessController;
    private Vector2 _targetDirection;
    private float _changeDirectionCooldown;

    private void Awake()
    {   
        _verySpeed = _speed;
        _veryRotationSpeed = _rotationSpeed;
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        _targetDirection = transform.up;
    }

    private void FixedUpdate()
    {   
       
        UpdateTargetDirection();
        RotateTowardsTarget();
        if(canMove)
            SetVelocity();

    }

    private void StopSignal()
    {
        _rigidbody.velocity = transform.up * 0f;
        canMove = false;
    }

    private void UpSpeed()
    {   
        
        _speed += 2.5f;
        _rotationSpeed += 220f; 
        RandomCd2 += -1;
        
    }

    private void NormalSpeed()
    {
        _speed = _verySpeed;
        _rotationSpeed = _veryRotationSpeed;
        RandomCd2 += 1;
    }

    private void UpdateTargetDirection()
    {
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
    }

    private void HandleRandomDirectionChange()
    {//AGOAGSU09AGAGAHGAGGAGAGAGAGG
        _changeDirectionCooldown -= Time.deltaTime;

        if (_changeDirectionCooldown <= 0) //wefwfhiowghiogghsaegoagahdogaghwtgjiqweejo qjiqerwjhifwejiowgejipqefgojipwegjiwergjgigjifeqhiojiwer    hioefhoefgjhipghioghi[ogbrfjhniovbnklxcfvnlxvnlxvnklxlk;gbjfdljghagh;oiegjiwrhjipghjipghjipojiogrjipowqejihseghnkgsdkgsjisgsgsggrgjwgjipgrwjipgrjipgjipgrjopwrjpowgjopewrgjnwgkjowergwgwporgwrgwjgpwrjgjpowrgwjrgwrgwrjgjwoiprgjipowergpowrgjowgwpoigwejhnfghsdfghsdfigshdjkghdfghadfo;ghnksdflghadfisugioeht4rqyh89uhdfsaghnagnjw4rtguht]
        {
            float angleChange = Random.Range(RandomChisferka1, RandomChisferka2);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _targetDirection = rotation * _targetDirection;

            _changeDirectionCooldown = Random.Range(RandomCd1, RandomCd2);
        }
    }

    private void HandlePlayerTargeting()
    {
        if(_playerAwarenessController.AwareOfPlayer && oleg == false)
        {
            UpSpeed();
            oleg = true;
            polya = true;
            timer = 0f;
        }

        if(polya)
        {
            timer += Time.deltaTime;
            if(timer >= chasingTime)
            {
                NormalSpeed();
                polya = false;
                oleg = false;
                timer = 0f;
            }
        }


    }

    private void RotateTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _rigidbody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        _rigidbody.velocity = transform.up * _speed;
    }
}