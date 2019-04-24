using System.ComponentModel;
using System.Windows.Controls;
using TerribleEditorV2.Controller;
using TerribleEditorV2.Models.PropertyViewer;

namespace TerribleEditorV2.Views
{
    /// <summary>
    /// Interaction logic for PropertyViewer.xaml
    /// </summary>
    public partial class PropertyViewer : UserControl
    {
        public IPropertyViewerController Controller { get; private set; }

        public PropertyViewer()
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

        private void InitRealData()
        {
            Controller = TerribleEditor.Container.Resolve<IPropertyViewerController>();
            DataContext = Controller.Model;
            TerribleEditor.EditorUpdate += (sender, args) => { PropertyGrid.Update(); };
        }

        private void InitDesignData()
        {
            DataContext = new PropertyViewerViewModel();
        }
    }
}
