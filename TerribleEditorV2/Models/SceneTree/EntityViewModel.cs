using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TerribleEditorV2.Annotations;
using TerribleEngine.ECS;

namespace TerribleEditorV2.Models.SceneTree
{
    public class EntityViewModel : INotifyPropertyChanged
    {
        public IEntity Entity { get; }

        public Transform Transform { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EntityViewModel(IEntity entity)
        {
            Entity = entity;
            Transform = entity.Transform;
        }
    }
}