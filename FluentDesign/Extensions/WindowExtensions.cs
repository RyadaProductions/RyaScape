using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace FluentDesign.Extensions
{
    internal static class WindowExtensions
    {
        /// <summary>
        /// enum to specify what type of accent i want the fluentWindow to have.
        /// </summary>
        private enum AccentState
        {
            AccentDisabled = 0,
            AccentEnableGradient = 1,
            AccentEnableTransparentGradient = 2,
            AccentEnableBlurBehind = 3,
            AccentEnableAcrylicBlurBehind = 4,
            AccentInvalidState = 5
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct AccentPolicy
        {
            public AccentState AccentState;
            public int AccentFlags;
            public uint GradientColor;
            public int AnimationId;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        private enum WindowCompositionAttribute
        {
            // ...
            WcaAccentPolicy = 19
            // ...
        }

        /// <summary>
        /// Enable the Aeroglass blur that is intended to be used in UWP.
        /// </summary>
        /// <param name="fluentWindow">the fluentWindow to enable Aeroglass on</param>
        public static void EnableBlur(this Window fluentWindow)
        {
            var windowHelper = new WindowInteropHelper(fluentWindow);

            var accent = new AccentPolicy
            {
                AccentState = AccentState.AccentEnableBlurBehind,
                AccentFlags = 2,
                GradientColor = 0x00FFFFFF
            };

            var accentStructSize = Marshal.SizeOf(accent);

            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData
            {
                Attribute = WindowCompositionAttribute.WcaAccentPolicy,
                SizeOfData = accentStructSize,
                Data = accentPtr
            };

            SetWindowCompositionAttribute(windowHelper.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }

        [DllImport("user32.dll")]
        private static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
    }
}
