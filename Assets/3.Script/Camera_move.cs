using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    //카메라 플레이어 따라가기
    public GameObject target; //카메라가 따라갈 대상
    public float moveSpeed;// 카메라가 따라갈 속도
    private Vector3 targetPos; //대상의 현재 위치

    //------------------------
    //카메라 범위 제한
    public float limitX = 10;
    public float limitY = 10;
    internal static object main;

    private void Update()
    {
        if (target.gameObject != null)//대상이 있는지 확인
        {
            //LimitCameraArea();
            //this는 카메라를 의미
            targetPos.Set(target.transform.position.x + 1, target.transform.position.y + 0.5f, -10);

            this.transform.position = Vector3.Lerp(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
            //Lerp는 즉각적으로 카메라가 플레이어를 따라가지 않게 하기 위해 사용
            //좀 더 부드럽게 따라감
        }
    }
}
