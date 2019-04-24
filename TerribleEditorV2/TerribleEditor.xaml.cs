using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using TerribleEditorV2.Controller;
using TerribleEditorV2.EngineHelpers;
using TerribleEditorV2.Events;
using TerribleEditorV2.Services;
using TerribleEngine;
using TerribleEngine.EditorHelpers.Interfaces;
using EventManager = TerribleEditorV2.Services.EventManager;

namespace TerribleEditorV2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class TerribleEditor : Application
    {
        public static IWindsorContainer Container { get; private set; }
        public static TerribleApp TerribleApp { get; private set; }
        public static IEditorInterface EditorInterface { get; private set; }

        public static event EventHandler EditorUpdate;

        public static DispatcherTimer MasterTimer { get; set; }

        public TerribleEditor()
        {
            Container = new WindsorContainer();
            Container.Register(
                Component.For<ISceneTreeController>()
                    .ImplementedBy<SceneTreeController>(),

                Component.For<IPropertyViewerController>()
                    .ImplementedBy<PropertyViewerController>(),

                Component.For<IEditorEntityManager>()
                    .ImplementedBy<EditorEntityManager>(),

                Component.For<IEditorInterface>()
                    .ImplementedBy<EditorInterface>(),

                Component.For<IEventManager>()
                    .ImplementedBy<EventManager>()
                );

            TerribleApp = new TerribleApp();
            MasterTimer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 500), DispatcherPriority.Normal, MasterTimeTick, Current.Dispatcher);
            MasterTimer.Start();
        }

        private void MasterTimeTick(object sender, EventArgs e)
        {
            EditorUpdate?.Invoke(this, e);
        }

        public static void CreateEngineInterface()
        {
            EditorInterface = Container.Resolve<IEditorInterface>();
        }
    }
}
