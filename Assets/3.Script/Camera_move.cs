using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    //ī�޶� �÷��̾� ���󰡱�
    public GameObject target; //ī�޶� ���� ���
    public float moveSpeed;// ī�޶� ���� �ӵ�
    private Vector3 targetPos; //����� ���� ��ġ

    //------------------------
    //ī�޶� ���� ����
    public float limitX = 10;
    public float limitY = 10;
    internal static object main;

    private void Update()
    {
        if (target.gameObject != null)//����� �ִ��� Ȯ��
        {
            //LimitCameraArea();
            //this�� ī�޶� �ǹ�
            targetPos.Set(target.transform.position.x + 1, target.transform.position.y + 0.5f, -10);

            this.transform.position = Vector3.Lerp(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
            //Lerp�� �ﰢ������ ī�޶� �÷��̾ ������ �ʰ� �ϱ� ���� ���
            //�� �� �ε巴�� ����
        }
    }
}
