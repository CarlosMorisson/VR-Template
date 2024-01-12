using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SCS : MonoBehaviour {

	public Transform Player ;
	public  float CloudsSpeed;
	private Material _rainMaterial;
	[SerializeField] private float _timeToRain;
	[SerializeField] private ParticleSystem _rainParticle;
    private void Start()
    {
		_rainMaterial = GetComponent<MeshRenderer>().material;
		StartCoroutine(Rain());
    }
	private IEnumerator Rain()
    {
		transform.DORotate(new Vector3(180, Time.deltaTime * CloudsSpeed, 0), _timeToRain, RotateMode.Fast);
		yield return new WaitForSeconds(_timeToRain);
		_rainParticle.Play();
		_rainParticle.loop = true;
		_rainMaterial.DOColor(Color.black, _timeToRain);
	}
    void Update () {
		if (!Player)
			return;
		gameObject.transform.position = Player.transform.position;

		transform.Rotate(0,Time.deltaTime*CloudsSpeed ,0); 
	}




}
