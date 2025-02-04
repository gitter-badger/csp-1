﻿using CSP.Utils.Extensions;
using Syncfusion.Windows.PropertyGrid;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;

namespace CSP.Database.Components
{
    public class ValuePropertyGridComboEditor : BaseTypeEditor
    {
        private ComboBox _comboBox;

        public override void Attach(PropertyViewItem property, PropertyItem info) {
            if (info.Value is not Models.MCU.MapModel.GroupModel.ValuePropertyGridComboEditorModel value)
                return;

            var binding = new Binding("Value.Source") {
                Mode = BindingMode.TwoWay,
                Source = info,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(_comboBox, ComboBox.ItemsSourceProperty, binding);

            binding = new Binding("Value.Value") {
                Mode = BindingMode.TwoWay,
                Source = info,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(_comboBox, ComboBox.SelectedValueProperty, binding);

            binding = new Binding("Value.Value") {
                Mode = BindingMode.TwoWay,
                Source = info,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(_comboBox, ComboBox.ToolTipProperty, binding);

            _comboBox.DisplayMemberPath = "Value";
            _comboBox.SelectedValuePath = "Key";

            if (value.Value.IsNullOrEmpty()) {
                _comboBox.SelectedIndex = 0;
            }
            else {
                _comboBox.SelectedValue = value.Value;
            }
        }

        public override object Create(PropertyInfo propertyInfo) {
            return CreateEditor();
        }

        public override object Create(PropertyDescriptor propertyDescriptor) {
            return CreateEditor();
        }

        public override void Detach(PropertyViewItem property) {
            _comboBox = null;
        }

        private ComboBox CreateEditor() {
            _comboBox = new ComboBox();
            return _comboBox;
        }
    }
}