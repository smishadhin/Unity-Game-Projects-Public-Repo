using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followpath : MonoBehaviour{
    public enum FollowType{
        MoveTowards,
        Lerp
    }

    public FollowType type = FollowType.MoveTowards;
    public PathDefination path;
    public float speed = 1;
    public float maxDistanceToGoal = .1f;

    private IEnumerator<Transform> _currentPoint;

     void Start(){
        if (path == null){
            Debug.LogError("path cannot be null", gameObject);
            return;
        }

        _currentPoint = path.GetPathsEnumerator();
        
        _currentPoint.MoveNext();

        if (_currentPoint.Current == null){
            return;
        }

        transform.position = _currentPoint.Current.position;
    }

     void Update(){
        if (_currentPoint == null || _currentPoint.Current == null){
            return;
        }

        if (type == FollowType.MoveTowards){
            transform.position = Vector3.MoveTowards(transform.position, _currentPoint.Current.position,  speed*Time.deltaTime );
        } else if (type == FollowType.Lerp){
            transform.position =
                Vector3.Lerp(transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
        }

        var distanceSqurad = (transform.position - _currentPoint.Current.position).sqrMagnitude;
        if (distanceSqurad < maxDistanceToGoal * maxDistanceToGoal){
            _currentPoint.MoveNext();
        }
    }
}