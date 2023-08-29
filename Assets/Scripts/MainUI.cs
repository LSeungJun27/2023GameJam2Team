using UnityEngine;
using UnityEngine.UIElements;

public class MainUI : MonoBehaviour
{
    public UIDocument UIDocument;

    private void Awake()
    {
        UIDocument.rootVisualElement.Q<Button>(className:"btn_start").clicked += () =>
        {
            Debug.Log("Game Started");
            UIDocument.rootVisualElement.Q<VisualElement>(className: "title").visible = false;
            GameManager.instance.onStart.Invoke();
            GameManager.instance.inGameCam.gameObject.SetActive(true);
            
        };
    }
}
