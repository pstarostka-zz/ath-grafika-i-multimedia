using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text winText;
	private int count;

	void Start()
	{
		count = 0;
		SetCountText();
		winText.text = "";
	}
	
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		switch (other.gameObject.tag)
		{
			case "PickUp":
				other.gameObject.SetActive (false);
				count++;
				SetCountText();
				break;
			case "PickUpVariant":
				other.gameObject.SetActive (false);
				count += 3;
				SetCountText();
				break;
			default:
				break;
			
		}
	}

	void SetCountText() {
		countText.text = "Points: " + count.ToString();
		if (count >= 17) {
			winText.text = "YOU WIN!";
		}
	}
}