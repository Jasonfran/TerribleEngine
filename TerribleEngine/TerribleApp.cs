﻿using System;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using TerribleEngine.ECS;
using TerribleEngine.EditorHelpers;
using TerribleEngine.Enums;
using TerribleEngine.Events.Window;
using TerribleEngine.Rendering;
using TerribleEngine.Resources;
using TerribleEngine.Scene;
using TerribleEngine.Threading;

namespace TerribleEngine
{
    public class TerribleApp
    {
        public LaunchState LaunchState { get; private set; }

        public EngineThread UpdateThread { get; set; }
        public EngineThread RenderThread { get; set; }

        public SystemManager SystemManager { get; }
        public EntityManager EntityManager { get; }
        public EventManager EventManager { get; }
        public ResourceManager ResourceManager { get; }
        public Renderer Renderer { get; private set; }
        public EngineInterface EngineInterface { get; }

        public World ActiveWorld { get; private set; }

        public static InitialiseSettings Settings { get; private set; }
        public static int ScreenWidth { get; private set; }
        public static int ScreenHeight { get; private set; }

        public TerribleApp()
        {
            SystemManager = new SystemManager();
            EventManager = new EventManager();
            EntityManager = new EntityManager(SystemManager, EventManager);
            ResourceManager = new ResourceManager();
            Renderer = new Renderer();

            EngineInterface = new EngineInterface(EventManager);
            EngineInterface.RegisterEvents();

            UpdateThread = new EngineThread(UpdateInit, Update, 60);
            RenderThread = new EngineThread(RenderInit, Render, 60);
        }

        public void Init(LaunchState state, InitialiseSettings settings)
        {
            LaunchState = state;
            Settings = settings;
            ActiveWorld = new World();

            Settings.Context.MakeCurrent(null);
            SystemManager.LoadSystems(new CoreSystemLoader());
            EntityManager.RegisterSystem(Renderer);

            SystemManager.InitialiseSystems(EntityManager, EventManager, ResourceManager, ActiveWorld);

            UpdateThread.Start();
            RenderThread.Start();
        }

        public void LoadScene(World world)
        {
            ActiveWorld = world;
        }

        public float GetFramerate()
        {
            return 1000.0f / (float) RenderThread.Timer.ElapsedFrameTime;
        }

        private void UpdateInit()
        {

        }

        private void Update()
        {
            SystemManager.UpdateSystems((float) UpdateThread.Timer.ElapsedFrameTime / 1000);
            EventManager.Update();
        }

        private void RenderInit()
        {
            Settings.Context.MakeCurrent(Settings.WindowInfo);

            Renderer.EntityManager = EntityManager;
            Renderer.EventManager = EventManager;
            Renderer.ResourceManager = ResourceManager;

            Renderer.Init();
            EventManager.RaiseEvent(new WindowResizeEvent(Settings.Width, Settings.Height));
        }

        private void Render()
        {
            Renderer.Update((float) RenderThread.Timer.ElapsedFrameTime / 1000);
        }

        public void Exit()
        {
            UpdateThread.Exit();
            RenderThread.Exit();
            SystemManager.ExitSystems();
        }

        public void ResizeWindow(int glControlWidth, int glControlHeight)
        {
            EventManager.RaiseEvent(new WindowResizeEvent(glControlWidth, glControlHeight));
        }
    }
}