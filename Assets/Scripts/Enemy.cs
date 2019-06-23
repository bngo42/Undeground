using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	public Transform 		target;
	public float			searchLength = 10f;

	private float			searchTimer;
	private NavMeshAgent 	nav;
	private float			distance;
	private Vector3			destination;
	private IEnumerator		patrolCoroutine;

	void Start () {
		nav = GetComponent<NavMeshAgent>();
	}
	
	void Update () {
		if (target) {
			RaycastHit hit;
			distance = (target.position - transform.position).magnitude;
			
			if (patrolCoroutine != null) {
				StopCoroutine(patrolCoroutine);
				patrolCoroutine = null;
			}


			if (distance >= nav.stoppingDistance){
				if (Physics.Raycast(transform.position, (target.position - transform.position), out hit, distance)) {
					searchTimer += Time.deltaTime;
				}
				nav.SetDestination(target.position);
			} else {
				searchTimer = 0f;
				Vector3 dir = target.position;
				dir.y = transform.position.y;
				transform.LookAt(dir);
			}

			if (searchTimer >= searchLength) {
					searchTimer = 0f;
					target = null;
			}
		} else {
			if (patrolCoroutine == null) {
				patrolCoroutine = patrol();
				StartCoroutine(patrolCoroutine);
			}
		}
	}

	IEnumerator patrol() {
		while (true) {
			distance = (destination - transform.position).magnitude;
			nav.SetDestination(destination);

			if (distance <= nav.stoppingDistance) {
				yield return new WaitForSeconds(5f);
				Vector3 dest = rndDestination(20f);
				dest.y = transform.position.y;
				destination = dest;
			} else {
				yield return null;
			}
		}
	}

	void OnTriggerStay(Collider col) {
		if (col.tag == "Player") {
			target = col.transform;
		}
	}

	public void setTarget(Transform t) {
		target = t;
	}

	public Vector3 rndDestination(float radius) {
		return (Random.insideUnitSphere * radius);
	}
}
