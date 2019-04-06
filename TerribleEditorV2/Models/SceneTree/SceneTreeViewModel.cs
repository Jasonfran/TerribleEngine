using System.Collections.ObjectModel;

namespace TerribleEditorV2.Models.SceneTree
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