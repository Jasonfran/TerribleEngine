using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using TerribleEngine.ECS;
using TerribleEngine.Enums;
using TerribleEngine.Rendering;
using TerribleEngine.Resources;
using TerribleEngine.Threading;

namespace TerribleEngine
{
    public class TerribleApp
    {
        public LaunchState LaunchState { get; private set; }

        public EngineThread UpdateThread { get; set; }
        public EngineThread RenderThread { get; set; }
        public InitialiseSettings Settings { get; private set; }

        public SystemManager SystemManager { get; }
        public EntityManager EntityManager { get; }
        public EventManager EventManager { get; }
        public ResourceManager ResourceManager { get; }
        public Renderer Renderer { get; private set; }

        public World.World ActiveWorld { get; private set; }

        public TerribleApp()
        {
            SystemManager = new SystemManager();
            EntityManager = new EntityManager(SystemManager);
            EventManager = new EventManager();
            ResourceManager = new ResourceManager();
            Renderer = new Renderer();

            UpdateThread = new EngineThread(UpdateInit, Update, 60);
            RenderThread = new EngineThread(RenderInit, Render, 30);
        }

        public void Init(LaunchState state, InitialiseSettings settings)
        {
            LaunchState = state;
            Settings = settings;

            Settings.Context.MakeCurrent(null);
            SystemManager.LoadSystems(new CoreSystemLoader());
            SystemManager.InitialiseSystems(EntityManager, EventManager, ResourceManager);

            UpdateThread.Start();
            RenderThread.Start();

        }

        public void LoadScene(World.World world)
        {
            ActiveWorld = world;
        }

        private void UpdateInit()
        {
        }

        private void Update()
        {
            SystemManager.UpdateSystems();
            EventManager.Update();
        }

        private void RenderInit()
        {
            Settings.Context.MakeCurrent(Settings.WindowInfo);

            Renderer.EntityManager = EntityManager;
            Renderer.EventManager = EventManager;
            Renderer.ResourceManager = ResourceManager;

            Renderer.Init(Settings.Width, Settings.Height);
        }

        private void Render()
        {
            Renderer.Render(Settings.Context);
        }

        public void Exit()
        {
            UpdateThread.Exit();
            RenderThread.Exit();
            SystemManager.ExitSystems();
        }
    }
}