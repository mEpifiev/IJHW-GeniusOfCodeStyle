using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Transform _waypointsContainer;
    [SerializeField] private Transform[] _waypoints;

    [SerializeField] private float _speed;

    private int _currentWaypointIndex;

    private void Awake()
    {
        _waypoints = new Transform[_waypointsContainer.childCount];

        for (int i = 0; i < _waypointsContainer.childCount; i++)
            _waypoints[i] = _waypointsContainer.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform point = _waypoints[_currentWaypointIndex];

        transform.position = Vector3.MoveTowards(transform.position, point.position, _speed * Time.deltaTime);

        if (transform.position == point.position)
            MoveToNextWaypoint();
    }

    private void MoveToNextWaypoint()
    {
        _currentWaypointIndex++;
        
        if(transform.position == _waypoints[_currentWaypointIndex].position)
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;

        Vector3 nextWaypoint = _waypoints[_currentWaypointIndex].transform.position;

        transform.forward = nextWaypoint - transform.position;
    }
}
