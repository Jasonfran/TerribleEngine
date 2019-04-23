using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        }

        private void InitDesignData()
        {
            DataContext = new PropertyViewerViewModel()
            {
                Controls = new ObservableCollection<UIElement>()
                {
                    new Label()
                    {
                        Content = "PropertyViewer design mode"
                    }
                }
            };
        }
    }
}
