using UnityEngine;

public class LaneInitializer : MonoBehaviour
{
    [SerializeField] private GameObject lane;

    private void Start()
    {
        for (int i = 1; i < Config.NUMBER_OF_LANES; i++)
        {
            GameObject newLane = Instantiate(lane, lane.transform.parent);
            Vector3 pos = newLane.transform.localPosition;
            pos.x += 0.2f * i;
            newLane.transform.localPosition = pos;
            newLane.GetComponent<LaneHandler>().SetLane(i);
        }
    }
}