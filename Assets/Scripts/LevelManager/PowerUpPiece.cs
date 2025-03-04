using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPiece : MonoBehaviour
{

    public int ContPowerUp = 3;

    private void Start()
    {
        for (int i = 0; i < ContPowerUp; i++)
        {
            Vector3 positionObject = new Vector3(PowerUpManager.Instance.powerUpPosition[i].positionPowerUp.x, transform.position.y + PowerUpManager.Instance.powerUpPosition[i].positionPowerUp.y, transform.position.z);
            GameObject instance = Instantiate(PowerUpManager.Instance.powerUpObject[Random.Range(0, PowerUpManager.Instance.powerUpObject.Count)].ObjectPowerUp, positionObject, transform.rotation);
            instance.transform.SetParent(transform);
        }
    }
}
