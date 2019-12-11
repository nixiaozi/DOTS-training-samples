﻿using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

[BurstCompile]
unsafe struct UpdateMeshJob : IJobParallelFor
{
    public NativeArray<float3> vertices;
    public NativeArray<float3> oldVertices;
    public float3 gravity;

    public void Execute(int i)
    {
        float3 oldVert = oldVertices[i];
        float3 vert = vertices[i];

        float3 startPos = vert;
        oldVert -= gravity;
        vert += (vert - oldVert);

        oldVert = startPos;

        vertices[i] = vert;
        oldVertices[i] = oldVert;
    }
}