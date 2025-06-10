using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Animations;

// Cube1, 2, 3, 4, 5를 순서대로 1초 간격으로 출발
// CylinderA -> B -> C -> D 순으로 이동
// 속성 : Cube의 속도, 타겟들
public class CubeManager : MonoBehaviour
{
    public float speed;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    public GameObject cube5;

    public List<GameObject> targets;

    private void Start()
    {
        StartCoroutine(CoStart());
    }

    private void Update()
    {
        print("Update");
    }

    // 코루틴(Coroutine) 메소드 : Process 내에서 잠깐 기다릴 수 있게 해줌.
    IEnumerator CoStart()
    {
        print("Cube 시작!!"); // 반복문 사용 Cube1 운행
        yield return MoveCubeToTargets(cube1, targets);

        yield return new WaitForSeconds(1);
        print("Cube2 시작!"); // 반복문 사용 Cube2 운행
        yield return MoveCubeToTargets(cube2, targets);

        yield return new WaitForSeconds(1);
        print("Cube3 시작!"); // 반복문 사용 Cube3 운행
        yield return MoveCubeToTargets(cube3, targets);

        yield return new WaitForSeconds(1);
        print("Cube4 시작!"); // 반복문 사용 Cube4 운행
        yield return MoveCubeToTargets(cube4, targets);
        
        yield return new WaitForSeconds(1);
        print("Cube4 시작!"); // 반복문 사용 Cube5 운행
        yield return MoveCubeToTargets(cube5, targets);
    }

    IEnumerator MoveCubeToTargets(GameObject cube, List<GameObject> targets)
    {
        int index = 0;
        print(cube.gameObject.name + "출발!!");

        while (true)
        {
            // A에서 B를 향하는 벡터 -> 단위벡터 (크기가 1) -> 플레이어에게 단위벡터를 더해줌
            Vector3 directionAtoB = targets[index].transform.position - cube.transform.position;
            Vector3 normalizedDir = directionAtoB.normalized;

            float distance = Vector3.Magnitude(directionAtoB);
            print(distance);

            if (distance < 0.1f)
            {
                // CylA -> CylB -> CylC -> CylD
                index++;
                
                if (index == targets.Count)
                    break;
            }

            cube.transform.position += normalizedDir * (speed * Time.deltaTime);
            
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }
}