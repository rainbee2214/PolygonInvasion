/**********************************************************************
 * Sacred Seed Studio - Unity Namespace
 * Random Module
 * v0.1.0
 *
 * Created: August 3 2015
 * Modified: August 3 2015
 *
 * The only rules:
 * 1. If you modify something, verify its documentation is still valid.
 * 2. Write some tests.
 * 3. Update the Modified date.
 *
 * Random Number Generators
 *********************************************************************/

using UnityEngine;

namespace SSS
{
    namespace Random
    {
        public static class RandomAlt
        {
            /// <summary>
            /// The Park-Miller Lehmer generator http://www.wikiwand.com/en/Lehmer_random_number_generator
            /// </summary>
            /// <param name="alt">Whether to use "alternative" bigger number</param>
            /// <returns>a pseudo random unsigned int</returns>
            public static uint Lehmer_PM(bool alt = false)
            {
                uint seed = (uint)(42 * UnityEngine.Random.Range(0, 987654321));
                uint multiplier = (uint)(alt ? 279470273 : 48271);
                uint mod = (alt ? 2147483647 : 4294967291);
                return (seed * multiplier) % mod;
            }
        }
    }
}