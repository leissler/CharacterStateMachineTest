using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.ThirdPerson;
using Prime31.StateKit;

public class EnemyAIController : MonoBehaviour {

	public Transform playerTransform;
	public List<Transform> wayPoints = new List<Transform>();
	public NavMeshAgent agent {get; private set;}
	public ThirdPersonCharacter character {get; private set;}

	private SKStateMachine<EnemyAIController> _machine;


	void Start() {
		agent = GetComponent<NavMeshAgent>();
		character = GetComponent<ThirdPersonCharacter>();

		_machine = new SKStateMachine<EnemyAIController>(this, new EnemyAIPatrol());
		_machine.addState(new EnemyAIChase());
	}

	void Update() {
		_machine.update(Time.deltaTime);
	}

}
