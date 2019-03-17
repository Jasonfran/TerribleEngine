using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using TerribleEngine.Attributes;
using TerribleEngine.ComponentModels;
using TerribleEngine.ECS;
using TerribleEngine.Resources;

namespace TerribleEngine.Rendering
{
    [DependsOnComponents(typeof(Renderable))]
    public class Renderer : TerribleSystem
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        private bool _resized = false;

        private Color4 clearColor = Color4.Black;

        private Model testModel;
        private Shader testShader;

        private int VAO;
        private int EBO;
        private ArrayBuffer VBO;

        private Dictionary<Mesh, VertexDataPointer> _vertexDataPointers;

        public Renderer()
        {
            _vertexDataPointers = new Dictionary<Mesh, VertexDataPointer>();
        }

        public void Init(int width, int height)
        {
            Width = width;
            Height = height;

            GL.Viewport(0, 0, width, height);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.CullFace(CullFaceMode.Back);

            testModel = ResourceManager.LoadModel(
                @"Models/cube.obj");

            testShader = ResourceManager.LoadShader("Shaders/Main.vert", "Shaders/Main.frag");

            VAO = GL.GenVertexArray();
            GL.BindVertexArray(VAO);

            VBO = new ArrayBuffer(GL.GenBuffer(), 1024 * 8, BufferUsageHint.StaticDraw);
            VBO.Bind();

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, Vertex.Stride, 0);

            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, Vertex.Stride,
                Marshal.OffsetOf(typeof(Vertex), "Normal"));

            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, Vertex.Stride,
                Marshal.OffsetOf(typeof(Vertex), "Color"));

            GL.EnableVertexAttribArray(3);
            GL.VertexAttribPointer(3, 2, VertexAttribPointerType.Float, false, Vertex.Stride,
                Marshal.OffsetOf(typeof(Vertex), "TexCoords"));

            EBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);

            GL.BufferData(BufferTarget.ElementArrayBuffer, 1024 * 8, IntPtr.Zero, BufferUsageHint.StaticDraw);

            var vertexOffset = 0;
            var indexOffset = 0;
            foreach (var mesh in testModel.Meshes)
            {
                var vertexCount = mesh.Vertices.Count * Vertex.Stride;
                var indexCount = mesh.Indices.Count * sizeof(int);

                GL.BufferSubData(VBO.Target, new IntPtr(vertexOffset), vertexCount, mesh.Vertices.ToArray());

                _vertexDataPointers.Add(mesh, new VertexDataPointer(vertexOffset, vertexCount));

                GL.BufferSubData(BufferTarget.ElementArrayBuffer, new IntPtr(indexOffset), indexCount, mesh.Indices.ToArray());

                vertexOffset += vertexCount;
                indexOffset += indexCount;
            }

            VBO.Unbind();
        }

        public void Resize(int width, int height)
        {
            Width = width;
            Height = height;
            _resized = true;
        }

        public void Render(IGraphicsContext context)
        {
            if (_resized)
            {
                GL.Viewport(0, 0, Width, Height);
                Console.WriteLine($"Resizing to Width: {Width}px Height {Height}px");
                _resized = false;
            }

            GL.ClearColor(clearColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.BindVertexArray(VAO);

            testShader.Use();
            var view = Matrix4.CreateTranslation(0.0f, 0.0f, -10.0f);
            var projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(75.0f),
                (float)Width / (float)Height, 1.0f, 1000.0f);

            testShader.SetMat4("view", view);
            testShader.SetMat4("projection", projection);

            foreach (var entity in Entities)
            {
                var renderable = entity.GetComponent<Renderable>();
                var model = Matrix4.CreateTranslation(entity.Transform.Position);
                testShader.SetMat4("model", model);
                testShader.SetMat4("mvp", model * view * projection);

                foreach (var mesh in renderable.Model.Meshes)
                {
                    var pointer = _vertexDataPointers[mesh];
                    GL.DrawElementsBaseVertex(PrimitiveType.Triangles, pointer.Count, DrawElementsType.UnsignedInt, IntPtr.Zero, pointer.Start);
                }
            }

            context.SwapBuffers();
            GL.BindVertexArray(0);
        }
    }
}