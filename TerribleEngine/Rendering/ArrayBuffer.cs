using OpenTK.Graphics.OpenGL;

namespace TerribleEngine.Rendering
{
    public class ArrayBuffer : Buffer
    {

        public ArrayBuffer(int bufferId, int size, BufferUsageHint usageHint) 
            : base (BufferTarget.ArrayBuffer, bufferId, size, usageHint)
        {
        }


    }
}