using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotateDash : MonoBehaviour
{
    [SerializeField] Transform startPoint; // Ba�lang�� noktas�
    [SerializeField] Transform endPoint;   // Biti� noktas�
    private float speed = 100f;     // Cismin h�z�

    private Vector3 targetPosition;
    private bool movingToEnd = true;

    void Start()
    {
        targetPosition = endPoint.position;
    }

    void Update()
    {
        // Hedefe do�ru hareket et
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // E�er hedefe ula��ld�ysa, yeni hedefi ayarla (di�er nokta) ve hareket y�n�n� de�i�tir
        if (transform.position == targetPosition)
        {
            if (movingToEnd)
            {
                targetPosition = startPoint.position;
                RandomSpeed();
            }
            else
            {
                targetPosition = endPoint.position;
                RandomSpeed();
            }
            movingToEnd = !movingToEnd;
        }
    }

    void RandomSpeed()
    {
        speed = Random.Range(100f, 300f);
    }
}
