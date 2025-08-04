using Enums;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private Transform runnersParent;
    [SerializeField] private GameObject runnerPrefab;


    [Header("Settings")]
    [SerializeField] private float radius;
    [SerializeField] private float angel;
    
    void Update()
    {
        if(!GameManager.instance.IsGameState())
        {
            return;
        }
        PlaceRunner();

        if (runnersParent.childCount <= 0)
        {
            GameManager.instance.SetGameState(GameState.GameOver);//
        }
    }

    private void PlaceRunner()
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            Vector3 childLocalPosition = PlayerRunnerLocalPosition(i);
            runnersParent.GetChild(i).localPosition = childLocalPosition;
        }
    }

    private Vector3 PlayerRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angel);
        float y = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angel);
        return new Vector3(x, 0, y);
    }

    public float GetCrowdRadius()
    {
        return radius * Mathf.Sqrt(runnersParent.childCount);
    }

    public void ApplyBonus(BonusType bonusType, int bonusAmount)
    {
        switch (bonusType)
        {
            case BonusType.Addition:
                AddRunners(bonusAmount);
                break;

            case BonusType.Product:
                int runnerToAdd = (runnersParent.childCount * bonusAmount) - runnersParent.childCount;
                AddRunners(runnerToAdd);
                break;

            case BonusType.Differance:
                RemoveRunners(bonusAmount);
                break;

            case BonusType.Division:
                int runnerToRemove = runnersParent.childCount - (runnersParent.childCount / bonusAmount);
                RemoveRunners(runnerToRemove);
                break;
        }
    }

    private void AddRunners(int amount)
    {
        for (int i = 0;i < amount; i++)
        {
            Instantiate(runnerPrefab, runnersParent);
        }
        playerAnimator.Run();
    }

    private void RemoveRunners(int amount)
    {        
            if(amount > runnersParent.childCount)
            {
                amount = runnersParent.childCount;
            }
            int runnersAmount = runnersParent.childCount;

            for(int i = runnersAmount-1; i >= runnersAmount - amount; i--)
            {
                Transform runnerToDestroy = runnersParent.GetChild(i);
                runnerToDestroy.SetParent(null);
                Destroy(runnerToDestroy.gameObject);
            } 
        
    }
}
