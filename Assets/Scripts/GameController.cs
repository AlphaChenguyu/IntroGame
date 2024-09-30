using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player; // 玩家物体
    private LineRenderer lineRenderer; // 用于渲染直线

    private GameObject[] pickups; // 所有拾取物
    private GameObject nearestPickup; // 最近的拾取物

    void Start()
    {

        lineRenderer = gameObject.AddComponent<LineRenderer>();

        pickups = GameObject.FindGameObjectsWithTag("PickUp");

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    void Update()
    {
        // 查找最近的拾取物
        FindNearestPickup();

        // 如果找到最近的拾取物，渲染直线
        if (nearestPickup != null)
        {
            // 渲染从玩家到最近拾取物的直线
            lineRenderer.SetPosition(0, player.transform.position);
            lineRenderer.SetPosition(1, nearestPickup.transform.position);
        }
    }

    void FindNearestPickup()
    {
        // 重置最近的拾取物
        nearestPickup = null;

        float minDistance = Mathf.Infinity;
        foreach (GameObject pickup in pickups)
        {
            // 跳过已经被拾取的物体
            if (!pickup.activeInHierarchy)
            {
                continue;
            }

            // 计算玩家与该拾取物的距离
            float distance = Vector3.Distance(player.transform.position, pickup.transform.position);

            // 找到距离最小的拾取物
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestPickup = pickup;
            }
        }
    }
}
