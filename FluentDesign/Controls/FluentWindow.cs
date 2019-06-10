using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using FluentDesign.Extensions;

namespace FluentDesign.Controls
{
    [TemplatePart(Name = PART_TitleBar, Type = typeof(UIElement))]
    [TemplatePart(Name = PART_Thumb, Type = typeof(UIElement))]
    public class FluentWindow : Window
    {
        // ReSharper disable InconsistentNaming
        private const string PART_TitleBar = "PART_TitleBar";
        private const string PART_Thumb = "PART_Thumb";
        // ReSharper restore InconsistentNaming

        private Thumb _titleThumb;

        static FluentWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FluentWindow), new FrameworkPropertyMetadata(typeof(FluentWindow)));
        }

        public override void OnApplyTemplate()
        {
            this.EnableBlur();

            _titleThumb = GetTemplateChild(PART_Thumb) as Thumb;
            
            RegisterAllEvents();
        }

        private void RegisterAllEvents()
        {
            UnregisterAllEvents();

            _titleThumb.PreviewMouseLeftButtonDown += TitleThumbOnPreviewMouseLeftButtonDown;
        }

        private void UnregisterAllEvents()
        {
            _titleThumb.PreviewMouseLeftButtonDown -= TitleThumbOnPreviewMouseLeftButtonDown;
        }

        private void TitleThumbOnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        public static bool GetIsAcrylic(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsAcrylicProperty);
        }

        public static void SetIsAcrylic(DependencyObject obj, bool value)
        {
            obj.SetValue(IsAcrylicProperty, value);
        }

        public static readonly DependencyProperty IsAcrylicProperty =
            DependencyProperty.RegisterAttached("IsAcrylic", typeof(bool), typeof(Window), new PropertyMetadata(true, OnIsAcrylicChanged));

        private static void OnIsAcrylicChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (!(dependencyObject is Window win)) return;

            var value = (bool)eventArgs.NewValue;
            if (!value) return;

            win.Loaded += (_, __) => { win.EnableBlur(); };
            if (win.IsLoaded) win.EnableBlur();
        }
    }
}
