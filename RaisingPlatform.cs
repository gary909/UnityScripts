using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisingPlatform : MonoBehaviour
{
    // This script is a coopy of the SlidingDoor script, execpt the door/platform goes up
    // on button click, not down
    public float duration = 1f;
    public float loweredHeight = 8.5f;

    private bool _lowerDoor = false;
    private Vector3 _raisedPosition;
    // Start is called before the first frame update
    void Start()
    {
        _raisedPosition = transform.position;
    }

    public void TogglePlatformUp()
    {
        StopAllCoroutines();
        if (!_lowerDoor)
        {
            Vector3 lowerPosition = _raisedPosition + Vector3.up * loweredHeight;
            StartCoroutine(MoveDoor(lowerPosition));
        }
        else
        {
            StartCoroutine(MoveDoor(_raisedPosition));
        }

        _lowerDoor = !_lowerDoor;
    }

    IEnumerator MoveDoor(Vector3 targetPosition)
    {
        float timeElapsed = 0;
        Vector3 startPosition = transform.position;
        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
