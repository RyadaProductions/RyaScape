﻿using System.Windows;
using FluentDesign.Extensions;

namespace FluentDesign.Controls
{
    [TemplatePart(Name = PART_TitleBar, Type= typeof(UIElement))]
    public class FluentWindow : Window
    {
        // ReSharper disable InconsistentNaming
        private const string PART_TitleBar = "PART_TitleBar";
        // ReSharper restore InconsistentNaming

        static FluentWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FluentWindow), new FrameworkPropertyMetadata(typeof(FluentWindow)));
        }

        public override void OnApplyTemplate()
        {
            
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
            DependencyProperty.RegisterAttached("IsAcrylic", typeof(bool), typeof(Window), new PropertyMetadata(false, OnEnableChanged));

        private static void OnEnableChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (!(dependencyObject is Window win)) return;

            var value = (bool)eventArgs.NewValue;
            if (!value) return;
            
            win.Loaded += (_, __) => { win.EnableBlur(); };
            if (win.IsLoaded) win.EnableBlur();
        }

        
    }
}