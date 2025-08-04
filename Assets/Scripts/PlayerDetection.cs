using Enums;
using UnityEngine;


public class PlayerDetection : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private CrowdSystem crowdSystem;

    private bool _hasFinished; // <-- bayrak eklendi ??? -> finish cizgisinde console a 100 den fazla debug mesaji yazdiriyordu
   
    void Update()
    {
        DetectDoors();
    }


    private void DetectDoors()
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, 1);

        for (int i = 0; i < detectedColliders.Length; i++)
        {
            if (detectedColliders[i].TryGetComponent(out Doors doors))
            {
                Debug.Log("Hit the doors");

                int bonusAmount = doors.GetBonusAmount(transform.position.x);
                BonusType bonusType = doors.GetBonusType(transform.position.x);

                doors.DisableDoorCollider();
                crowdSystem.ApplyBonus(bonusType, bonusAmount);
            }

            // else if (detectedColliders[i].tag == "Finish" && !_hasFinished)
            // {
            //     PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            //     GameManager.instance.SetGameState(GameState.LevelComplete); //
            //     
            //     _hasFinished = true; // <-- bayrak eklendi ??? 
            // }
        }
    }
}
