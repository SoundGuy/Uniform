using UnityEngine;

/// <summary>
/// Primary pointer (first touch or mouse) for legacy Input on WebGL/mobile and desktop.
/// </summary>
public static class PointerInput {

	public static bool PrimaryPointerDown() {
		if (Input.touchCount > 0)
			return Input.GetTouch(0).phase == TouchPhase.Began;
		return Input.GetMouseButtonDown(0);
	}

	public static bool PrimaryPointerUp() {
		if (Input.touchCount > 0) {
			TouchPhase p = Input.GetTouch(0).phase;
			return p == TouchPhase.Ended || p == TouchPhase.Canceled;
		}
		return Input.GetMouseButtonUp(0);
	}

	public static Vector2 PrimaryScreenPosition() {
		if (Input.touchCount > 0)
			return Input.GetTouch(0).position;
		return Input.mousePosition;
	}

	/// <summary>
	/// World point on z=0 plane for an orthographic camera facing the XY plane (typical 2D).
	/// </summary>
	public static Vector3 ScreenToWorldPointOnPlayPlane(Camera cam, Vector2 screenPx) {
		if (cam == null)
			return Vector3.zero;
		float dist = Mathf.Abs(cam.transform.position.z);
		Vector3 sp = new Vector3(screenPx.x, screenPx.y, dist);
		Vector3 w = cam.ScreenToWorldPoint(sp);
		w.z = 0f;
		return w;
	}

	public static Ray ScreenPointToRay(Camera cam, Vector2 screenPx) {
		return cam.ScreenPointToRay(new Vector3(screenPx.x, screenPx.y, 0f));
	}

	/// <summary>
	/// Call from Update when ghetto is full: true once per downward two-finger pan (mobile substitute for scroll wheel).
	/// </summary>
	public static bool TwoFingerPanDownThisFrame() {
		if (Input.touchCount < 2)
			return false;
		float dy = 0f;
		for (int i = 0; i < Input.touchCount; i++) {
			Touch t = Input.GetTouch(i);
			if (t.phase == TouchPhase.Moved)
				dy += t.deltaPosition.y;
		}
		return dy < -20f;
	}
}
