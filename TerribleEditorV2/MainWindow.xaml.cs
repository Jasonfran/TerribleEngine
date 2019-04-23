using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using TerribleEngine;
using TerribleEngine.ECS;
using TerribleEngine.Enums;

namespace TerribleEditorV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TerribleApp _terribleApp = TerribleEditor.TerribleApp;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TerribleEditor.CreateEngineInterface();
            _terribleApp.Init(LaunchState.Editor, new InitialiseSettings()
            {
                Context = GlControl.Context,
                Width = GlControl.Width,
                Height = GlControl.Height,
                WindowInfo = GlControl.WindowInfo
            });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _terribleApp.Exit();
        }

        private void GlHost_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_terribleApp != null)
            {
                _terribleApp.ResizeWindow(GlControl.Width, GlControl.Height);
            }
        }
    }
}
