using System;
using OpenTK.Graphics.OpenGL;

namespace TerribleEngine.Rendering
{
    public class Buffer
    {
        public BufferTarget Target { get; }
        public int BufferId { get; }
        public int Size { get; private set; }
        public BufferUsageHint UsageHint { get; private set; }

        protected Buffer(BufferTarget target, int bufferId, int size, BufferUsageHint usageHint)
        {
            Target = target;
            BufferId = bufferId;
            Size = size;
            UsageHint = usageHint;

            SetupBuffer();
        }

        protected void SetupBuffer()
        {
            Bind();
            GL.BufferData(Target, Size, IntPtr.Zero, UsageHint);
        }

        public void Bind()
        {
            GL.BindBuffer(Target, BufferId);
        }

        public void Unbind()
        {
            GL.BindBuffer(Target, 0);
        }
    }
}