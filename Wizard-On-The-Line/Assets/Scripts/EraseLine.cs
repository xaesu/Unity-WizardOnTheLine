using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseLine : MonoBehaviour
{
    public bool eraseMode = false;

    [SerializeField]
    GameObject LineContainer;

    [SerializeField]
    float radius = 0.1f;

    void Start()
    {
        LineContainer = GameObject.Find("LineContainer");
    }

    void Update()
    {
        if (eraseMode)
        {
            GetComponent<DrawLine>().drawMode = false;
            // 지우개 모드이면서 마우스 클릭 중일 때
            if (Input.GetMouseButtonDown(0))
            {
                LineErase();
            }
        }
    }

    void LineErase()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(mouseWorldPos, radius);

        // 생성된 라인 오브젝트 대상 검증
        foreach (Transform child in LineContainer.transform)
        {
            foreach (Collider2D collider in colliders)
            {
                if (collider is EdgeCollider2D && collider.gameObject == child.gameObject)
                {
                    // 라인 오브젝트 삭제
                    Destroy(child.gameObject);
                    break;
                }
            }
        }
    }
}
