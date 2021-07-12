using UnityEngine;
public class Movement : MonoBehaviour
{
	private Vector3 walking;
	[SerializeField]
	[Range(0, 0.3f)]
	private float walkingSpeed;
	private float walkHor, walkVer;
	public GameObject analog;

	void Start()
	{
		transform.localEulerAngles = new Vector3(0, 150, 0);
	}

	// Update is called once per frame
	void Update()
	{

		walkHor = Input.GetAxis("Horizontal") * walkingSpeed * Time.smoothDeltaTime;
		walkVer = Input.GetAxis("Vertical") * walkingSpeed * Time.smoothDeltaTime;


		walking = new Vector3(analog.transform.localPosition.x, 0, analog.transform.localPosition.y);

		transform.Translate(walking * (walkingSpeed * Time.deltaTime));
	}

}