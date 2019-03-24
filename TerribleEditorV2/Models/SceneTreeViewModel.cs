using System.Collections.ObjectModel;
using TerribleEditorV2.Controller;
using TerribleEngine.ECS;

namespace TerribleEditorV2.Models
{
    public class SceneTreeViewModel
    {
        public ObservableCollection<EntityNodeViewModel> Entities { get; set; }

        public SceneTreeViewModel()
        {
            Entities = new ObservableCollection<EntityNodeViewModel>();
        }
    }
}