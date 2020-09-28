﻿using UnityEngine;

public class PlayerWalkEvent : IPlayerEvent {
    private readonly Rigidbody _PlayerRigidbody;
    private readonly Transform _PlayerTransform;
    private readonly PlayerPhysics _PhysicsPlayer;
    //private readonly float _MaxWalkSpeed;
    private readonly float _WalkSpeed;

    public PlayerWalkEvent(PlayerPhysics playerPhysics, Rigidbody playerRigidbody) {
        _PhysicsPlayer = playerPhysics;
        _PlayerRigidbody = playerRigidbody;
        _PlayerTransform = playerRigidbody.transform;
        //_MaxWalkSpeed = 3.0f;
        _WalkSpeed = 3.0f;
    }

    public void ExecuteAnimationEvent() {
        throw new System.NotImplementedException();
    }

    public void ExecutePhysicsEvent() {
        Vector3 direction = _PhysicsPlayer.CalculateHorizontalDirection();
        Vector3 moveToLocation = (direction * _WalkSpeed * Time.deltaTime) + _PlayerTransform.position;
        if (_PhysicsPlayer.Grounded_HorizontalMoveCheck(moveToLocation)) {
            direction = _PhysicsPlayer.HorizontalDirection;
            moveToLocation = (direction * _WalkSpeed * Time.deltaTime) + _PlayerTransform.position;
            _PlayerRigidbody.MovePosition(moveToLocation);
        } else {
            return;
        }
    }
}
