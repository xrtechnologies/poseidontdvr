using System;
using System.Collections.Generic;

[Serializable]
public class Wave
{
    public List<WavePart> WaveParts { get; set; } = new List<WavePart>();
}