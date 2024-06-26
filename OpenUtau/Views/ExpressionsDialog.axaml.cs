﻿using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using OpenUtau.App.ViewModels;
using OpenUtau.Core.Ustx;

namespace OpenUtau.App.Views {
    public partial class ExpressionsDialog : Window {
        public ExpressionsDialog() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        private void ApplyButtonClicked(object sender, RoutedEventArgs _) {
            try {
                (DataContext as ExpressionsViewModel)?.Apply();
                Close();
            } catch (Exception e) {
                MessageBox.ShowError(this, e);
            }
        }

        private void OnExpressionTypeChanged(object sender, SelectionChangedEventArgs e) {
            var comboBox = (ComboBox)sender;
            var vm = DataContext as ExpressionsViewModel;
            if (vm?.Expression != null) {
                vm.Expression!.ExpressionType = (UExpressionType)comboBox.SelectedIndex;
            }
        }
    }
}
