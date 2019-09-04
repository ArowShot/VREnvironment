using Valve.VR.Extras;

public interface IVRUIInteraction
{
    void Click(object sender, PointerEventArgs e);
    void Enter(object sender, PointerEventArgs e);
    void Exit(object sender, PointerEventArgs e);
}