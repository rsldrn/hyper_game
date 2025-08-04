using Enums;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    
    [Header("Setting")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private int roadWidth;
    [SerializeField] private bool canMove;

    [SerializeField] private PlayerAnimator playerAnimator;

    [Header("Control")]
    [SerializeField] private float slideSpeed;

    [SerializeField] private Vector3 clickScreenPosition;
    [SerializeField] private Vector3 clickPlayerPosition;

    [SerializeField] private CrowdSystem crowdSystem;

    private void Awake() //bu sinifin yalnizca bir ornegi (instance) sahnede olmali.
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        GameManager.onGameStateChanged += GameStateChangeCallback;
    }

    private void OnDestroy() //nesne yok edilmeden hemen once çagrilir
    {
        GameManager.onGameStateChanged -= GameStateChangeCallback; //Daha once abone olunan onGameStateChanged olayindan çikiliır (unsubscribe).
    }


    void Update()
    {
        if (canMove)
        {
            MoveSpeedForward();
            ManageControl();
        }
    }

    private void StartMoving()
    {
        canMove = true;
        playerAnimator.Run();
    }
    private void StopMoving()
    {
        canMove = false;
        playerAnimator.Idle(); 
    }

    private void GameStateChangeCallback(GameState gameState)//
    {
        if(gameState == GameState.Game)//
        {
            StartMoving();
        }
        else if (gameState == GameState.LevelComplete)//
        {
            StopMoving();
        }
        
    }

    private void MoveSpeedForward()
    {
        // float factor = Time.deltaTime * moveSpeed;  //daha verimli carpma
        // transform.position += Vector3.forward * factor;
        
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }
   
    private void ManageControl()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Ilk dokunmada pozisyonu kaydet
            if (touch.phase == TouchPhase.Began)
            {
                clickScreenPosition = touch.position;
                clickPlayerPosition = transform.position;
            }

            // Parmagi hareket ettirirken konumu surekli guncelle
            else if (touch.phase == TouchPhase.Moved)
            {
                float xScreenDifferences = touch.position.x - clickScreenPosition.x;

                xScreenDifferences /= Screen.width;
                xScreenDifferences *= slideSpeed;

                Vector3 position = transform.position;
                position.x = clickPlayerPosition.x + xScreenDifferences;

                position.x = Mathf.Clamp(position.x, -roadWidth / 2 + crowdSystem.GetCrowdRadius(), roadWidth / 2 - crowdSystem.GetCrowdRadius());//karakterlerin kenardan tasmasi engellenir

                transform.position = position;
            }

            // Parmagin ekranla temasi bittiginde yeni baslangic verilerini kaydet
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                clickPlayerPosition = transform.position; 
            }
        }
    }

}
