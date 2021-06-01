using System;

using SlimDX;

namespace Flaxen.SlimDXControlLib {
    public class ColorRamp {
        private readonly float m_minValue;

        private readonly float m_maxValue;

        private readonly float m_dv;

        private readonly float m_dv14;

        private readonly float m_r1;

        private readonly float m_r2;

        private readonly float m_r2m;

        private readonly float m_r3;

        public ColorRamp(float minValue, float maxValue) {
            if (maxValue <= minValue) {
                throw new ArgumentOutOfRangeException("maxValue", "maxValue not greater than minValue");
            }
            m_minValue = minValue;
            m_maxValue = maxValue;
            m_dv = m_maxValue - m_minValue;
            m_dv14 = m_dv / 4f;
            m_r1 = m_minValue + m_dv * 0.25f;
            m_r2 = m_minValue + m_dv * 0.5f;
            m_r2m = m_minValue - m_dv * 0.5f;
            m_r3 = m_minValue + m_dv * 0.75f;
        }

        public static Color3 GetColor(float value, float minValue, float maxValue) {
            Color3 color3 = new Color3(1f, 1f, 1f);
            if (value < minValue) {
                value = minValue;
            }
            if (value > maxValue) {
                value = maxValue;
            }
            float single = maxValue - minValue;
            if ((double)value < (double)minValue + 0.25 * (double)single) {
                color3.Red = 0f;
                color3.Green = 4f * (value - minValue) / single;
            } else if ((double)value < (double)minValue + 0.5 * (double)single) {
                color3.Red = 0f;
                color3.Blue = 1f + 4f * (minValue + 0.25f * single - value) / single;
            } else if ((double)value >= (double)minValue + 0.75 * (double)single) {
                color3.Green = 1f + 4f * (minValue + 0.75f * single - value) / single;
                color3.Blue = 0f;
            } else {
                color3.Red = 4f * (value - minValue - 0.5f * single) / single;
                color3.Blue = 0f;
            }
            return color3;
        }

        public Color3 GetColor(float value) {
            Color3 mDv14 = default(Color3);
            if (value < m_minValue) {
                value = m_minValue;
            }
            if (value > m_maxValue) {
                value = m_maxValue;
            }
            if (value < m_r1) {
                mDv14.Red = 0f;
                mDv14.Green = m_dv14 * (value - m_minValue);
                mDv14.Blue = 1f;
            } else if (value < m_r2) {
                mDv14.Red = 0f;
                mDv14.Green = 1f;
                mDv14.Blue = 1f + m_dv14 * (m_r1 - value);
            } else if (value >= m_r3) {
                mDv14.Red = 1f;
                mDv14.Green = 1f + m_dv14 * (m_r3 - value);
                mDv14.Blue = 0f;
            } else {
                mDv14.Red = m_dv14 * (value - m_r2m);
                mDv14.Green = 1f;
                mDv14.Blue = 0f;
            }
            return mDv14;
        }

        public static void Test() {
            Random random = new Random();
            for (int i = 0; i < 10000; i++) {
                float single = (float)random.NextDouble();
                float single2 = (float)random.NextDouble();
                if (single >= single2) {
                    float num = single;
                    single = single2;
                    single2 = num;
                }
                float single3 = (float)random.NextDouble();
                new ColorRamp(single, single2).GetColor(single3);
                GetColor(single3, single, single2);
            }
        }
    }
}
