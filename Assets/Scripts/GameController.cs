using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player; // �������
    private LineRenderer lineRenderer; // ������Ⱦֱ��

    private GameObject[] pickups; // ����ʰȡ��
    private GameObject nearestPickup; // �����ʰȡ��

    void Start()
    {

        lineRenderer = gameObject.AddComponent<LineRenderer>();

        pickups = GameObject.FindGameObjectsWithTag("PickUp");

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    void Update()
    {
        // ���������ʰȡ��
        FindNearestPickup();

        // ����ҵ������ʰȡ���Ⱦֱ��
        if (nearestPickup != null)
        {
            // ��Ⱦ����ҵ����ʰȡ���ֱ��
            lineRenderer.SetPosition(0, player.transform.position);
            lineRenderer.SetPosition(1, nearestPickup.transform.position);
        }
    }

    void FindNearestPickup()
    {
        // ���������ʰȡ��
        nearestPickup = null;

        float minDistance = Mathf.Infinity;
        foreach (GameObject pickup in pickups)
        {
            // �����Ѿ���ʰȡ������
            if (!pickup.activeInHierarchy)
            {
                continue;
            }

            // ����������ʰȡ��ľ���
            float distance = Vector3.Distance(player.transform.position, pickup.transform.position);

            // �ҵ�������С��ʰȡ��
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestPickup = pickup;
            }
        }
    }
}
