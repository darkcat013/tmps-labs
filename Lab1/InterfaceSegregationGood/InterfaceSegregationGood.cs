using System;

namespace SOLIDPrinciples
{
    interface ILeftMouseButton
    {
        void LeftButton();
    }
    interface IRightMouseButton
    {
        void RightButton();
    }
    interface IWheelMouseButton
    {
        void WheelButton();
    }
    interface ISideMouseButton
    {
        void SideButton();
    }
    interface IChangeSensitivityMouseButton
    {
        void ChangeSensitivityButton();
    }
}
