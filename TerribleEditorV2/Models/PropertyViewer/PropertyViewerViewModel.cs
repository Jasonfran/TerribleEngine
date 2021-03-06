﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TerribleEditorV2.Annotations;

namespace TerribleEditorV2.Models.PropertyViewer
{
    public class PropertyViewerViewModel : INotifyPropertyChanged
    {
        private object _observingItem;

        public object ObservingItem
        {
            get => _observingItem;
            set
            {
                if (value == _observingItem) return;
                _observingItem = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PropertyViewerViewModel()
        {

        }
    }
}