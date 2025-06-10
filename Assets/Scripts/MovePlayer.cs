using System;
using UnityEngine;
using UnityEngine.Animations;

// 물체를 방향키의 입력을 받아 이동
public class MovePlayer : MonoBehaviour
{
    public float speed = 10;
    public float rotSpeed = 50;

    float xRot;
    float yRot;

    void Start()
    {
        transform.rotation = Quaternion.identity;
        //transform.rotation = Quaternion.Euler(30, 45, 60);
    }

    void Update()
    {
        // MoveWithoutTime();

        MoveWithTime();

        RotatePlayer();
    }

    private void MoveWithoutTime()
    {
        bool isAKeyDown = Input.GetKey(KeyCode.A);
        bool isWKeyDown = Input.GetKey(KeyCode.W);
        bool isSKeyDown = Input.GetKey(KeyCode.S);
        bool isDKeyDown = Input.GetKey(KeyCode.D);

        if (isWKeyDown)
        {
            Vector3 direction = Vector3.forward * speed;
            Vector3 localDirection = transform.forward * speed;

            transform.position += localDirection;
        }

        if (isAKeyDown)
        {
            Vector3 direction = Vector3.left * speed;
            Vector3 localDirection = -transform.forward * speed;

            transform.position += localDirection;
        }

        if (isSKeyDown)
        {
            Vector3 direction = Vector3.back * speed;
            Vector3 localdirection = Vector3.right * speed;

            transform.position += localdirection;
        }

        if (isDKeyDown)
        {
            Vector3 direction = Vector3.right * speed;
            Vector3 localdirection = -Vector3.right * speed;

            transform.position += localdirection;
        }
    }

    // 시간에 대한 고려 있는 Move함수
    private void MoveWithTime()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // 방향키 좌우
        float verticalInput = Input.GetAxis("Vertical"); // 방향키 상하

        Vector3 direction = transform.forward * verticalInput + transform.right* horizontalInput;
        transform.position += direction * (speed * Time.deltaTime);
    }

    // 시간에 대한 고려 없는 Move함수
    private void RotatePlayer()
    {
        /*오일러 회전 : 0~360 deg -> 이해하기 쉬운 각도의 값을 넣어서 회전 (직관적)
        쿼터니언회전 : 4원수(x, y, z, w), 오일러 회전의 단점인 짐벌락(gimbal lock)을 보완
        짐벌락이란?
            내부의 회전이 외부의 회전에 의해 자유도를 잃어버리는 현상.
        */

        // // 짐벌락 예시
        // transform.eulerAngles += new Vector3(1 * 0.1f, 1, 0);

        // // 오일러 예시
        // transform.Rotate(transform.up, 0.1f);       // 내 자신의 Up Vector 기준 회전
        // transform.Rotate(transform.right, 0.1f);    // 내 자신의 Right Vector 기준 회전

        // // transform.rotation = Quaternion.identity;
        // Quaternion rotY90 = Quaternion.AngleAxis(0.1f, Vector3.up);
        // transform.rotation *= rotY90;

        // Vector3 rotDir = Input.mousePosition;
        // print(rotDir);


        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        print($"Mouse X: {mouseX}, mouse Y: {mouseY}x");

        xRot += mouseX * rotSpeed * Time.deltaTime;
        yRot += mouseY * rotSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(-yRot, xRot, 0);
    }
}