using UnityEngine;

public class MovementEx : MonoBehaviour
{
    [SerializeField] private float speed;

    // public float Speed { get; set; }
    public GameObject cylinderA;
    public GameObject cylinderB;

    public bool isArrived = false;

    void Start()
    {
    }

    void Update()
    {
        if (!isArrived)
            MoveAtoB(transform.gameObject, cylinderB);

        else
            MoveAtoB(transform.gameObject, cylinderA);
    }

    private void MoveAtoB(GameObject start, GameObject end)
    {
        // A에서 B를 향하는 벡터 -> 단위벡터 (크기가 1) -> 플레이어에게 단위벡터를 더해줌
        Vector3 directionAtoB = end.transform.position - start.transform.position;
        Vector3 normalizedDir = directionAtoB.normalized;

        float distance = Vector3.Magnitude(directionAtoB);
        print(distance);

        if (distance < 0.1f)
        {
            isArrived = !isArrived;
            return;
        }

        transform.position += normalizedDir * (speed * Time.deltaTime);
    }
}