using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Vehicle : MonoBehaviour
{
    private Vector3 _directionOfRay = new Vector3(0, 0, 1);
    private Vector3 _rayPosition;
    private Quaternion _angleOfRayRotation;
    private Color _colorOfRay = Color.red;    
    private float _lengthOfRay = 3f;

    public float MinMoveSpeed { get; set; }
    public float MaxMoveSpeed { get; set; }

    protected float _randomSelectedSpeed;
    protected float _minSpeedInterval = SpawnController._minSpeedInterval;
    protected float _maxSpeedInterval = SpawnController._maxSpeedInterval;    
    
    private void Start()
    {
        SetMoveSpeed();        
    }    

    public virtual void SetMoveSpeed()
    {
        ChangeSpeedLimits(_minSpeedInterval, _maxSpeedInterval);
        ChooseNewRandomSpeed();
    }

    public void ChangeSpeedLimits(float minSpeed, float maxSpeed)
    {
        MinMoveSpeed = minSpeed;
        MaxMoveSpeed = maxSpeed;
    }

    public void ChooseNewRandomSpeed()
    {
        _randomSelectedSpeed = Random.Range(MinMoveSpeed, MaxMoveSpeed);
        gameObject.GetComponent<PathFollower>()._moveSpeed = _randomSelectedSpeed;
    }

    private void Update()
    {
        DrawVisibleInEditorRay();
        CastRayFromVehicle();
    }

    private void DrawVisibleInEditorRay()
    {
        _angleOfRayRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        _rayPosition = transform.position + Vector3.up / 2;
        Debug.DrawRay(_rayPosition, _angleOfRayRotation * _directionOfRay * _lengthOfRay, _colorOfRay);
    }

    private void CastRayFromVehicle()
    {
        RaycastHit hit;
        if(Physics.Raycast(_rayPosition,_angleOfRayRotation * _directionOfRay,out hit,_lengthOfRay))
        {
            if (hit.transform.gameObject.tag != "Wall")
            {
                gameObject.GetComponent<PathFollower>()._moveSpeed = hit.transform.gameObject.GetComponent<PathFollower>()._moveSpeed;
            }
        }
        else
        {
            if(gameObject.GetComponent<PathFollower>()._moveSpeed < _randomSelectedSpeed)
            {
                gameObject.GetComponent<PathFollower>()._moveSpeed *= 1.1f;
            }            
        }
    }
}
