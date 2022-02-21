using System.Collections.Generic;
using UnityEngine;

public class SampleWaveDefinition
{
    // Definition of waves --> next step. Serialize this to Resource and load on demand.
    public static List<Wave> Wave1 => new List<Wave>{
            // Wave 1
            new Wave
            {
                WaveParts = new List<WavePart>
                    {
                    new WavePart
                    {
                        EnemyType = WavePart.ENEMY_TYPE_CART,
                        Amount = 3,
                        DensityDelay = 1.0f,
                        Scale = new Vector3(2f, 2f, 2f),
                        Speed = 0.25f
                    },
                    new WavePart
                    {
                        EnemyType = WavePart.ENEMY_TYPE_PLAYER,
                        Amount = 3,
                        DensityDelay = 1.0f,
                        Scale = new Vector3(7f, 7f, 7f),
                        Speed = 0.5f
                    }
                }
            },
            // Wave 2
            new Wave
            {
                WaveParts = new List<WavePart>
                    {
                    new WavePart
                    {
                        EnemyType = WavePart.ENEMY_TYPE_PLAYER,
                        Amount = 6,
                        DensityDelay = 2.0f,
                        Scale = new Vector3(5f, 5f, 5f),
                        Speed = 2.0f
                    },
                    new WavePart
                    {
                        EnemyType = WavePart.ENEMY_TYPE_CART,
                        Amount = 5,
                        DensityDelay = 0.5f,
                        Scale = new Vector3(6f, 6f, 6f),
                        Speed = 3.0f
                    }
                }
            },

        };
}