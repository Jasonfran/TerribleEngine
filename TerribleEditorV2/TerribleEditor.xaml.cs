using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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
        public static SynchronizationContext SynchronizationContext { get; private set; }

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

            SynchronizationContext = SynchronizationContext.Current;
            TerribleApp = new TerribleApp();
        }

        public static void CreateEngineInterface()
        {
            EditorInterface = Container.Resolve<IEditorInterface>();
        }
    }
}
