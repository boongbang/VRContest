using UnityEngine;

public class RockingChair : MonoBehaviour
{
	public float speed = 100f;       // 키보드 누를 때 속도
	public float returnSpeed = 2f;   // 키보드 뗐을 때 원위치 속도
	public float maxAngle = 15f;     // 최대 기울기 각도

	private float currentAngle = 0f;

	void Update()
	{
		// 좌우 방향키 입력 (A, D 키도 작동)
		float input = Input.GetAxis("Horizontal");

		if (input != 0)
		{
			currentAngle += input * speed * Time.deltaTime;
		}
		else
		{
			// 키를 떼면 서서히 0도(정중앙)로 복귀
			currentAngle = Mathf.Lerp(currentAngle, 0, Time.deltaTime * returnSpeed);
		}

		// 각도가 maxAngle을 넘지 않도록 제한
		currentAngle = Mathf.Clamp(currentAngle, -maxAngle, maxAngle);

		// Z축을 기준으로 회전 적용 (방향이 엉뚱하면 아래 3번 참고)
		transform.localRotation = Quaternion.Euler(0, 0, currentAngle);
	}
}