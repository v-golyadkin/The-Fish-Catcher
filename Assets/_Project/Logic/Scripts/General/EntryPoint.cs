using UnityEngine;
using YG;

public class EntryPoint : MonoBehaviour
{
    private void Start()
    {
        ScreenSelectorSystem.Instance.ShowMainScreen();
        YG2.StickyAdActivity(true);
    }
}
