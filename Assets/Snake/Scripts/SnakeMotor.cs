using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMotor : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip foodSound;
    public AudioClip deathSound;
    public AudioClip scootSound;
    public AudioSource soundFX;
    [Range(0f, 1f)] [SerializeField] float scootVolume = 0.4f;


    [Header("Movement")]
    [SerializeField] float inputGracePeriod;
    private float? inputPressedTime;
    Vector2 dir;
    Vector2 right = Vector2.right;
    Vector2 left = Vector2.left;
    Vector2 up = Vector2.up;
    Vector2 down = Vector2.down;
    float moveSpeed = 5f;
    private bool isDead = false;


    [Header("Componets")]
    [SerializeField] Transform segPrefab;
    Transform poolParent;
    ParticleSystem ps;
    SpriteRenderer sprite;
    Score scoreScript;
    int score;
    private List<Transform> segments = new List<Transform>();
    [SerializeField] int startSize = 4;
    private Vector3 startPosition = Vector3.zero;
    private bool canInput;
    Animator animator;
    Event_Master eventMaster;

    void OnEnable()
    {
        eventMaster = GameObject.Find("EventMaster").GetComponent<Event_Master>();
        eventMaster.levelComplete += PausePlayer;
        eventMaster.gameOver += PausePlayer;
    }
    void OnDisable()
    {
        eventMaster.levelComplete -= PausePlayer;
        eventMaster.gameOver += PausePlayer;
    }
    void Awake()
    {
        poolParent = GameObject.Find("PoolParent").GetComponent<Transform>();
        ps = GetComponent<ParticleSystem>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        scoreScript = Score.instance;
        score = scoreScript.currentScore;
        Respawn();
    }
    void Update()
    {
        if (canInput)
            TrackInputs();
        
        if(!IsMoving() && !isDead)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }
        
    }
    void FixedUpdate()
    {
        if (isDead)
            return;
        if (IsMoving())
            soundFX.PlayOneShot(scootSound, scootVolume);

        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        transform.position = new Vector3(Mathf.Round(transform.position.x) + dir.normalized.x , Mathf.Round(transform.position.y) + dir.normalized.y , 0f);
        canInput = true;
    }

    bool IsMoving() => dir.magnitude != 0;
   
    void TrackInputs()
    {
        float currentTime = Time.time + inputGracePeriod;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && dir != right)
        {
            inputPressedTime = Time.time;
            if(Time.time - inputPressedTime <= inputGracePeriod)
            {
                dir = left;
                canInput = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && dir != left)
        {
            inputPressedTime = Time.time;
            if (Time.time - inputPressedTime <= inputGracePeriod)
            {
                dir = right;
                canInput = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && dir != down)
        {
            inputPressedTime = Time.time;
            if (Time.time - inputPressedTime <= inputGracePeriod)
            {
                dir = up;
                canInput = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && dir != up)
        {
            inputPressedTime = Time.time;
            if (Time.time - inputPressedTime <= inputGracePeriod)
            {
                dir = down;
                canInput = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!IsMoving())
            return;
        if (CanEat(col))
        {
            if (isDead)
                return;
            Transform segment = Instantiate(segPrefab, poolParent);
            segment.position = segments[segments.Count - 1].position;
            segments.Add(segment);
            ps.Play();
            soundFX.PlayOneShot(foodSound);
        }
        if(ShouldDieOnTrigger(col))
        {
            StartCoroutine(Death());
        }
    }
    bool CanEat(Collider2D col) => col.CompareTag("Food");

    bool ShouldDieOnTrigger(Collider2D col) => col.CompareTag("DoNotTouch");
    
    void PausePlayer()
    {
        isDead = true;
    }
    IEnumerator Death()
    {
        isDead = true;
        soundFX.PlayOneShot(deathSound);
        ps.Play();
        segments.Clear();
        eventMaster.CallDeath(); 
        Destroy(gameObject, 0.5f); // posible bug when you die and food piece hits you and tries to add prefab to player thats destroyed.
        yield break;
        
    }
    void Respawn()
    {
        dir = Vector2.zero;
        eventMaster.CallStartScene();
        isDead = false;
        segments.Add(this.transform);
        for (int i = 1; i < startSize + score; i++)
        {
            segments.Add(Instantiate(segPrefab, poolParent.transform));
        }

        if (!isDead)
        {
            
        }
    }
    public void ReturnToTitle()
    {
        if (isDead)
            return;
        
        eventMaster.CallReturnToTitle();
    }
    
}
