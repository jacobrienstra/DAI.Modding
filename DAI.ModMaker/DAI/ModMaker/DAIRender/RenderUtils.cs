using System;
using System.IO;
using System.Reflection;

using DAI.FrostbiteAssets;

using SlimDX;
using SlimDX.D3DCompiler;
using SlimDX.Direct3D11;

namespace DAI.ModMaker.DAIRender
{
    public class RenderUtils
    {
        public static Matrix LinearTransformToMatrix(LinearTransform Transform)
        {
            Matrix matrix2 = Matrix.RotationQuaternion(LinearTransformToQuat(Transform));
            Matrix matrix1 = Matrix.Translation(new Vector3(Transform.trans.x, Transform.trans.y, Transform.trans.z));
            return matrix2 * matrix1;
        }

        public static Quaternion LinearTransformToQuat(LinearTransform Transform)
        {
            Matrix transform = default(Matrix);
            transform.M11 = Transform.right.x;
            transform.M12 = Transform.right.y;
            transform.M13 = Transform.right.z;
            transform.M14 = 0f;
            transform.M21 = Transform.up.x;
            transform.M22 = Transform.up.y;
            transform.M23 = Transform.up.z;
            transform.M24 = 0f;
            transform.M31 = Transform.forward.x;
            transform.M32 = Transform.forward.y;
            transform.M33 = Transform.forward.z;
            transform.M34 = 0f;
            transform.M41 = 0f;
            transform.M42 = 0f;
            transform.M43 = 0f;
            transform.M44 = 1f;
            Quaternion m12 = default(Quaternion);
            float m11 = transform.M11 + transform.M22 + transform.M33;
            if (m11 <= 0f)
            {
                int num = 0;
                if (transform.M22 > transform.M11)
                {
                    num = 1;
                }
                float m13 = transform.M33;
                int num4 = num;
                if (m13 > transform[num4, num4])
                {
                    num = 2;
                }
                int[] obj = new int[3] { 1, 2, 0 };
                int num2 = obj[num];
                int num3 = obj[num2];
                int num5 = num;
                float item = transform[num5, num5] - transform[num2, num2] - transform[num3, num3] + 1f;
                float single = 1f / (float)Math.Sqrt(item);
                float[] singleArray = new float[4];
                singleArray[num] = 0.5f * (1f / single);
                item = 0.5f * single;
                singleArray[3] = (transform[num2, num3] - transform[num3, num2]) * item;
                singleArray[num2] = (transform[num, num2] + transform[num2, num]) * item;
                singleArray[num3] = (transform[num, num3] + transform[num3, num]) * item;
                m12.X = singleArray[0];
                m12.Y = singleArray[1];
                m12.Z = singleArray[2];
                m12.W = singleArray[3];
            }
            else
            {
                float single2 = 1f / (float)Math.Sqrt(m11 + 1f);
                m12.W = 0.5f * (1f / single2);
                float item = 0.5f * single2;
                m12.X = (transform.M23 - transform.M32) * item;
                m12.Y = (transform.M31 - transform.M13) * item;
                m12.Z = (transform.M12 - transform.M21) * item;
            }
            m12.Normalize();
            return m12;
        }

        public static void LoadShader(Device Device, string ShaderName, string VSEntry, string PSEntry, out VertexShader OutVS, out PixelShader OutPS, out ShaderSignature OutSignature)
        {
            Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DAI.ModMaker.Resources.Shaders." + ShaderName);
            byte[] numArray = new byte[manifestResourceStream.Length - 4];
            manifestResourceStream.Read(numArray, 0, 4);
            manifestResourceStream.Read(numArray, 0, (int)manifestResourceStream.Length - 4);
            manifestResourceStream.Close();
            ShaderSignature inputSignature;
            using (ShaderBytecode shaderBytecode = ShaderBytecode.Compile(numArray, VSEntry, "vs_5_0", ShaderFlags.None, EffectFlags.None))
            {
                OutVS = new VertexShader(Device, shaderBytecode);
                inputSignature = ShaderSignature.GetInputSignature(shaderBytecode);
            }
            using (ShaderBytecode shaderBytecode2 = ShaderBytecode.Compile(numArray, PSEntry, "ps_5_0", ShaderFlags.None, EffectFlags.None))
            {
                OutPS = new PixelShader(Device, shaderBytecode2);
            }
            OutSignature = inputSignature;
        }

        public static void ReleaseCOM(ComObject Obj)
        {
            if (Obj != null)
            {
                Obj.Dispose();
                Obj = null;
            }
        }

        public static Matrix TransRotScaleToMatrix(Vector3 InTrans, Vector4 InRot, Vector3 InScale)
        {
            Matrix matrix = Matrix.Translation(InTrans);
            Matrix matrix2 = Matrix.RotationQuaternion(new Quaternion(InRot.X, InRot.Y, InRot.Z, InRot.W));
            Matrix.Scaling(InScale);
            return matrix2 * matrix;
        }
    }
}
