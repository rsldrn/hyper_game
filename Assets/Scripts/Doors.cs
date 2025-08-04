using Enums;
using UnityEngine;
using TMPro;
//public enum BonusType { Addition, Differance, Product, Division };

public class Doors : MonoBehaviour
{
    

    [Header("Elements")]
    [SerializeField] private SpriteRenderer rightDoorRenderer;
    [SerializeField] private SpriteRenderer leftDoorRenderer;
    [SerializeField] private TextMeshPro rightDoorText;
    [SerializeField] private TextMeshPro leftDoorText;
    [SerializeField] private new Collider collider;

    [Header("Setting")]
    [SerializeField] private BonusType rightDoorBonusType;
    [SerializeField] private int rightDoorBonusAmount;

    [SerializeField] private BonusType leftDoorBonusType;
    [SerializeField] private int leftDoorBonusAmount;

    [SerializeField] private Color bonusColor;  //kendi gradyan olusturabilir mi
    [SerializeField] private Color penaltyColor;

    void Start()
    {
        ConfigureDoors();
    }

    private void ConfigureDoors()
    {
        switch (rightDoorBonusType)  
        {
            case BonusType.Addition:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "+" + rightDoorBonusAmount;
                break;

            case BonusType.Differance:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "-" + rightDoorBonusAmount;
                break;

            case BonusType.Product:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "*" + rightDoorBonusAmount;
                break;

            case BonusType.Division:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "/" + rightDoorBonusAmount;
                break;
        }

        switch (leftDoorBonusType) 
        {
            case BonusType.Addition:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "+" + leftDoorBonusAmount;
                break;

            case BonusType.Differance:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "-" + leftDoorBonusAmount;
                break;

            case BonusType.Product:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "*" + leftDoorBonusAmount;
                break;

            case BonusType.Division:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "/" + leftDoorBonusAmount;
                break;
        }
    }

    public int GetBonusAmount(float xPosition)
    {
        if (xPosition > 0)
        {
            return rightDoorBonusAmount;
        }
        else
        {
            return leftDoorBonusAmount;
        }
    }
    public BonusType GetBonusType(float xPosition)
    {
        if (xPosition > 0)
        {
            return rightDoorBonusType;
        }
        else
        {
            return leftDoorBonusType;
        }
    }

    public void DisableDoorCollider()
    {
        collider.enabled = false; // ayni kapidan birden fazla kez bonus almamak icin
    }
}
