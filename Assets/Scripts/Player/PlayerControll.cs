using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using generic.core.Singleton;
using TMPro;
using DG.Tweening;

public class PlayerControll : Singleton<PlayerControll>
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;
    public string tagToCheckEnimy; 
    public string tagToCheckVictory;
    public TextMeshPro uiTextPowerUp;
    public SOCoordenateMenu springMenu;
    public Rigidbody rigidbodyPlayer;

    [Header("Coin Setup")]
    public GameObject coinCollector;
    public Collider coinCollider;
    //public CircleCollider2D colliderPlayer;


    [Header("Animation")]
    public AnimatorManager animatormanagerPlayer;
    public float VelAnimationRun = 1.5f;

    private Tween _curretTween;
    private bool Referencetime = false;

    private float _currentSpeed;

    public BounceHelper bouceHelper;


    [Header("Animation Start")]
    public float scaleDuration = .2f;
    public float scaleTimeBetweenPiece = .1f;
    public Ease easeStartGame = Ease.OutBack;

    [Header("Animation PowerUp")]
    private bool _canRun;
    private Vector3 _pos;
    private Vector3 _startPosition;
    private float _baseSpeedToAnimation = 1;
    public bool invencible = false;
    public bool fly = false;
    public float Movement = 2f;
    public float duracao = 1;
    public Ease easeAnimatorFly = Ease.InOutQuad;
    public GameObject EffectVisual;
    public List<AnimatorEffectVisual> effectvisual;
    public Material Material1;
    public Material Material2;
    public Material Material3;
    private Renderer rendererObject;
    private List<ColorChange> colorChange;

    [Header("Animation EffectGame")]

    public ParticleSystem particleBloom;
    public ParticleSystem particleShield;
    public ParticleSystem particleIma;
    public ParticleSystem particleSpeed;

    [System.Serializable]
    public class AnimatorEffectVisual
    {
        public GameObject ObjectEffectVisual;
    }

    private void Start()
    {
        rendererObject = GetComponent<Renderer>();
        _startPosition = transform.position;
        animatormanagerPlayer.Play(AnimatorManager.AnimationType.IDLE, VelAnimationRun);
        _currentSpeed = speed;

        colorChange = new List<ColorChange>();
        foreach (var child in gameObject.GetComponentsInChildren<ColorChange>())
        {
            colorChange.Add(child);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!_canRun) return;

        transform.position = Vector3.Lerp(transform.position, new Vector3 (target.position.x, transform.position.y, transform.position.z), lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
        if (fly)
        {
            if (_curretTween == null)
            {
                _curretTween = transform.DOLocalMoveY(transform.position.y + Movement, duracao).SetEase(easeAnimatorFly, 1);
                Invoke(nameof(OperacaodeTempo), duracao + 0.1f);
            }
        }
    }

    private void OperacaodeTempo()
    {
        Movement *= -1;
        _curretTween = null;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == tagToCheckEnimy)
        {
            if (!invencible)
            {
                Invoke(nameof(FinishAnimationLost), 2);
                _canRun = false;
                animatormanagerPlayer.Play(AnimatorManager.AnimationType.DEAD);
            }
        }
        if (collision.transform.tag == tagToCheckVictory)
        {
            springMenu.OpenVictory();
            _canRun = false;            
        }
        
    }

    private void FinishAnimationLost()
    {
        springMenu.OpenLost();

    }

    public void StarToRun()
    {
        _canRun = false;
        StartCoroutine(ScalePersonagePlayer());
        Invoke(nameof(Operationstart), scaleDuration);
    }

    IEnumerator ScalePersonagePlayer()
    {

        CoinsAnimatorManager.Instance.StartAnimator();
        transform.localScale = Vector3.zero;
        transform.DOScale(1, scaleDuration).SetEase(easeStartGame);
        yield return null;
    }

    private void Operationstart()
    {
        animatormanagerPlayer.Play(AnimatorManager.AnimationType.START, 1);
    }

    public void GoToRun()
    {
        _canRun = true;
        animatormanagerPlayer.Play(AnimatorManager.AnimationType.RUN, VelAnimationRun);
    }

    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }


    public void PowerUpSpeedUp(float f)
    {
        if (particleSpeed != null)
        {
            particleSpeed.Play();
        }
        animatormanagerPlayer.Play(AnimatorManager.AnimationType.RUN, (f/VelAnimationRun)/4);
        _currentSpeed = f;
    }

    public void ResetSpeed()
    {
        animatormanagerPlayer.Play(AnimatorManager.AnimationType.RUN, VelAnimationRun);
        _currentSpeed = speed;
    }

    public void SetInvencible(bool b)
    {
        invencible = b;
        if (invencible)
        {
            changeVisual(Material3);
            animatormanagerPlayer.Play(AnimatorManager.AnimationType.MAGNETIC, VelAnimationRun);
            if (particleShield != null)
            {
                particleShield.Play();
            }
        }
        else
        {
            changeVisual(Material1);
            animatormanagerPlayer.Play(AnimatorManager.AnimationType.RUN, VelAnimationRun);
        }
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        if (particleBloom != null)
        {
            particleBloom.Play();
        }
        rigidbodyPlayer.useGravity = (false);
        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);//.OnComplete(ResetHeight);a
        animatormanagerPlayer.Play(AnimatorManager.AnimationType.FLY, 0.4f);
        Invoke(nameof(InitialFly), animationDuration + 0.1f);
        Invoke(nameof(ResetHeight), duration);
    }

    public void InitialFly()
    {
        fly = true;
    }

    public void ResetHeight()
    {
        _curretTween.Kill();
        fly = false;
        rigidbodyPlayer.useGravity = (true);
        animatormanagerPlayer.Play(AnimatorManager.AnimationType.RUN, VelAnimationRun);
    }

    public void timePowerUpLast(float timeLast)
    {
        for (int i = 0; i < colorChange.Count; i++) 
        {
            StartCoroutine(timePowerUpLastAnimation(i, timeLast));
        }
    }

    IEnumerator timePowerUpLastAnimation(int i, float timeLast)
    {

        yield return new WaitForSeconds(timeLast);
        colorChange[i].InitiateAnimate();
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        if (amount != 1)
        {
            if (particleIma != null)
            {
                particleIma.Play();
            }
            changeVisual(Material2);
        }
        else {
            changeVisual(Material1); 
        }
        coinCollector.transform.localScale = Vector3.one * amount;
    }


    public void changeVisual(Material material) {
        foreach (AnimatorEffectVisual variavelmaterial in effectvisual)
        {
            rendererObject = variavelmaterial.ObjectEffectVisual.GetComponent<Renderer>();
            rendererObject.material = material;
        }
    }

    public void Bounce()
    {
        bouceHelper.Bounce();
    }
}
