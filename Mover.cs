using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;

    private int _currentPlace;

    private void Update()
    {
        GoToPoint();
    }

    private void GoToPoint()
    {
        if (transform.position == _points[_currentPlace].position)
        {
            _currentPlace++;

            if (_currentPlace >= _points.Length)
            {
                _currentPlace = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _points[_currentPlace].position, _speed * Time.deltaTime);
    }
}