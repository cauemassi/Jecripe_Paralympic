using UnityEngine;
using System.Collections;

public class guideBehaviour : MonoBehaviour {

	public Transform atleta, referencia, referencia2;
	public Rigidbody rig;
	public Animator animator;
	public float x, x1;

	void Start () {
		x = referencia.position.x;
		x1 = referencia2.position.x;
	}

	void Rotaciona (Transform referencia)
	{
		float dx = this.transform.position.x - referencia.position.x;
		float dy = this.transform.position.z - referencia.position.z;
		float angle = Mathf.Atan2 (dx, dy) * Mathf.Rad2Deg;
		Quaternion rot = Quaternion.Euler (new Vector3 (0, angle + 90, 0));
		this.transform.rotation = rot;
	}

	void Movimenta(){

		rig.velocity = playerBehaviour2.velocidadeparaguia;

	}

	void MovimentaCurva(){

		rig.velocity = playerBehaviour2.velfrente * -transform.forward * 1.11f + playerBehaviour2.vellado  * transform.right *1.1101f;
	}

	void Anima ()
	{
		
		if (playerBehaviour2.começa) {
			if (rig.velocity != new Vector3 (0, 0, 0)) {
				animator.SetBool ("inIdle", false);
				animator.SetBool ("inRun", true);
				animator.SetBool ("inStart", false);
			} else {
				animator.SetBool ("inIdle", true);
				animator.SetBool ("inRun", false);
				animator.SetBool ("inStart", false);
			}
		} else {
			animator.SetBool ("inIdle", false);
			animator.SetBool ("inRun", false);
			animator.SetBool ("inStart", true);
		}
	}

	void ControlaPosiçoes ()
	{
		
		if (transform.position.x < x1) {
			Rotaciona (referencia2);
			MovimentaCurva ();

		} else {
			
			if (transform.position.x < x) {			
				if (transform.position.z <= 19f) {
					if(transform.position.z <= 13.5f){
						rig.velocity = new Vector3(rig.velocity.x,0,1*Time.deltaTime);
					}
					else{
						rig.velocity = new Vector3(rig.velocity.x,0,0);
					}
					transform.rotation = Quaternion.Euler (new Vector3 (0, 270, 0));
					Movimenta();
				} else {
					if(transform.position.z >= 101.9f){
						transform.Translate (Vector3.right * Time.deltaTime);
					}
					else{
						rig.velocity = new Vector3(rig.velocity.x,0,0);
					}
					transform.rotation = Quaternion.Euler (new Vector3 (0, 90, 0));
					Movimenta();
					
					
				}
			} else {
				Rotaciona (referencia);
				MovimentaCurva ();
			}
		}
	}

	
	void Update () {
		Anima ();
		ControlaPosiçoes ();
	
	}
}
