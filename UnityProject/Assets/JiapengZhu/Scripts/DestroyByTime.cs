using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
	public float lifeTime;

/*
 * Object.Destroy():
 * public static function Destroy(obj: Object, t: float = 0.0F): void;
 * Removes a gameobject, component or asset.
 * The object obj will be destroyed now or if a time is specified t seconds from now. 
 * If obj is a Component it will remove the component from the GameObject and destroy it. 
 * If obj is a GameObject it will destroy the GameObject, 
 * all its components and all transform children of the GameObject.
 * Actual object destruction is always delayed until after the current Update loop, 
 * but will always be done before rendering.
 */
	void Start(){
		Destroy (gameObject, lifeTime);
	}
}
