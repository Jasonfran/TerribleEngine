using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using TerribleEditorV2.Controller;
using TerribleEditorV2.Models;
using TerribleEngine.ECS;

namespace TerribleEditorV2.Views
{
    /// <summary>
    /// Interaction logic for SceneTree.xaml
    /// </summary>
    public partial class SceneTree : UserControl
    {
        public ISceneTreeController Controller { get; private set; }
        public string Test { get; }
        public SceneTree()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                InitDesignData();
            }
            else
            {
                InitRealData();
            }
        }

        private void InitDesignData()
        {
            var model = new SceneTreeViewModel()
            {
                Entities = new ObservableCollection<EntityNodeViewModel>()
                {
                    new EntityNodeViewModel()
                    {
                       Id = 420
                    }
                }
            };

            DataContext = model;
        }

        private void InitRealData()
        {
            Controller = TerribleEditor.Container.Resolve<ISceneTreeController>();
            DataContext = Controller.Model;
        }
    }
}
