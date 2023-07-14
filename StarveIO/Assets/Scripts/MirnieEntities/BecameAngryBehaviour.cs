using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecameAngryBehaviour : MonoBehaviour
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
    public Sprite spriteDefault;
    public Sprite spriteAngry;

    public bool isAngry;

    private Vector2 lastPlayerTransform;

    public SpriteRenderer spriteRend;



    [SerializeField]
    private float _rotationSpeed;
    private float _veryRotationSpeed;

    private Rigidbody2D _rigidbody;
    private PlayerAwarenessController _playerAwarenessController;
    private Vector2 _targetDirection;
    private float _changeDirectionCooldown;

    private void Awake()
    {   
        isAngry = false;
        _verySpeed = _speed;
        _veryRotationSpeed = _rotationSpeed;
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        _targetDirection = transform.up;
    }

    private void FixedUpdate()
    {   
        if(isAngry)
        {
            spriteRend.sprite = spriteAngry;
        }
        else{
            spriteRend.sprite = spriteDefault;
            NormalSpeed();
        }

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
        if(!Inokentiy)
        {
            _speed += 2.5f;
            _rotationSpeed += 220f;
            Inokentiy = true;
        }
        
    }

    private void NormalSpeed()
    {
        _speed = _verySpeed;
        _rotationSpeed = _veryRotationSpeed;
    }

    private void UpdateTargetDirection()
    {
        HandleRandomDirectionChange();
        if(isAngry)
            HandlePlayerTargeting();
    }

    private void HandleRandomDirectionChange()
    {//AGOAGSU09AGAGAHGAGGAGAGAGAGG
        _changeDirectionCooldown -= Time.deltaTime;

        if (_changeDirectionCooldown <= 0) //wefwfhiowghiogghsaegoagahdogaghwtgjiqweejo qjiqerwjhifwejiowgejipqefgojipwegjiwergjgigjifeqhiojiwer    hioefhoefgjhipghioghi[ogbrfjhniovbnklxcfvnlxvnlxvnklxlk;gbjfdljghagh;oiegjiwrhjipghjipghjipojiogrjipowqejihseghnkgsdkgsjisgsgsggrgjwgjipgrwjipgrjipgjipgrjopwrjpowgjopewrgjnwgkjowergwgwporgwrgwjgpwrjgjpowrgwjrgwrgwrjgjwoiprgjipowergpowrgjowgwpoigwejhnfghsdfghsdfigshdjkghdfghadfo;ghnksdflghadfisugioeht4rqyh89uhdfsaghnagnjw4rtguht]
        {
            float angleChange = Random.Range(-130f, 130f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _targetDirection = rotation * _targetDirection;

            _changeDirectionCooldown = Random.Range(2f, 6f);
        }
    }

    private void HandlePlayerTargeting()
    {

        if(polya)
        {
            lastPlayerTransform = _playerAwarenessController.DirectionToPlayer;
            canMove = true;
            polya = false;
        }

        if(_playerAwarenessController.AwareOfPlayer == false)
            NormalSpeed();


        if (_playerAwarenessController.AwareOfPlayer && canChase)
        {   
            _targetDirection = lastPlayerTransform;
            oleg = true;
            
            timer = 0f;
        }

      

        if(transform.position.x + 1f > lastPlayerTransform.x && transform.position.x -1f < lastPlayerTransform.x)
        {
            if(transform.position.y + 1f > lastPlayerTransform.y && transform.position.y -1f < lastPlayerTransform.y)
            {
                StopSignal();
            }
        }

        
        

        if(oleg)
        {
            timer2+= Time.deltaTime;
            UpSpeed();
            if(timer2 >= chasingTime)
            {
                NormalSpeed();
                canChase = false;
                timer = 0f;
                oleg = false;
                timer2 = 0f;
            }
        }

        if(canChase == false)
        {   
            timer += Time.deltaTime;
            StopSignal();
            if(timer >= chillTime)
            {
                canChase = true;
                polya = true;
                Inokentiy = false;
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