using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransformManager : OrdonedMonoBehaviour
{
    public FloatVariable MapLength;
    public FloatVariable MapHeight;

    public FloatVariable LengthZoomFactor;
    public FloatVariable HeightZoomFactor;
    public FloatVariable MinZoom;
    public FloatVariable ZoomMargin;
    public FloatVariable AdaptationTime;

    public PlayerPositions PlayerPositions;

    private int _maxX;
    private int _minX;
    private int _maxY;
    private int _minY;

    private Vector2 _centerPos;
    private Vector2 _centerPosAtLastWait;

    private float _cameraZTarget;
    private float _cameraZTargetAtLastWait;
    private float _initialCameraZTarget;

    private float _lastWaitTime;

    public override void DoAwake()
    {

    }

    public override void DoUpdate()
    {
        if (!AdaptationTime) return;
        float timeSinceLastWait = Time.time - _lastWaitTime;
        if (timeSinceLastWait < AdaptationTime.Value)
        {
            float timeFactor = (1 - timeSinceLastWait / AdaptationTime.Value);
            Vector2 cameraXY = _centerPos + timeFactor * (_centerPosAtLastWait - _centerPos);
            float cameraZ = _cameraZTarget + timeFactor * (_cameraZTargetAtLastWait - _cameraZTarget);
            transform.position = new Vector3(cameraXY.x, cameraXY.y, cameraZ);
        }
    }

    public void OnMapConfigurated()
    {
        if (!MapLength || !MapHeight || !LengthZoomFactor || !HeightZoomFactor) return;
        float cameraX = MapLength.Value % 2 == 0 ? -0.5f : 0f;
        float cameraY = MapHeight.Value % 2 == 0 ? -0.5f : 0f;
        _initialCameraZTarget = Mathf.Min(-(MapLength.Value + 2) * LengthZoomFactor.Value, -(MapHeight.Value + 2) * HeightZoomFactor.Value);
        transform.position = new Vector3(cameraX, cameraY, _initialCameraZTarget);
        _lastWaitTime = -1;
    }

    public void OnWaitActionState()
    {
        _centerPosAtLastWait = _centerPos;
        _cameraZTargetAtLastWait = _cameraZTarget;
        CalcCoordonates();
        CalcZTarget();
        _lastWaitTime = Time.time;
    }

    public void CalcCoordonates()
    {
        _maxX = PlayerPositions.GetPosition(0).x;
        _minX = PlayerPositions.GetPosition(0).x;
        _maxY = PlayerPositions.GetPosition(0).y;
        _minY = PlayerPositions.GetPosition(0).y;
        for (int i = 0; i < PlayerPositions.GetPlayerCount(); i++)
        {
            if (PlayerPositions.GetPosition(i).x < _minX) { _minX = PlayerPositions.GetPosition(i).x; }
            if (PlayerPositions.GetPosition(i).x > _maxX) { _maxX = PlayerPositions.GetPosition(i).x; }
            if (PlayerPositions.GetPosition(i).y < _minY) { _minY = PlayerPositions.GetPosition(i).y; }
            if (PlayerPositions.GetPosition(i).y > _maxY) { _maxY = PlayerPositions.GetPosition(i).y; }
        }
        _centerPos = new Vector2(((float)(_minX + _maxX))/2, ((float)(_minY + _maxY))/2);
    }

    public void CalcZTarget()
    {
        _cameraZTarget = Mathf.Max(_initialCameraZTarget, Mathf.Min(-((float)(_maxX - _minX + 1) + ZoomMargin.Value) * LengthZoomFactor.Value, -((float)(_maxY - _minY + 1) + ZoomMargin.Value) * HeightZoomFactor.Value, -MinZoom.Value * HeightZoomFactor.Value));
    }
}
